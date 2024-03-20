using Azure.Core.Serialization;
using Microsoft.Azure.Cosmos;
using System.Text.Json;

namespace FH.Giveaway;

public class CosmosSystemTextJsonSerializer(
    JsonSerializerOptions options) : CosmosSerializer
{
    private readonly JsonObjectSerializer serializer = new(options);

    public override T FromStream<T>(Stream stream)
    {
        using (stream)
        {
            if (stream.CanSeek && stream.Length == 0)
                return default!;

            if (typeof(Stream).IsAssignableFrom(typeof(T)))
                return (T)(object)stream;

            return (T)serializer.Deserialize(stream, typeof(T), default)!;
        }
    }

    public override Stream ToStream<T>(T input)
    {
        var payload = new MemoryStream();

        serializer.Serialize(payload, input, input.GetType(), default);

        payload.Position = 0;

        return payload;
    }
}