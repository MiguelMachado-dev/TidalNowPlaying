using System.Text.Json;

namespace TidalNowPlaying
{
    internal sealed class OutputSettings
    {
        public const int MaxTrailingSpaces = 100;

        public bool IncludePrefix { get; set; } = true;
        public int TrailingSpaces { get; set; }

        public string Format(string songInfo)
        {
            if (string.IsNullOrEmpty(songInfo))
                return string.Empty;

            return (IncludePrefix ? "Current Song: " : string.Empty)
                + songInfo + new string(' ', Math.Clamp(TrailingSpaces, 0, MaxTrailingSpaces));
        }

        public static OutputSettings Load(string filePath)
        {
            try
            {
                var settings = JsonSerializer.Deserialize<OutputSettings>(File.ReadAllText(filePath))
                    ?? new OutputSettings();
                settings.TrailingSpaces = Math.Clamp(settings.TrailingSpaces, 0, MaxTrailingSpaces);
                return settings;
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                return new OutputSettings();
            }
        }

        public void Save(string filePath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(filePath))!);
            File.WriteAllText(filePath, JsonSerializer.Serialize(this));
        }
    }
}
