using YoutubeExplode;
using YoutubeExplode.Common;

namespace FH.Giveaway;

public static class YouTubeHelper
{
    public static async Task<VideoInfo[]> GetVideoInfos()
    {
        const string PLAYLIST_ID = "PL2z8DaMofPICkaMtAovA5z2VKYrF7WsrZ";

        var youtube = new YoutubeClient();

        var playlists = await youtube.Playlists.GetVideosAsync(PLAYLIST_ID);

        var infos = new List<VideoInfo>();

        foreach (var video in playlists)
        {
            var last = video.Thumbnails[video.Thumbnails.Count - 1];

            var info = new VideoInfo()
            {
                Title = video.Title,
                Author = video.Author.ChannelTitle,
                VideoId = video.Id,
                ImageUri = new Uri(last.Url),
                VideoUri = new Uri(video.Url),
                Duration = video.Duration
            };

            infos.Add(info);
        }

        return infos.ToArray();
    }
}
