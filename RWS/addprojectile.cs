using IniParser;
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
    public partial class addprojectile : Form
    {
        public addprojectile()
        {
            InitializeComponent();
        }

        private void ballistic_CheckedChanged(object sender, EventArgs e)
        {
            if (ballistic.Checked)
            {
                groupBox4.Enabled = true;
            }
            else
            {
                groupBox4.Enabled = false;
            }
        }

        private void addprojectile_Load(object sender, EventArgs e)
        {
            if (editUnit.lastprj != null)
            {
                string[] sss = Directory.GetFiles(editUnit.path, "*.ini");
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(sss[0]);
                name.Enabled = false;
                name.Text = editUnit.lastprj;

                life.Text = data["projectile_" + editUnit.lastprj]["life"];
                defpower.Text = data["projectile_" + editUnit.lastprj]["deflectionPower"];
                explodeOnEndOflife.Checked = Convert.ToBoolean(data["projectile_" + editUnit.lastprj]["explodeOnEndOfLife"]);
                retarget.Checked = Convert.ToBoolean(data["projectile_" + editUnit.lastprj]["autoTargetingOnDeadTarget"]);
                teleportSource.Checked = Convert.ToBoolean(data["projectile_" + editUnit.lastprj]["teleportSource"]);
                spawnUnit.Text = data["projectile_" + editUnit.lastprj]["spawnUnit"];
                tags.Text = data["projectile_" + editUnit.lastprj]["tags"];
                fwaepon.Checked = Convert.ToBoolean(data["projectile_" + editUnit.lastprj]["flameWeapon"]);
                ddamage.Text = data["projectile_" + editUnit.lastprj]["directDamage"];
                areadamage.Text = data["projectile_" + editUnit.lastprj]["areaDamage"];
                areaRadius.Text = data["projectile_" + editUnit.lastprj]["areaRadius"];
                hituwater.Checked = Convert.ToBoolean(data["projectile_" + editUnit.lastprj]["areaHitUnderwaterAlways"]);
                airandground.Checked = Convert.ToBoolean(data["projectile_" + editUnit.lastprj]["areaHitAirAndLandAtSameTime"]);
                bdm.Text = data["projectile_" + editUnit.lastprj]["buildingDamageMultiplier"];
                sdm.Text = data["projectile_" + editUnit.lastprj]["shieldDamageMultiplier"];
                shielddefection.Text = data["projectile_" + editUnit.lastprj]["shieldDefectionMultiplier"];
                friendlyFire.Checked = Convert.ToBoolean(data["projectile_" + editUnit.lastprj]["friendlyFire"]);
                targetground.Checked = Convert.ToBoolean(data["projectile_" + editUnit.lastprj]["targetGround"]);
                speed.Text = data["projectile_" + editUnit.lastprj]["speed"];
                targetspwwd.Text = data["projectile_" + editUnit.lastprj]["targetSpeed"];
                acceleration.Text =  data["projectile_" + editUnit.lastprj]["targetSpeedAcceleration"];
                ballistic.Checked = Convert.ToBoolean(data["projectile_" + editUnit.lastprj]["ballistic"]);
                dmH.Text = data["projectile_" + editUnit.lastprj]["ballistic_delaymove_height"];
                ballheigh.Text = data["projectile_" + editUnit.lastprj]["ballistic_height"];
                instant.Checked = Convert.ToBoolean(data["projectile_" + editUnit.lastprj]["instant"]);
                disableLeadTargeting.Checked = Convert.ToBoolean(data["projectile_" + editUnit.lastprj]["disableLeadTargeting"]);
                gravity.Text = data["projectile_" + editUnit.lastprj]["gravity"];
                color.Text = data["projectile_" + editUnit.lastprj]["color"];
                invisible.Checked = Convert.ToBoolean(data["projectile_" + editUnit.lastprj]["invisible"]);
                image.Text = data["projectile_" + editUnit.lastprj]["image"];
                drawType.Text = data["projectile_" + editUnit.lastprj]["drawType"];
                if (data["projectile_" + editUnit.lastprj]["hitSound"] != null)
                    hitsound.Checked = Convert.ToBoolean(data["projectile_" + editUnit.lastprj]["hitSound"]);
                else
                    hitsound.Checked = true;
                explodeeff.Text = data["projectile_" + editUnit.lastprj]["explodeEffect"];
                explodeonshieldeff.Text = data["projectile_" + editUnit.lastprj]["explodeEffectOnShield"];
                createEffect.Text = data["projectile_" + editUnit.lastprj]["effectOnCreate"];
                revalFogonExplode.Checked = Convert.ToBoolean(data["projectile_" + editUnit.lastprj]["shouldRevealFog"]);
                visibleinfog.Checked = Convert.ToBoolean(data["projectile_" + editUnit.lastprj]["alwaysVisibleInFog"]);
                nukeWeapon.Checked = Convert.ToBoolean(data["projectile_" + editUnit.lastprj]["nukeWeapon"]);
                lighsize.Text = data["projectile_" + editUnit.lastprj]["lightSize"];
                lighColor.Text = data["projectile_" + editUnit.lastprj]["lightColor"];
                lasereffect.Checked = Convert.ToBoolean(data["projectile_" + editUnit.lastprj]["laserEffect"]);
                lightingEffect.Checked = Convert.ToBoolean(data["projectile_" + editUnit.lastprj]["lightingEffect"]);
                button1.BackColor = ColorTranslator.FromHtml(color.Text);
                button2.BackColor = ColorTranslator.FromHtml(lighColor.Text);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            editUnit.lastprj = name.Text;
            string[] sss = Directory.GetFiles(editUnit.path, "*.ini");
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(sss[0]);
            writeFromTextbox(life, "projectile_" + editUnit.lastprj, "life", data);
              writeFromTextbox(defpower, "projectile_" + editUnit.lastprj, "deflectionPower", data);
              data["projectile_" + editUnit.lastprj]["explodeOnEndOfLife"] = explodeOnEndOflife.Checked.ToString();
              data["projectile_" + editUnit.lastprj]["autoTargetingOnDeadTarget"] = retarget.Checked.ToString();
              data["projectile_" + editUnit.lastprj]["teleportSource"]= teleportSource.Checked.ToString();
              writeFromTextbox(spawnUnit, "projectile_" + editUnit.lastprj, "spawnUnit", data);
              writeFromTextbox(tags, "projectile_" + editUnit.lastprj, "tags", data);
              data["projectile_" + editUnit.lastprj]["flameWeapon"] = fwaepon.Checked.ToString();
              writeFromTextbox(ddamage, "projectile_" + editUnit.lastprj, "directDamage", data);
              writeFromTextbox(areadamage, "projectile_" + editUnit.lastprj, "areaDamage", data);
              writeFromTextbox(areaRadius, "projectile_" + editUnit.lastprj, "areaRadius", data);
              data["projectile_" + editUnit.lastprj]["areaHitUnderwaterAlways"] = hituwater.Checked.ToString();
              data["projectile_" + editUnit.lastprj]["areaHitAirAndLandAtSameTime"] = airandground.Checked.ToString();
              writeFromTextbox(bdm, "projectile_" + editUnit.lastprj, "buildingDamageMultiplier", data);
              writeFromTextbox(sdm, "projectile_" + editUnit.lastprj, "shieldDamageMultiplier", data);
              writeFromTextbox(shielddefection, "projectile_" + editUnit.lastprj, "shieldDefectionMultiplier", data);
            data["projectile_" + editUnit.lastprj]["friendlyFire"] = friendlyFire.Checked.ToString();
            data["projectile_" + editUnit.lastprj]["targetground"] = targetground.Checked.ToString();
            writeFromTextbox(speed, "projectile_" + editUnit.lastprj, "speed", data);
            writeFromTextbox(targetspwwd, "projectile_" + editUnit.lastprj, "targetSpeed", data);
            writeFromTextbox(acceleration, "projectile_" + editUnit.lastprj, "targetSpeedAcceleration", data);
            data["projectile_" + editUnit.lastprj]["ballistic"] = ballistic.Checked.ToString();
            writeFromTextbox(ballheigh, "projectile_" + editUnit.lastprj, "ballistic_height", data);
            writeFromTextbox(dmH, "projectile_" + editUnit.lastprj, "ballistic_delaymove_height", data);
            data["projectile_" + editUnit.lastprj]["instant"] = instant.Checked.ToString();
            writeFromCombotbox(image, "projectile_" + editUnit.lastprj, "image", data);
            writeFromTextbox(drawType, "projectile_" + editUnit.lastprj, "drawType", data);
            data["projectile_" + editUnit.lastprj]["hitSound"] = hitsound.Checked.ToString();
            writeFromTextbox(explodeonshieldeff, "projectile_" + editUnit.lastprj, "explodeEffectOnShield", data);
            writeFromTextbox(createEffect, "projectile_" + editUnit.lastprj, "effectOnCreate", data);
              data["projectile_" + editUnit.lastprj]["shouldRevealFog"] = revalFogonExplode.Checked.ToString();
            data["projectile_" + editUnit.lastprj]["alwaysVisibleInFog"] = visibleinfog.Checked.ToString();
             data["projectile_" + editUnit.lastprj]["nukeWeapon"] = nukeWeapon.Checked.ToString();
             data["projectile_" + editUnit.lastprj]["laserEffect"] = lasereffect.Checked.ToString();
             data["projectile_" + editUnit.lastprj]["lightingEffect"] = lightingEffect.Checked.ToString();
            writeFromTextbox(lighsize, "projectile_" + editUnit.lastprj, "lightSize", data);
            writeFromTextbox(lighColor, "projectile_" + editUnit.lastprj, "lightColor", data);
            writeFromTextbox(gravity, "projectile_" + editUnit.lastprj, "gravity", data);
            writeFromTextbox(color, "projectile_" + editUnit.lastprj, "color", data);
             data["projectile_" + editUnit.lastprj]["invisible"] = invisible.Checked.ToString();
            
            parser.WriteFile(sss[0], data);
            editUnit.lastprj = null;
            Close();
        }

        private void writeFromTextbox(TextBox txt, string section, string param, IniData data)
        {
            if (txt.Text != null && txt.Text != "" && txt.Text != " " && txt.Enabled)
            {
                data[section][param] = txt.Text;
            }
        }
        private void writeFromCombotbox(ComboBox txt, string section, string param, IniData data)
        {
            if (txt.Text != null && txt.Text != "" && txt.Text != " " && txt.Enabled)
            {
                data[section][param] = txt.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            button2.BackColor = colorDialog1.Color;
            lighColor.Text = HexConverter(colorDialog1.Color);
        }
        private static String HexConverter(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            button1.BackColor = colorDialog1.Color;
            color.Text = HexConverter(colorDialog1.Color);
        }

        private void instant_CheckedChanged(object sender, EventArgs e)
        {
            if (instant.Checked)
            {
                targetground.Checked = false;
                targetground.Enabled = false;
            }
            else
            {
                targetground.Enabled = true;
            }
        }

        private void targetground_CheckedChanged(object sender, EventArgs e)
        {
            if (targetground.Checked)
            {
               instant.Checked = false;
               instant.Enabled = false;
            }
            else
            {
                instant.Enabled = true;
            }
        }
    }
}
