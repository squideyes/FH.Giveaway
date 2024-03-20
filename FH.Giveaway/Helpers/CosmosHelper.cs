using Microsoft.Azure.Cosmos;
using SquidEyes.Fundamentals;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace FH.Giveaway;

internal static partial class CosmosHelper
{
    private static readonly Regex errorsParser = GetErrorsParser();

    public static string GetErrorMessage(string body)
    {
        var sb = new StringBuilder();

        var match = errorsParser.Match(body);

        if (match.Success)
            sb.Append($"{match.Groups["E"].Value.Split(',').First()}.");
        else
            sb.Append($"An error occured while saving this entry.");

        sb.Append("  (Please show this message to your host.)");

        return sb.ToString();
    }

    public static CosmosClient GetCosmosClient(IConfiguration config)
    {
        var handler = new SocketsHttpHandler()
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(5)
        };

        var jso = new JsonSerializerOptions()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        jso.Converters.Add(new JsonStringDateOnlyConverter());
        jso.Converters.Add(new JsonStringEnumConverter());

        var serializer = new CosmosSystemTextJsonSerializer(jso);

        var cco = new CosmosClientOptions()
        {
            ConnectionMode = ConnectionMode.Direct,
            HttpClientFactory = () => new HttpClient(handler, false),
            OpenTcpConnectionTimeout = TimeSpan.FromMilliseconds(500),
            RequestTimeout = TimeSpan.FromMilliseconds(1500),
            Serializer = serializer
        };

        var connString = config["Cosmos:ConnString"]!;

        return new CosmosClient(connString, cco);
    }

    [GeneratedRegex("\"Errors\":\\[(?<E>.*?)]")]
    private static partial Regex GetErrorsParser();
}