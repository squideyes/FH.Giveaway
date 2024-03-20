// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

namespace FH.Giveaway;

public class VideoInfo
{
    public required string VideoId { get; init; }
    public required string Author { get; init; }
    public required string Title { get; init; }
    public required Uri ImageUri { get; init; }
    public required Uri VideoUri { get; init; }
    public required TimeSpan? Duration { get; init; }
}