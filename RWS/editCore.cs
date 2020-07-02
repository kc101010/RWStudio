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
    public partial class editCore : Form
    {
        public editCore()
        {
            InitializeComponent();
            group_BuildingOptions.Enabled = false;
            group_construction.Enabled = false;
        }

        private void check_Experimental_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        

        private void check_Building_CheckedChanged(object sender, EventArgs e)
        {
            group_BuildingOptions.Enabled = check_Building.Checked;
        }

        private void check_isBuilder_CheckedChanged(object sender, EventArgs e)
        {
            group_construction.Enabled = check_isBuilder.Checked;
        }
    }
}
