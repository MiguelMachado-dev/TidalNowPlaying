using TidalNowPlaying;

static void Equal<T>(T expected, T actual, string scenario)
{
    if (!EqualityComparer<T>.Default.Equals(expected, actual))
        throw new Exception($"Failed: {scenario}. Expected [{expected}], got [{actual}].");
}

const string song = "Björk - Jóga";
var settings = new OutputSettings();
Equal("Current Song: " + song, settings.Format(song), "existing default output");
settings.IncludePrefix = false;
Equal(song, settings.Format(song), "prefix omitted");
settings.TrailingSpaces = 5;
Equal(song + "     ", settings.Format(song), "exact trailing spaces without newline");
settings.IncludePrefix = true;
Equal("Current Song: " + song + "     ", settings.Format(song), "prefix and spacing together");
Equal(string.Empty, settings.Format(string.Empty), "no prefix or padding without a song");
settings.TrailingSpaces = -1;
Equal("Current Song: " + song, settings.Format(song), "negative spacing clamped");
settings.TrailingSpaces = 101;
Equal("Current Song: " + song + new string(' ', 100), settings.Format(song), "maximum spacing");

string folder = Path.Combine(Path.GetTempPath(), "TidalNowPlayingTests", Guid.NewGuid().ToString("N"));
string path = Path.Combine(folder, "settings.json");
Equal("Current Song: " + song, OutputSettings.Load(path).Format(song), "missing settings");
settings.IncludePrefix = false;
settings.TrailingSpaces = 12;
settings.Save(path);
Equal(song + new string(' ', 12), OutputSettings.Load(path).Format(song), "settings survive reload");
File.WriteAllText(path, "invalid JSON");
Equal("Current Song: " + song, OutputSettings.Load(path).Format(song), "malformed settings");
File.WriteAllText(path, "null");
Equal("Current Song: " + song, OutputSettings.Load(path).Format(song), "null settings");
File.WriteAllText(path, "{}");
Equal("Current Song: " + song, OutputSettings.Load(path).Format(song), "missing properties");
File.WriteAllText(path, "{\"TrailingSpaces\":1000}");
Equal(100, OutputSettings.Load(path).TrailingSpaces, "loaded spacing upper bound");
File.WriteAllText(path, "{\"TrailingSpaces\":-5}");
Equal(0, OutputSettings.Load(path).TrailingSpaces, "loaded spacing lower bound");
File.WriteAllText(path, "{\"TrailingSpaces\":\"bad\"}");
Equal("Current Song: " + song, OutputSettings.Load(path).Format(song), "invalid property type");
Console.WriteLine("Passed 15 output formatting and settings checks.");
