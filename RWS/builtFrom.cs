using IniParser;
using IniParser.Model;
using System;
using System.IO;
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
            if (editUnit.lastbf != null)
            {
                bfnum.Enabled = false;
                string[] sss = Directory.GetFiles(editUnit.path, "*.ini");
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(sss[0]);
                bfnum.Value = Convert.ToInt32(editUnit.lastbf.Split(':')[0]);
                name.Text = data["core"]["builtFrom_" + bfnum.Value.ToString() + "_name"];
                pos.Text = data["core"]["builtFrom_" + bfnum.Value.ToString() + "_pos"];
                forceNano.Checked = Convert.ToBoolean(data["core"]["builtFrom_" + bfnum.Value.ToString() + "_forceNano"]);
                islocked.Text = data["core"]["builtFrom_" + bfnum.Value.ToString() + "_isLocked"];
                lockedmess.Text = data["core"]["builtFrom_" + bfnum.Value.ToString() + "_isLockedMessage"];
            }
            else
                bfnum.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] sss = Directory.GetFiles(editUnit.path, "*.ini");
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(sss[0]);
            writeFromTextbox(name, "builtFrom_" + bfnum.Value.ToString() + "_name", data);
            writeFromTextbox(pos, "builtFrom_" + bfnum.Value.ToString() + "_pos", data);
            data["core"]["builtFrom_" + bfnum.Value.ToString() + "_forceNano"] = forceNano.Checked.ToString();
            writeFromCombotbox(islocked, "builtFrom_" + bfnum.Value.ToString() + "_isLocked", data);
            writeFromTextbox(lockedmess, "builtFrom_" + bfnum.Value.ToString() + "_isLockedMessage", data);
            parser.WriteFile(sss[0], data);
            Close();
        }
        private void writeFromTextbox(TextBox txt, string param, IniData data)
        {
            if (txt.Text != null && txt.Text != "" && txt.Text != " " && txt.Enabled)
            {
                data["core"][param] = txt.Text;
            }
        }
        private void writeFromCombotbox(ComboBox txt, string param, IniData data)
        {
            if (txt.Text != null && txt.Text != "" && txt.Text != " " && txt.Enabled)
            {
                data["core"][param] = txt.Text;
            }
        }
    }
}
