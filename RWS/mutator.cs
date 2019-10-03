using IniParser.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RWS
{
    public partial class mutator : Form
    {
        public mutator()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] sss = Directory.GetFiles(editUnit.path, "*.ini");
            var parser = new IniParser.FileIniDataParser();
            IniData data = parser.ReadFile(sss[0]);
            writeFromTextbox(uwt, "projectile_" + addprojectile.projectile, "mutator" + nam.Value + "_ifUnitWithTags", data);
            writeFromTextbox(uwtot, "projectile_" + addprojectile.projectile, "mutator" + nam.Value + "_ifUnitWithoutTags", data);
            writeFromTextbox(ad, "projectile_" + addprojectile.projectile, "mutator" + nam.Value + "_areaDamageMultiplier", data);
            writeFromTextbox(dd, "projectile_" + addprojectile.projectile, "mutator" + nam.Value + "_directDamageMultiplier", data);
            parser.WriteFile(sss[0], data);
            Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void writeFromTextbox(TextBox txt, string section, string param, IniData data)
        {
            if (txt.Text != null && txt.Text != "" && txt.Text != " " && txt.Enabled)
            {
                data[section][param] = txt.Text;
            }
        }
    }
}
