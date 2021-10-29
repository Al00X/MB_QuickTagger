using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static MusicBeePlugin.Plugin;

namespace MusicBeePlugin
{
    public struct TagTableModel
    {
        public int code;
        public string value;
    }
    public partial class ConfigurationForm : PluginForm
    {
        Action<TagTableModel[]> _onSaveFn;
        public ConfigurationForm(Action<TagTableModel[]> onSaveFn)
        {
            _onSaveFn = onSaveFn;
            InitializeComponent();
            InitializeStyle();
        }
        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            aboytLbl.Text = $"QuickTagger by Al00X - v{Info.VersionMajor}.{Info.VersionMinor}.{Info.Revision}";

            tableTagField.Items.AddRange(TagFields);
            tableTagField.DisplayMember = "name";
            tableTagField.ValueMember = "code";
            foreach(var tag in PluginSettings.Settings.Tags)
            {
                tagTable.Rows.Add(new object[] { (int)tag.Key, tag.Value });
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            _onSaveFn.Invoke((from DataGridViewRow row in tagTable.Rows
                              select new TagTableModel
                              {
                                  code = row.Cells[0].Value != null ? Convert.ToInt32(row.Cells[0].Value) : -1,
                                  value = row.Cells[1].Value?.ToString(),
                              }).ToArray());
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableAddBtn_Click(object sender, EventArgs e)
        {
            tagTable.Rows.Add();
        }

        private void tableRemoveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                tagTable.Rows.RemoveAt(tagTable.SelectedRows[0].Index);
            }
            catch { }
        }
    }
}
