namespace MediaPlayer;

/// <summary>
/// Wrapper class for TagLibSharp
/// </summary>
public static class TagLib
{
    #region Public
    /// <summary>
    /// Enum for the different tags that can be retrieved from a file
    /// </summary>
    public enum Tag
    {
        /// <summary>
        /// The title of the song
        /// </summary>
        Title,
        /// <summary>
        /// The artist of the song
        /// </summary>
        Artist,
        /// <summary>
        /// The album of the song
        /// </summary>
        Album,
        /// <summary>
        /// The album artist of the song
        /// </summary>
        AlbumArtist,
        /// <summary>
        /// The genre of the song
        /// </summary>
        Genre,
        /// <summary>
        /// The year of the song
        /// </summary>
        Year,
        /// <summary>
        /// The track number of the song
        /// </summary>
        Track,
        /// <summary>
        /// The disc number of the song
        /// </summary>
        Disc,
        /// <summary>
        /// The composer of the song
        /// </summary>
        Composer,
        /// <summary>
        /// The conductor of the song
        /// </summary>
        Conductor,
    }

    private static string _tag;

    /// <summary>
    /// Gets a tag from an audio file
    /// </summary>
    /// <param name="filepath">The path to the audio file</param>
    /// <param name="tag">The tag to get</param>
    /// <returns>String of requested tag</returns>
    public static string GetTag(string filepath, Tag tag)
    {
        var tagLibFile = global::TagLib.File.Create(filepath);
        _tag = tag switch
        {
            Tag.Title => tagLibFile.Tag.Title,
            Tag.Artist => tagLibFile.Tag.FirstPerformer,
            Tag.Album => tagLibFile.Tag.Album,
            Tag.AlbumArtist => tagLibFile.Tag.FirstAlbumArtist,
            Tag.Genre => tagLibFile.Tag.FirstGenre,
            Tag.Year => tagLibFile.Tag.Year.ToString(),
            Tag.Track => tagLibFile.Tag.Track.ToString(),
            Tag.Disc => tagLibFile.Tag.Disc.ToString(),
            Tag.Composer => tagLibFile.Tag.FirstComposer,
            Tag.Conductor => tagLibFile.Tag.Conductor,
            _ => null
        };
        if (_tag == null)
        {
            ModConsole.Error($"{filepath}'s {tag.ToString()} field is null!");
            return null;
        }
        return _tag;
    }

    /// <summary>
    /// Gets the album art from an audio file
    /// </summary>
    /// <param name="filepath">The path to the audio file</param>
    /// <returns>Texture2D of the album cover</returns>
    public static Texture2D GetCover(string filepath)
    {
        var tagLibFile = global::TagLib.File.Create(filepath);
        var picture = tagLibFile.Tag.Pictures[0];
        if (picture == null)
        {
            ModConsole.Error($"{filepath}'s album art field is null!");
            return null;
        }
        var texture = new Texture2D(2, 2);
        // ReSharper disable once InvokeAsExtensionMethod, unhollowed unity extensions don't work well, have to call them directly
        ImageConversion.LoadImage(texture, picture.Data.Data, false);
        return texture;
    }
    
    
    /// <summary>
    /// Gets the filename of an audio file
    /// </summary>
    /// <param name="filepath">The path to the audio file</param>
    /// <returns>String of filename</returns>
    public static string GetFilename(string filepath)
    {
        var title = Path.GetFileName(filepath);
        return title;
    }
    #endregion
    #region Internal

    private static string _privateTag;
    internal static string GetTag(int index, Tag tag)
    {
        var file = Assets.FilePaths[index];
        var tagLibFile = global::TagLib.File.Create(file);
        _privateTag = tag switch
        {
            Tag.Title => tagLibFile.Tag.Title,
            Tag.Artist => tagLibFile.Tag.FirstPerformer,
            Tag.Album => tagLibFile.Tag.Album,
            Tag.AlbumArtist => tagLibFile.Tag.FirstAlbumArtist,
            Tag.Genre => tagLibFile.Tag.FirstGenre,
            Tag.Year => tagLibFile.Tag.Year.ToString(),
            Tag.Track => tagLibFile.Tag.Track.ToString(),
            Tag.Disc => tagLibFile.Tag.Disc.ToString(),
            Tag.Composer => tagLibFile.Tag.FirstComposer,
            Tag.Conductor => tagLibFile.Tag.Conductor,
            _ => null
        };
        if (_privateTag == null)
        {
            ModConsole.Error($"{file}'s {tag.ToString()} field is null!");
            return null;
        }
        return _privateTag;
    }
    
    internal static Texture2D GetCover(int index)
    {
        var file = Assets.FilePaths[index];
        var tagLibFile = global::TagLib.File.Create(file);
        var picture = tagLibFile.Tag.Pictures[0];
        if (picture == null)
        {
            ModConsole.Error($"{file}'s album art field is null!");
            return null;
        }
        var texture = new Texture2D(2, 2);
        // ReSharper disable once InvokeAsExtensionMethod, unhollowed unity extensions don't work well, have to call them directly
        ImageConversion.LoadImage(texture, picture.Data.Data, false);
        return texture;
    }
    
    internal static string GetFilename(int index)
    {
        var file = Assets.FilePaths[index];
        var title = Path.GetFileName(file);
        return title;
    }
    #endregion
}