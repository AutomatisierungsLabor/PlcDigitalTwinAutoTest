using System;
using System.Windows.Controls;

namespace LibWpf;

public partial class LibWpf
{
    public void VideoAutoPlay(string source, int xPos, int xSpan, int yPos, int ySpan)
    {
        var mediaElement = new MediaElement
        {
            Source = new Uri(@$"Videos\{source}", UriKind.Relative),
            LoadedBehavior = MediaState.Manual
        };

        mediaElement.MediaEnded += (_, _) =>
        {
            mediaElement.Position = TimeSpan.Zero;
            mediaElement.Play();
        };

        mediaElement.Play();

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, mediaElement);
    }
}