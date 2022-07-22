using XIVLauncher.Common;

namespace XIVLauncher.Core.Components.SettingsPage.Tabs;

public class SettingsTabGame : SettingsTab
{
    public override SettingsEntry[] Entries { get; } =
    {
        new SettingsEntry<DirectoryInfo>("Game Path", "Where the game is installed to.", () => Program.Config.GamePath, x => Program.Config.GamePath = x)
        {
            CheckValidity = x =>
            {
                if (string.IsNullOrWhiteSpace(x?.FullName))
                    return "Game path is not set.";

                if (x.Name == "game" || x.Name == "boot")
                    return "Please select the path containing the folders \"game\" and \"boot\", not the folders itself.";

                return null;
            }
        },

        new SettingsEntry<DirectoryInfo>("Game Config Path", "Where the user config files will be stored.", () => Program.Config.GameConfigPath, x => Program.Config.GameConfigPath = x)
        {
            CheckValidity = x => string.IsNullOrWhiteSpace(x?.FullName) ? "Game Config Path is not set." : null,

            // TODO: We should also support this on Windows
            CheckVisibility = () => Environment.OSVersion.Platform == PlatformID.Unix,
        },

        new SettingsEntry<bool>("Use DirectX11", "Use the modern DirectX11 version of the game.", () => Program.Config.IsDx11 ?? true, x => Program.Config.IsDx11 = x)
        {
            CheckWarning = x => !x ? "DirectX 9 is no longer supported by Square Enix or Dalamud. Things may not work." : null,
            CheckVisibility = () => false,
        },

        new SettingsEntry<string>("Additional Arguments", "Additional args to start the game with", () => Program.Config.AdditionalArgs, x => Program.Config.AdditionalArgs = x),
        new SettingsEntry<ClientLanguage>("Game Language", "Select the game's language.", () => Program.Config.ClientLanguage ?? ClientLanguage.ChineseSimplified, x => Program.Config.ClientLanguage = x)
        {
            CheckVisibility = () => false,
        },
        new SettingsEntry<DpiAwareness>("Game DPI Awareness", "Select the game's DPI Awareness. Change this if the game's scaling looks wrong.", () => Program.Config.DpiAwareness ?? DpiAwareness.Unaware, x => Program.Config.DpiAwareness = x),
        new SettingsEntry<bool>("Free trial account", "Check this if you are using a free trial account.", () => Program.Config.IsFt ?? false, x => Program.Config.IsFt = x)
        {
            CheckVisibility = () => false,
        },
        new SettingsEntry<bool>("Use XIVLauncher authenticator/OTP macros", "Check this if you want to use the XIVLauncher authenticator app or macros.", () => Program.Config.IsOtpServer ?? false, x => Program.Config.IsOtpServer = x)
        {
            CheckVisibility = () => false,
        },
    };

    public override string Title => "Game";

    public override void Draw()
    {
        base.Draw();
    }
}