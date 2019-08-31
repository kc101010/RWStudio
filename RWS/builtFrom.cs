using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RWS
{
    public partial class builtFrom : Form
    {
        public builtFrom()
        {
            InitializeComponent();
        }

        private void builtFrom_Load(object sender, EventArgs e)
        {
            label1.Text = "Unit: " + editUnit.namE + ",can be builded in:";

        }
    }
}
