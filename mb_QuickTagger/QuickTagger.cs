using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using static MusicBeePlugin.Plugin;
using System.IO;
using System.Linq;

namespace MusicBeePlugin
{
    public partial class QuickTagger
    {
        public QuickTagger()
        {
            PluginSettings.LoadSettings();
        }

        public void ShowConfiguration(Action afterCloseFn = null)
        {
            ConfigurationForm configForm = new ConfigurationForm(tags =>
            {
                PluginSettings.Settings.Tags.Clear();
                foreach (var tag in tags) {
                    if (tag.value == "" || tag.value == null || tag.code == -1)
                    {
                        continue;
                    }
                    PluginSettings.Settings.Tags.Add((MetaDataType)tag.code, string.Join("; ",tag.value.Split(';').Select(x => x.Trim()).Where(x => x != "")));
                }
                PluginSettings.SaveSettings();
            });
            configForm.ShowDialog();
            afterCloseFn?.Invoke();
            Api.MB_RefreshPanels();
        }

        public void SetTag_handle(MetaDataType tag, string value)
        {
            QueryMusics(musics =>
            {
                foreach (var music in musics)
                {
                    ChangeFileTag(music, tag, value);
                }
                Api.MB_RefreshPanels();
            });
        }

        public void SetTagCustom_handle(MetaDataType tag)
        {
            QueryMusics(musics =>
            {
                var tagName = GetTagName(tag);
                CustomValueForm valueForm = new CustomValueForm(musics.Length == 1 ? Api.Library_GetFileTag(musics[0], tag) : "", tagName, value =>
                {
                    foreach (var music in musics)
                    {
                        ChangeFileTag(music, tag, value);
                    }
                    Api.MB_RefreshPanels();
                });
                valueForm.ShowDialog();
            });
        }

        private void ChangeFileTag(string fileUrl, MetaDataType tag, string value)
        {
            Api.Library_SetFileTag(fileUrl, tag, value.Trim());
            Api.Library_CommitTagsToFile(fileUrl);
        }
        
        private string[] GetSelectedMusics()
        {
            string[] selectedMusics = null;
            Api.Library_QueryFilesEx("domain=SelectedFiles", out selectedMusics);
            var playingMusic = Api.NowPlaying_GetFileUrl();
            return selectedMusics == null ? playingMusic != null ? new string[] { playingMusic } : new string[] { } : selectedMusics;
        }

        private void QueryMusics(Action<string[]> processFn)
        {
            var musics = GetSelectedMusics();
            if (musics.Length == 0)
            {
                return;
            }
            if (musics.Length > 1)
            {
                var promptResult = MessageBox.Show("Are you sure you want to change tag of " + musics.Length + " musics?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (promptResult != DialogResult.Yes)
                {
                    return;
                }
            }
            processFn.Invoke(musics);
        }
    }
}