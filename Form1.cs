using DiscordRPC.Message;
using DiscordRPC;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using windows_discord_presence.Properties;

namespace windows_discord_presence
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// The level of logging to use.
        /// </summary>
        private static DiscordRPC.Logging.LogLevel logLevel = DiscordRPC.Logging.LogLevel.Info;

        /// <summary>
        /// The pipe to connect too.
        /// </summary>
        private static readonly int discordPipe = -1;

        /// <summary>
        /// The current presence to send to discord.
        /// </summary>
        private static RichPresence Presence = new RichPresence()
        {
            Details = Environment.OSVersion.VersionString,
            State = "Running ...",
            Assets = new Assets()
            {
                LargeImageKey = "windows11",
                LargeImageText = "...",
                SmallImageKey = "image_small"
            }
        };

        private RichPresence CreateRichPresence(string state, string details, string largeImageKey, string largeImageText, string smallImageKey, string smallImageText)
        {
            return new()
            {
                Details = details,
                State = state,
                Assets = new()
                {
                    LargeImageKey = largeImageKey,
                    LargeImageText = largeImageText,
                    SmallImageKey = smallImageKey,
                    SmallImageText = smallImageText
                }
            };
        }

        private RichPresence CreateRichPresence(string state, string details, string largeImageKey, string largeImageText, string smallImageKey, string smallImageText, DiscordRPC.Button[] buttons)
        {
            return new()
            {
                Buttons = buttons,
                Details = details,
                State = state,
                Assets = new()
                {
                    LargeImageKey = largeImageKey,
                    LargeImageText = largeImageText,
                    SmallImageKey = smallImageKey,
                    SmallImageText = smallImageText
                }
            };
        }

        /// <summary>
        /// The discord client
        /// </summary>
        private static DiscordRpcClient client = new(applicationID: appID, pipe: discordPipe)
        {
            Logger = new DiscordRPC.Logging.ConsoleLogger(logLevel, true)
        };


        /// <summary>
        /// The application ID to use
        /// </summary>
        private const string appID = "1075783408149598208";

        public Form1()
        {
            InitializeComponent();
        }

        enum WindowsRelease
        {
            Vista = 5,
            Seven = 7,
            Eight = 8,
            EightOne = 81,
            Ten = 10,
            Eleven = 11
        }

        public enum WindowsVersion : short
        {
            Win10 = 10,
            Win11 = 10,
            Win8 = 6,
            Win81 = 6,
            Win7 = 6,
            WinVista = 6
        }

        public enum WindowsMinor : short
        {
            Win10 = 0,
            Win11 = 0,
            Win8 = 2,
            Win81 = 3,
            Win7 = 1,
            WinVista = 0
        }

        public enum WindowsBuild : short
        {
            Win10 = 0,
            Win11 = 22000,
            Win8 = 0,
            Win81 = 0,
            Win7 = 0,
            WinVista = 0
        }

        string largeImageKey = string.Empty;
        WindowsRelease windowsRelease;
        string osName = "Windows";

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

            instagram_button_checkbox.Checked = Settings.Default.instagram_button;
            whatsapp_button_checkbox.Checked = Settings.Default.whatsapp_button;

            instagram_username_textbox.Text = Settings.Default.instagram_username;
            whatsapp_phone_textbox.Text = Settings.Default.whatsapp_phone.ToString("0 000 000 0000");

            // == Subscribe to some events
            client.OnReady += (sender, msg) =>
            {
                //Create some events so we know things are happening
                Console.WriteLine("Connected to discord with user {0}", msg.User.Username);
            };

            client.OnPresenceUpdate += (sender, msg) =>
            {
                //The presence has updated
                Console.WriteLine("Presence has been updated! ");
            };

            // == Initialize
            client.Initialize();

            // == Get the OS version
            if (Environment.OSVersion.Platform != PlatformID.Win32NT)
            {
                Console.WriteLine("Platform not supported: {0}", Environment.OSVersion.VersionString);
                Environment.Exit(1);
                return;
            }
            else
            {
                if (OperatingSystem.IsWindowsVersionAtLeast((int)WindowsVersion.Win11, (int)WindowsMinor.Win11, (int)WindowsBuild.Win11))
                {
                    windowsRelease = WindowsRelease.Eleven;
                }
                else if (OperatingSystem.IsWindowsVersionAtLeast((int)WindowsVersion.Win10))
                {
                    windowsRelease = WindowsRelease.Ten;
                }
                else if (OperatingSystem.IsWindowsVersionAtLeast((int)WindowsVersion.Win81, (int)WindowsMinor.Win81))
                {
                    windowsRelease = WindowsRelease.EightOne;
                }
                else if (OperatingSystem.IsWindowsVersionAtLeast((int)WindowsVersion.Win8, (int)WindowsMinor.Win8))
                {
                    windowsRelease = WindowsRelease.Eight;
                }
                else if (OperatingSystem.IsWindowsVersionAtLeast((int)WindowsVersion.Win7, (int)WindowsMinor.Win7))
                {
                    windowsRelease = WindowsRelease.Seven;
                }
                else
                {
                    windowsRelease = WindowsRelease.Vista;
                }
            }

            switch (windowsRelease)
            {
                case WindowsRelease.Vista:
                    largeImageKey = "windowsvista";
                    break;
                case WindowsRelease.Seven:
                    largeImageKey = "windows7";
                    break;
                case WindowsRelease.EightOne:
                case WindowsRelease.Eight:
                    largeImageKey = "windows8";
                    break;
                case WindowsRelease.Ten:
                    largeImageKey = "windows10";
                    break;
                case WindowsRelease.Eleven:
                    largeImageKey = "windows11";
                    break;
            }

            osName = "Windows " + StringExtensions.FirstCharToUpper(largeImageKey.Remove(0, "windows".Length));

            // == Set the presence
            client.SetPresence(CreateRichPresence(osName, string.Empty, largeImageKey, string.Empty, string.Empty, string.Empty));
        }

        private void SyncSettings()
        {
            Settings.Default["instagram_username"] = instagram_username_textbox.Text;
            Settings.Default["instagram_button"] = instagram_button_checkbox.Checked;
            Settings.Default["whatsapp_button"] = whatsapp_button_checkbox.Checked;

            try
            {
                Settings.Default["whatsapp_phone"] = ulong.Parse(whatsapp_phone_textbox.Text.Replace(" ", string.Empty));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not save phone number: {ex.Message}", "Windows Discord Presence", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            notifyIcon1.ShowBalloonTip(1, "Windows Discord Presence", "Applied preferences", ToolTipIcon.Info);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Settings.Default.Save();
            Console.WriteLine("Main window is closing" + Environment.NewLine + "Disposing client . . . ");            
            client.Dispose();
        }

        bool notificationShown = false;

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Normal)
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Minimized;
                Hide();
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                if (!notificationShown)
                {
                    notificationShown = true;
                    notifyIcon1.ShowBalloonTip(1, "Windows Discord Presence", "Windows Discord Presence is running in the System Tray", ToolTipIcon.Info);
                }
            }
            WindowState = FormWindowState.Normal;
        }

        string oldAppTitle = string.Empty;

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Process foregroundWindowProcess = ProcessUtils.GetForgroundWindowProcess();
            string? apptitle;

            try
            {
                apptitle = foregroundWindowProcess.MainModule?.FileVersionInfo.FileDescription;
            }
            catch
            {
                apptitle = null;
            }

            try
            {
                if (apptitle is null)
                    apptitle = string.Empty + foregroundWindowProcess.ProcessName;

                if (apptitle == "Windows Shell Experience Host")
                {
                    apptitle = "Windows Explorer";
                }

                if (apptitle == "Application Frame Host")
                {
                    apptitle = string.Empty + Path.GetFileNameWithoutExtension(UWP.UwpUtils.GetProcessName(foregroundWindowProcess.MainWindowHandle));
                }

                if (foregroundWindowProcess.ProcessName == "javaw")
                {
                    apptitle = foregroundWindowProcess.MainWindowTitle;
                    if (apptitle.StartsWith("Minecraft"))
                    {
                        apptitle = apptitle.Replace("Minecraft*", "Minecraft");
                        if (apptitle.Contains("Multiplayer"))
                            apptitle = "Minecraft Java Multiplayer";
                        else
                            apptitle = apptitle.Replace("Minecraft", "Minecraft Java Edition");
                    }

                    if (apptitle.StartsWith("TLauncher"))
                    {
                        apptitle = apptitle.Replace("TLauncher", "Minecraft Launcher");
                    }
                }

                if (foregroundWindowProcess.ProcessName == "SearchHost" || foregroundWindowProcess.ProcessName == "StartMenuExperienceHost")
                {
                    apptitle = "Windows Start Menu";
                }

                if (foregroundWindowProcess.ProcessName.ToLower() == "msedge")
                {
                    if (foregroundWindowProcess.MainWindowTitle.StartsWith("Instagram"))
                    {
                        apptitle = "Instagram";
                    }
                    else if (foregroundWindowProcess.MainWindowTitle.StartsWith("WhatsApp"))
                    {
                        apptitle = "WhatsApp";
                    }
                }

                apptitle = apptitle.Replace("Minecraft.Windows", "Minecraft Bedrock");
                apptitle = apptitle.Replace("PowerToys.Run", "Windows Explorer");
                apptitle = apptitle.Replace("WindowsTerminal.exe", "Windows Terminal");
                apptitle = apptitle.Replace("wt.exe", "Windows Terminal");
                apptitle = apptitle.Replace("SecHealthUI", "Windows Defender");
                apptitle = apptitle.Replace("SystemSettings", "Settings");
                apptitle = apptitle.Replace("COM Surrogate", string.Empty);
                apptitle = apptitle.Replace("LockApp.exe", string.Empty);
                apptitle = apptitle.Replace("PhotosApp", "Windows Photos");
                apptitle = apptitle.Replace("Video.UI", "Movies & TV");
                apptitle = apptitle.Replace("WinStore.App", "Microsoft Store");
                apptitle = apptitle.Replace("SnippingTool.exe", "Snipping Tool");


                apptitle = apptitle.Replace("Microsoft", "MS");
            }
            catch
            {
                apptitle = string.Empty;
            }

            if (oldAppTitle != apptitle) {
                try
                {
                    bool presenceSet = false;

                    if (apptitle.Equals("WhatsApp") && Settings.Default.whatsapp_button)
                    {
                        client.SetPresence(CreateRichPresence(osName, apptitle, largeImageKey, string.Empty, string.Empty, string.Empty, new DiscordRPC.Button[] { new DiscordRPC.Button { Label = "Chat on WhatsApp", Url = $"whatsapp://send?phone={Settings.Default.whatsapp_phone.ToString().Replace(" ", string.Empty)}" } }));
                        presenceSet = true;
                    }

                    if (apptitle.Equals("Instagram") && Settings.Default.instagram_button)
                    {
                        client.SetPresence(CreateRichPresence(osName, apptitle, largeImageKey, string.Empty, string.Empty, string.Empty, new DiscordRPC.Button[] { new DiscordRPC.Button { Label = "Instagram profile", Url = $"https://www.instagram.com/{Settings.Default.instagram_username.ToString().Replace(" ", string.Empty)}" } }));
                        presenceSet = true;
                    }

                    if (!presenceSet)
                        client.SetPresence(CreateRichPresence(osName, apptitle, largeImageKey, string.Empty, string.Empty, string.Empty));
                    presenceSet = true;
                }
                catch
                {
                }
            }


            oldAppTitle = apptitle;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Hide();
        }

        private void hideLink_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void quitLink_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void syncSettingsButton_Click(object sender, EventArgs e)
        {
            SyncSettings();
        }
    }

    class ProcessUtils
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        public static Process GetForgroundWindowProcess()
        {
            uint processID = 0;
            IntPtr hWnd = GetForegroundWindow(); // Get foreground window handle
            uint threadID = GetWindowThreadProcessId(hWnd, out processID); // Get PID from window handle
            Process fgProc = Process.GetProcessById(Convert.ToInt32(processID)); // Get it as a C# obj.
            // NOTE: In some rare cases ProcessID will be NULL. Handle this how you want. 
            return fgProc;
        }
    }

    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string input) =>
            input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
            };
    }
}