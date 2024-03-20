using System.Text.Json.Serialization;

namespace FH.Giveaway;

internal class Data
{
    public DateOnly Date { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool WantsEmails { get; set; }
    public bool Won { get; set; }
    public string? Id { get; set; }

    [JsonIgnore]
    public string FullName => FirstName + " " + LastName;
}