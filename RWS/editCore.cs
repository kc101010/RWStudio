using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
        EDIT: CORE PAGE - Rusted Warfare Studio
        - Designed by kc101010
 
 */

namespace RWS
{
    public partial class editCore : Form
    {
        public editCore()
        {
            InitializeComponent();

            //Certain options are disabled as they will not always be used
            group_BuildingOptions.Enabled = false;
            group_construction.Enabled = false;

            check_death_nukeOnDeath_DisableWhenNoNuke.Enabled = false;
            num_death_nukeOnDeath_Damage.Enabled = false;
            num_death_nukeOnDeath_Range.Enabled = false;
        }

        private void check_Experimental_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        
        //Method manages enabling of Building section
        private void check_Building_CheckedChanged(object sender, EventArgs e)
        {
            group_BuildingOptions.Enabled = check_Building.Checked;
        }

        //Method manages enabling of Construction/Builder section
        private void check_isBuilder_CheckedChanged(object sender, EventArgs e)
        {
            group_construction.Enabled = check_isBuilder.Checked;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Method manages enabling of nuke-related options in 'Death'
        private void check_death_nukeOnDeath_CheckedChanged(object sender, EventArgs e)
        {
            check_death_nukeOnDeath_DisableWhenNoNuke.Enabled = check_death_nukeOnDeath.Checked;
            num_death_nukeOnDeath_Damage.Enabled = check_death_nukeOnDeath.Checked;
            num_death_nukeOnDeath_Range.Enabled = check_death_nukeOnDeath.Checked;
        }
    }
}
