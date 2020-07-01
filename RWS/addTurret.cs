using IniParser;
using IniParser.Model;
using System;
using System.Drawing;
using System.IO;
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
            string[] sss = Directory.GetFiles(New_edit.path, "*.ini");
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(sss[0]);
            if (New_edit.lastt != null)
            {              
                name.Text = New_edit.lastt;
                name.Enabled = false;
                x.Text = data["turret_" + New_edit.lastt]["x"];
                y.Text = data["turret_" + New_edit.lastt]["y"];
                bx.Text = data["turret_" + New_edit.lastt]["barrelX"];
                size.Text = data["turret_" + New_edit.lastt]["size"];
                    by.Text = data["turret_" + New_edit.lastt]["barrelY"];
                bh.Text = data["turret_" + New_edit.lastt]["barrelHeight"];
                image.Text = data["turret_" + New_edit.lastt]["image"];
                turnSpeed.Text = data["turret_" + New_edit.lastt]["turnSpeed"];
                tas.Text = data["turret_" + New_edit.lastt]["turnSpeedAcceleration"];
                tds.Text = data["turret_" + New_edit.lastt]["turnSpeedDeceleration"];
                idledir.Text = data["turret_" + New_edit.lastt]["idleDir"];
                idr.Text = data["turret_" + New_edit.lastt]["idleDirReversing"];
                tlist.Text = data["turret_" + New_edit.lastt]["attachedTo"];
                proj.Text = data["turret_" + New_edit.lastt]["projectile"];
                animonshoot.Text = data["turret_" + New_edit.lastt]["onShoot_playAnimation"];
                eusage.Text = data["turret_" + New_edit.lastt]["energyUsage"];
                shootdelay.Text = data["turret_" + New_edit.lastt]["delay"];
                delay2.Text = data["turret_" + New_edit.lastt]["warmup"];
                cac.Text = data["turret_" + New_edit.lastt]["canAttackCondition"];
                image1.Text = data["turret_" + New_edit.lastt]["chargeEffectImage"];
                maxrange.Text = data["turret_" + New_edit.lastt]["limitingRange"];
                maxangle.Text = data["turret_" + New_edit.lastt]["limitingAngle"];
                mirange.Text = data["turret_" + New_edit.lastt]["limitingMinRange"];
                shootlight.Text = data["turret_" + New_edit.lastt]["shoot_light"];
                shootflame.Text = data["turret_" + New_edit.lastt]["shoot_flame"];
                shootsound.Text = data["turret_" + New_edit.lastt]["shoot_sound"];
                if (data["turret_" + New_edit.lastt]["shouldResetTurret"] !=null)
                {
                    resetturret.Checked = Convert.ToBoolean(data["turret_" + New_edit.lastt]["shouldResetTurret"]);
                }
                else
                {
                    resetturret.Checked = true;
                }
                if (data["turret_" + New_edit.lastt]["isMainNanoTurret"] != null)
                {
                    nano.Checked = Convert.ToBoolean(data["turret_" + New_edit.lastt]["isMainNanoTurret"]);
                }
                if (data["turret_" + New_edit.lastt]["slave"] != null)
                {
                    slave.Checked = Convert.ToBoolean(data["turret_" + New_edit.lastt]["slave"]);
                }
                freeze.Text = data["turret_" + New_edit.lastt]["onShoot_freezeBodyMovementFor"];
                invisible.Checked = Convert.ToBoolean(data["turret_" + New_edit.lastt]["invisible"]);
                if (data["turret_" + New_edit.lastt]["canShoot"] != null)
                    canattack.Checked = Convert.ToBoolean(data["turret_" + New_edit.lastt]["canShoot"]);
                else
                    canattack.Checked = true;
                air.Checked = Convert.ToBoolean(data["turret_" + New_edit.lastt]["canAttackFlyingUnits"]); 
                land.Checked = Convert.ToBoolean(data["turret_" + New_edit.lastt]["canAttackLandUnits"]);
                uwater.Checked = Convert.ToBoolean(data["turret_" + New_edit.lastt]["canAttackUnderwaterUnits"]);
                showcircle.Checked = Convert.ToBoolean(data["turret_" + New_edit.lastt]["showRangeUIGuide"]);
                if (data["turret_" + New_edit.lastt]["canAttackNotTouchingWaterUnits"] != null)
                {
                    resetturret.Checked = !Convert.ToBoolean(data["turret_" + New_edit.lastt]["canAttackNotTouchingWaterUnits"]);
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
            if(data["turret_" + New_edit.lastt]["laserDefenceEnergyUse"] != null)
            {
                laserdefenece.Checked = true;
                laserdefen.Text = data["turret_" + New_edit.lastt]["laserDefenceEnergyUse"];
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string[] sss = Directory.GetFiles(New_edit.path, "*.ini");
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(sss[0]);
            if (New_edit.lastt != null) ;
            else
            {
                New_edit.lastt = name.Text;
            }
            data["turret_" + New_edit.lastt]["canAttackNotTouchingWaterUnits"] = Convert.ToString(!resetturret.Checked);
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
            writeFromCombotbox(shootflame, "shoot_flame", data);
            writeFromCombotbox(shootsound, "shoot_sound", data);
            writeFromTextbox(freeze, "onShoot_freezeBodyMovementFor", data);
            writeFromTextbox(laserdefen, "laserDefenceEnergyUse", data);
            data["turret_" + New_edit.lastt]["shouldResetTurret"] = resetturret.Checked.ToString();
            writeFromCombotbox(image, "image", data);
            writeFromCombotbox(image1, "chargeEffectImage", data);
            writeFromCombotbox(proj, "projectile", data);
            writeFromCombotbox(tlist, "attachedTo", data);
            writeFromCombotbox(animonshoot, "onShoot_playAnimation", data);
             data["turret_" + New_edit.lastt]["invisible"]=invisible.Checked.ToString();
             data["turret_" + New_edit.lastt]["canShoot"] = canattack.Checked.ToString();
             data["turret_" + New_edit.lastt]["canAttackFlyingUnits"] = air.Checked.ToString();
             data["turret_" + New_edit.lastt]["canAttackLandUnits"] = land.Checked.ToString();
             data["turret_" + New_edit.lastt]["canAttackUnderwaterUnits"] = uwater.Checked.ToString();
             data["turret_" + New_edit.lastt]["showRangeUIGuide"] = showcircle.Checked.ToString();
             data["turret_" + New_edit.lastt]["slave"] = slave.Checked.ToString();
             data["turret_" + New_edit.lastt]["isMainNanoTurret"] = nano.Checked.ToString();
            parser.WriteFile(sss[0], data);
            New_edit.lastt = null;
            Close();
        }
        private void loadList()
        {
            string[] sss = Directory.GetFiles(New_edit.path, "*.ini");
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
                        if (str[1] != New_edit.lastt)
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
            string[] sss2 = Directory.GetFiles(New_edit.path, "*.png");
            for (int i = 0; i < sss2.Length; i++)
            {
                image.Items.Add(new DirectoryInfo(sss2[i]).Name);
                image1.Items.Add(new DirectoryInfo(sss2[i]).Name);
            }
          string[] sss3 = Directory.GetFiles(New_edit.path, "*.wav");
            for (int i = 0; i < sss3.Length; i++)
            {
                shootsound.Items.Add(new DirectoryInfo(sss3[i]).Name);
            }
            sss3 = null;
            sss3 = Directory.GetFiles(New_edit.path, "*.ogg");
            for (int i = 0; i < sss3.Length; i++)
            {
                shootsound.Items.Add(new DirectoryInfo(sss3[i]).Name);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            button1.BackColor = colorDialog1.Color;
            shootlight.Text = HexConverter(colorDialog1.Color);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            New_edit.lastt = null;
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
                data["turret_" + New_edit.lastt][param] = txt.Text;
            }
            else if (data["turret_" + New_edit.lastt][param] != null)
            {
                data["turret_" + New_edit.lastt].RemoveKey(param);
            }
        }
        private void writeFromCombotbox(ComboBox txt, string param, IniData data)
        {
            if (txt.Text != null && txt.Text != "" && txt.Text != " " && txt.Enabled)
            {
                data["turret_" + New_edit.lastt][param] = txt.Text;
            }
            else if (data["turret_" + New_edit.lastt][param] != null)
            {
                data["turret_" + New_edit.lastt].RemoveKey(param);
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
