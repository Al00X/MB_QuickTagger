using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MusicBeePlugin
{
    public class TagField
    {
        public int code { get; set; }
        public string name { get; set; }
        public Plugin.MetaDataType type { get; set; }
    }
    public partial class Plugin
    {
        private static MusicBeeApiInterface mbApiInterface;
        private static PluginInfo about = new PluginInfo();
        private QuickTagger QuickTagger;
        private static List<TagField> _tagField = new List<TagField>();
        public PluginInfo Initialise(IntPtr apiInterfacePtr)
        {
            mbApiInterface = new MusicBeeApiInterface();
            mbApiInterface.Initialise(apiInterfacePtr);
            about.PluginInfoVersion = PluginInfoVersion;
            about.Name = "Quick Tagger";
            about.Description = "Quickly tag your musics using hotkeys";
            about.Author = "Al00X";
            about.TargetApplication = "";   //  the name of a Plugin Storage device or panel header for a dockable panel
            about.Type = PluginType.Storage;
            about.VersionMajor = 1;  // your plugin version
            about.VersionMinor = 0;
            about.Revision = 1;
            about.MinInterfaceVersion = MinInterfaceVersion;
            about.MinApiRevision = MinApiRevision;
            about.ReceiveNotifications = ReceiveNotificationFlags.StartupOnly | ReceiveNotificationFlags.PlayerEvents | ReceiveNotificationFlags.DataStreamEvents | ReceiveNotificationFlags.DownloadEvents | ReceiveNotificationFlags.TagEvents;
            about.ConfigurationPanelHeight = 0;   // height in pixels that musicbee should reserve in a panel for config settings. When set, a handle to an empty panel will be passed to the Configure function
            QuickTagger = new QuickTagger();
            foreach(int code in Array.ConvertAll((int[])Enum.GetValues(typeof(MetaDataType)), Convert.ToInt32))
            {
                _tagField.Add(new TagField { code = code, name = Api.Setting_GetFieldName((MetaDataType)code), type = (MetaDataType)code });
            }
            return about;
        }

        public static MusicBeeApiInterface Api
        {
            get => mbApiInterface;
        }

        public static PluginInfo Info
        {
            get => about;
        }

        public static TagField[] TagFields {
            get => _tagField.ToArray();
        }

        public static string GetTagName(MetaDataType tag)
        {
            return _tagField.Find(x => x.type == tag).name;
        }

        public void UpdateHotKeys()
        {
            foreach (var tag in PluginSettings.Settings.Tags)
            {
                var tagSplit = tag.Value.Split(';');
                var tagName = GetTagName(tag.Key);
                foreach (var tagValue in tagSplit)
                {
                    if (tagValue.Trim() == "")
                        continue;

                    mbApiInterface.MB_RegisterCommand($"Quick Tagger: Set {tagName} to: {tagValue.Trim()}", (sender, e) => QuickTagger.SetTag_handle(tag.Key, tagValue));
                }
                mbApiInterface.MB_RegisterCommand($"Quick Tagger: Set {tagName} to a custom value", (sender, e) => QuickTagger.SetTagCustom_handle(tag.Key));
            }
        }

        public bool Configure(IntPtr panelHandle)
        {
            QuickTagger.ShowConfiguration();
            return true;
        }

        public void SaveSettings()
        {
            UpdateHotKeys();
            Api.MB_SendNotification(CallbackType.SettingsUpdated);
        }

        public void Close(PluginCloseReason reason)
        {
        }

        public void Uninstall()
        {
            PluginSettings.PurgeEverything();
        }

        public void ReceiveNotification(string sourceFileUrl, NotificationType type)
        {
            switch (type)
            {
                case NotificationType.PluginStartup:
                    UpdateHotKeys();
                    break;
                case NotificationType.EmbedInPanel:
                    MessageBox.Show("HEHEHE!");
                    break;
            }
        }
    }
}