using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using static MusicBeePlugin.Plugin;

namespace MusicBeePlugin
{
    public class PluginForm: Form
    {
        public void InitializeStyle()
        {
            var font = Api.Setting_GetDefaultFont();
            this.Font = font;
            foreach(Control control in this.Controls)
            {
                var isFontBold = control.Font.Bold;
                control.Font = new Font(font, isFontBold ? FontStyle.Bold : FontStyle.Regular);
            }
        }
    }
}
