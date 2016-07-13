using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetScaledImageAsString
{
    public partial class TextForm : Form
    {
        public TextForm(string text)
        {
            InitializeComponent();
            this.txb.Text = text;
        }
    }
}
