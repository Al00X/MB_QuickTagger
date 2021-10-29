using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using static MusicBeePlugin.Plugin;
using SerializeDictionary;

namespace MusicBeePlugin
{
    public class SettingsModel
    {
        public SettingsModel()
        {
            Tags = new SerializableDictionary<MetaDataType, string>();
        }

        public SerializableDictionary<MetaDataType, string> Tags { get; set; }

    }
    public static class PluginSettings
    {
        private const string CONFIG_FILE_PATH_RAW = "mb_QuickTagger.config";

        public static SettingsModel Settings = new SettingsModel();

        public static void SaveSettings()
        {
            Write<SettingsModel>(ConfigPath);
        }
        public static void LoadSettings()
        {
            Settings = Read<SettingsModel>(ConfigPath);
        }

        public static void PurgeEverything()
        {
            try
            {
                File.Delete(ConfigPath);
            }
            catch { }
        }

        private static void Write<T>(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(T));
                xmls.Serialize(sw, Settings);
            }
        }
        private static T Read<T>(string filename)
        {
            if (!File.Exists(filename))
            {
                Write<T>(filename);
            }
            using (StreamReader sw = new StreamReader(filename))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(T));
                return (T)xmls.Deserialize(sw);
            }
        }

        private static string ConfigPath
        {
            get { return Path.Combine(Api.Setting_GetPersistentStoragePath(), CONFIG_FILE_PATH_RAW); }
        }
    }

}
