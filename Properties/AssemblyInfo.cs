[assembly: AssemblyTitle(MediaPlayer.Main.Description)]
[assembly: AssemblyDescription(MediaPlayer.Main.Description)]
[assembly: AssemblyCompany(MediaPlayer.Main.Company)]
[assembly: AssemblyProduct(MediaPlayer.Main.Name)]
[assembly: AssemblyCopyright("Developed by " + MediaPlayer.Main.Author)]
[assembly: AssemblyTrademark(MediaPlayer.Main.Company)]
[assembly: AssemblyVersion(MediaPlayer.Main.Version)]
[assembly: AssemblyFileVersion(MediaPlayer.Main.Version)]
[assembly:
    MelonInfo(typeof(MediaPlayer.Main), MediaPlayer.Main.Name, MediaPlayer.Main.Version,
        MediaPlayer.Main.Author, MediaPlayer.Main.DownloadLink)]
[assembly: MelonColor(ConsoleColor.Magenta)]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("Stress Level Zero", "BONELAB")]