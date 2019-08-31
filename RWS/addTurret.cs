using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RWS
{
    public partial class addTurret : Form
    {
        public addTurret()
        {
            InitializeComponent();
            load();
            loadList();
        }
        private void load()
        {
            string[] sss = Directory.GetFiles(editUnit.path, "*.ini");
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(sss[0]);
            if (editUnit.lastt != null)
            {              
                name.Text = editUnit.lastt;
                name.Enabled = false;
                x.Text = data["turret_" + editUnit.lastt]["x"];
                y.Text = data["turret_" + editUnit.lastt]["y"];
                bx.Text = data["turret_" + editUnit.lastt]["barrelX"];
                size.Text = data["turret_" + editUnit.lastt]["size"];
                    by.Text = data["turret_" + editUnit.lastt]["barrelY"];
                bh.Text = data["turret_" + editUnit.lastt]["barrelHeight"];
                image.Text = data["turret_" + editUnit.lastt]["image"];
                turnSpeed.Text = data["turret_" + editUnit.lastt]["turnSpeed"];
                tas.Text = data["turret_" + editUnit.lastt]["turnSpeedAcceleration"];
                tds.Text = data["turret_" + editUnit.lastt]["turnSpeedDeceleration"];
                idledir.Text = data["turret_" + editUnit.lastt]["idleDir"];
                idr.Text = data["turret_" + editUnit.lastt]["idleDirReversing"];
                tlist.Text = data["turret_" + editUnit.lastt]["attachedTo"];
                proj.Text = data["turret_" + editUnit.lastt]["projectile"];
                animonshoot.Text = data["turret_" + editUnit.lastt]["onShoot_playAnimation"];
                eusage.Text = data["turret_" + editUnit.lastt]["energyUsage"];
                shootdelay.Text = data["turret_" + editUnit.lastt]["delay"];
                delay2.Text = data["turret_" + editUnit.lastt]["warmup"];
                cac.Text = data["turret_" + editUnit.lastt]["canAttackCondition"];
                image1.Text = data["turret_" + editUnit.lastt]["chargeEffectImage"];
                maxrange.Text = data["turret_" + editUnit.lastt]["limitingRange"];
                maxangle.Text = data["turret_" + editUnit.lastt]["limitingAngle"];
                mirange.Text = data["turret_" + editUnit.lastt]["limitingMinRange"];
                shootlight.Text = data["turret_" + editUnit.lastt]["shoot_light"];
                shootflame.Text = data["turret_" + editUnit.lastt]["shoot_flame"];
                if (data["turret_" + editUnit.lastt]["shouldResetTurret"] !=null)
                {
                    resetturret.Checked = Convert.ToBoolean(data["turret_" + editUnit.lastt]["shouldResetTurret"]);
                }
                else
                {
                    resetturret.Checked = true;
                }
                if (data["turret_" + editUnit.lastt]["isMainNanoTurret"] != null)
                {
                    nano.Checked = Convert.ToBoolean(data["turret_" + editUnit.lastt]["isMainNanoTurret"]);
                }
                if (data["turret_" + editUnit.lastt]["slave"] != null)
                {
                    slave.Checked = Convert.ToBoolean(data["turret_" + editUnit.lastt]["slave"]);
                }
                freeze.Text = data["turret_" + editUnit.lastt]["onShoot_freezeBodyMovementFor"];
                invisible.Checked = Convert.ToBoolean(data["turret_" + editUnit.lastt]["invisible"]);
                if (data["turret_" + editUnit.lastt]["canShoot"] != null)
                    canattack.Checked = Convert.ToBoolean(data["turret_" + editUnit.lastt]["canShoot"]);
                else
                    canattack.Checked = true;
                air.Checked = Convert.ToBoolean(data["turret_" + editUnit.lastt]["canAttackFlyingUnits"]); 
                land.Checked = Convert.ToBoolean(data["turret_" + editUnit.lastt]["canAttackLandUnits"]);
                uwater.Checked = Convert.ToBoolean(data["turret_" + editUnit.lastt]["canAttackUnderwaterUnits"]);
                showcircle.Checked = Convert.ToBoolean(data["turret_" + editUnit.lastt]["showRangeUIGuide"]);
                if (data["turret_" + editUnit.lastt]["canAttackNotTouchingWaterUnits"] != null)
                {
                    resetturret.Checked = !Convert.ToBoolean(data["turret_" + editUnit.lastt]["canAttackNotTouchingWaterUnits"]);
                }
                else
                {
                    resetturret.Checked = false;
                }
            }
            else
            {
                name.Enabled = true;
            }
            button1.BackColor = ColorTranslator.FromHtml(shootlight.Text);
            if(data["turret_" + editUnit.lastt]["laserDefenceEnergyUse"] != null)
            {
                laserdefenece.Checked = true;
                laserdefen.Text = data["turret_" + editUnit.lastt]["laserDefenceEnergyUse"];
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string[] sss = Directory.GetFiles(editUnit.path, "*.ini");
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(sss[0]);
            if (editUnit.lastt != null) ;
            else
            {
                editUnit.lastt = name.Text;
            }
            data["turret_" + editUnit.lastt]["canAttackNotTouchingWaterUnits"] = Convert.ToString(!resetturret.Checked);
            writeFromTextbox(x, "x", data);
            writeFromTextbox(y, "y", data);
            writeFromTextbox(bx, "barrelX", data);
            writeFromTextbox(by, "barrelY", data);
            writeFromTextbox(bh, "barrelHeight", data);
            writeFromTextbox(size, "size", data);
            writeFromTextbox(turnSpeed, "turnSpeed", data);
            writeFromTextbox(tas, "turnSpeedAcceleration", data);
            writeFromTextbox(tds, "turnSpeedDeceleration", data);
            writeFromTextbox(idledir, "idleDir", data);
            writeFromTextbox(idr, "idleDirReversing", data);
            writeFromTextbox(idr, "idleDirReversing", data);
            writeFromTextbox(eusage, "energyUsage", data);
            writeFromTextbox(shootdelay, "delay", data);
            writeFromTextbox(delay2, "warmup", data);
            writeFromTextbox(cac, "canAttackCondition", data);
            writeFromTextbox(maxangle, "limitingAngle", data);
            writeFromTextbox(maxrange, "limitingRange", data);
            writeFromTextbox(mirange, "limitingMinRange", data);
            writeFromTextbox(shootlight, "shoot_light", data);
            writeFromTextbox(shootflame, "shoot_flame", data);
            writeFromTextbox(freeze, "onShoot_freezeBodyMovementFor", data);
            writeFromTextbox(laserdefen, "laserDefenceEnergyUse", data);
            data["turret_" + editUnit.lastt]["shouldResetTurret"] = resetturret.Checked.ToString();
            writeFromCombotbox(image, "image", data);
            writeFromCombotbox(image1, "chargeEffectImage", data);
            writeFromCombotbox(proj, "projectile", data);
            writeFromCombotbox(tlist, "attachedTo", data);
            writeFromCombotbox(animonshoot, "onShoot_playAnimation", data);
             data["turret_" + editUnit.lastt]["invisible"]=invisible.Checked.ToString();
             data["turret_" + editUnit.lastt]["canShoot"] = canattack.Checked.ToString();
             data["turret_" + editUnit.lastt]["canAttackFlyingUnits"] = air.Checked.ToString();
             data["turret_" + editUnit.lastt]["canAttackLandUnits"] = land.Checked.ToString();
             data["turret_" + editUnit.lastt]["canAttackUnderwaterUnits"] = uwater.Checked.ToString();
             data["turret_" + editUnit.lastt]["showRangeUIGuide"] = showcircle.Checked.ToString();
             data["turret_" + editUnit.lastt]["slave"] = slave.Checked.ToString();
             data["turret_" + editUnit.lastt]["isMainNanoTurret"] = nano.Checked.ToString();
            parser.WriteFile(sss[0], data);
            editUnit.lastt = null;
            Close();
        }
        private void loadList()
        {
            string[] sss = Directory.GetFiles(editUnit.path, "*.ini");
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(sss[0]);
            string[] strings = data.ToString().Split(new[] { '\r', '\n' });
            foreach (string s in strings)
            {
                if (s.Contains("#")) ;
                else
                {
                    if (s.Contains("[projectile_") && s.Contains("]"))
                    {
                        string[] str;
                        str = s.Split(new char[] { '_', ']' });
                        proj.Items.Add(str[1]); 
                    }
                    if (s.Contains("[turret_") && s.Contains("]"))
                    {
                        string[] str;
                        str = s.Split(new char[] { '_', ']' });
                        tlist.Items.Add(str[1]);
                    }
                    if (s.Contains("[animation_") && s.Contains("]"))
                    {
                        string[] str;
                        str = s.Split(new char[] { '_', ']' });
                        animonshoot.Items.Add(str[1]);
                    }
                }
            }
            string[] sss2 = Directory.GetFiles(editUnit.path, "*.png");
            for (int i = 0; i < sss2.Length; i++)
            {
                image.Items.Add(new DirectoryInfo(sss2[i]).Name);
                image1.Items.Add(new DirectoryInfo(sss2[i]).Name);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            button1.BackColor = colorDialog1.Color;
            shootlight.Text = HexConverter(colorDialog1.Color);
        }

        private void addTurret_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            editUnit.lastt = null;
            Close();
        }
        private static String HexConverter(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
        private void writeFromTextbox(TextBox txt, string param, IniData data)
        {
            if (txt.Text != null && txt.Text != "" && txt.Text != " " && txt.Enabled)
            {
                data["turret_" + editUnit.lastt][param] = txt.Text;
            }
        }
        private void writeFromCombotbox(ComboBox txt, string param, IniData data)
        {
            if (txt.Text != null && txt.Text != "" && txt.Text != " " && txt.Enabled)
            {
                data["turret_" + editUnit.lastt][param] = txt.Text;
            }
        }
        private void size_TextChanged(object sender, EventArgs e)
        {
            if(size.Text != "")
               by.Enabled = false;
            else
                by.Enabled = true;
        }
        private void by_TextChanged(object sender, EventArgs e)
        {
            if (by.Text != "")
            {
                size.Enabled = false;
            }
            else
            {
                size.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (laserdefenece.Checked)
            {
                canattack.Checked = false;
                laserdefen.Enabled = true;
            }
            else
                laserdefen.Enabled = false;
        }
    }
}
