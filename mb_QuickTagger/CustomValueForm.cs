using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MusicBeePlugin
{
    public partial class CustomValueForm : PluginForm
    {
        Action<string> _saveFn;
        public CustomValueForm(string initialValue, string tagName, Action<string> saveFn)
        {
            _saveFn = saveFn;
            InitializeComponent();
            InitializeStyle();
            textBox1.Text = initialValue;
            label1.Text = $"Set tag value for <{tagName}>:";
        }

        private void CustomValueForm_Load(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            _saveFn.Invoke(textBox1.Text);
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                saveBtn_Click(null, null);
            }
        }
    }
}
