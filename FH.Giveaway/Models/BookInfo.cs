namespace FH.Giveaway;

public class BookInfo
{
    public required string Code { get; init; }
    public required string ASIN { get; init; }
    public required string Slug { get; init; }
    public required string Title { get; init; }
    public required string Author { get; init; }
    public required DateTime PubDate { get; init; }
    public required string ImageFile { get; init; }

    public int Quantity { get; set; }

    public string ImageUrl => "/images/" + ImageFile;

    public string AmazonUri => 
        $"https://www.amazon.com/{Slug}/dp/{ASIN}";
}