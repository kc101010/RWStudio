using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;

namespace RWS
{
    public partial class editUnit : Form
    {
        public static string path;
        public static string lastcb;
        public static string lastt;
        public static string lastprj;
        public static string namE;
        public static string lastbf;
        public static string lastact;
        public static string lastleg;
        public static string lastanim;

        public editUnit()
        {
            InitializeComponent();
            path = unitList.f;
            namE = name.Text;
        }
        private void button34_Click(object sender, EventArgs e)
        {
            if (customp.Text != "" && customs.Text != "" && customv.Text != "")
            {
                string[] sss = Directory.GetFiles(path, "*.ini");
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(sss[0]);
                data[customs.Text][customp.Text] = customv.Text;
                parser.WriteFile(sss[0], data);
                customs.Text = customp.Text = customv.Text = string.Empty;
            }
            else
                MessageBox.Show("Hmmm...");
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string picture_path;
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse PNG file",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "png",
                Filter = "png files (*.png)|*.png",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picture_path = openFileDialog1.FileName;
                pictureBox1.BackgroundImage = new Bitmap(picture_path);
                File.Copy(picture_path, Path.Combine(path, new DirectoryInfo(picture_path).Name.Replace(" ", string.Empty)));
                string[] sss = Directory.GetFiles(path, "*.ini");
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(sss[0]);
                data["graphics"]["image"] = new DirectoryInfo(picture_path).Name.Replace(" ", string.Empty);
                parser.WriteFile(sss[0], data);
                loadimages();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string picture_path;
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse file",

                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = true,
                DefaultExt = "png",
                Filter = "png files (*.png)|*.png|wav files(*.wav)|*.wav|ogg files(*.ogg)|*.ogg",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string pp in openFileDialog1.FileNames)
                {
                    picture_path = pp;
                    File.Copy(picture_path, Path.Combine(path, new DirectoryInfo(picture_path).Name.Replace(" ", "_")));
                }
            }
            loadimages();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            string[] sss = Directory.GetFiles(path, "*.ini");
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(sss[0]);
           /*
            * core
            */
            writeFromTextbox(name, "core", "displayText", data);
            if (descript.Text != null)
                data["core"]["displayDescription"] = descript.Text.Replace(Environment.NewLine, "\\n");
            writeFromNumeric(hp, "core", "maxHp", data);
            writeFromNumeric(price, "core", "price", data);
            writeFromNumeric(mass, "core", "mass", data);
            writeFromNumeric(mass, "core", "mass", data);
            data["core"]["class"] = "CustomUnitMetadata";
            writeFromTextbox(buildspeed, "core", "buildSpeed", data);
            writeFromNumeric(level, "core", "techLevel", data);
            writeFromTextbox(tags, "core", "tags", data);
            writeFromCheck(lock_body_rotation_with_main_turret, "graphics", "lock_body_rotation_with_main_turret", data);
            /*
             * radius/footprint
             */
            writeFromTextbox(ft, "core", "footprint", data);
            writeFromTextbox(fc, "core", "constructionFootprint", data);
            writeFromNumeric(radius, "core", "radius", data);
            writeFromNumeric(dradius, "core", "displayRadius", data);
           /*
            * nano
            */
            writeFromTextbox(nanoRange, "core", "nanoRange", data);
            writeFromTextbox(nanobs, "core", "nanoBuildSpeed", data);
            writeFromTextbox(nanoFactorySpeed, "core", "nanoFactorySpeed", data);
            writeFromTextbox(nanoRepairSpeed, "core", "nanoRepairSpeed", data);
           /*
            * nuke
            */
            writeFromCheck(nukeOnDeath, "core", "nukeOnDeath", data);
            writeFromTextbox(nukeOnDeathDamage, "core", "nukeOnDeathDamage", data);
            writeFromTextbox(nukeOnDeathRange, "core", "nukeOnDeathRange", data);
            writeFromCheck(noNuke, "core", "nukeOnDeathDisableWhenNoNuke", data);
            writeFromCheck(nonukelocked, "core", "isLockedIfGameModeNoNuke", data);
            /*
             * shield
             */
            writeFromNumeric(shield, "core", "maxShield", data);
            writeFromTextbox(shieldr, "core", "shieldRegen", data);
            writeFromCheck(ssaz, "core", "startShieldAtZero", data);
            writeFromNumeric(armour, "core", "armour", data);
            /*
            * energy
            */
            writeFromTextbox(energy, "core", "energyMax", data);
            writeFromTextbox(energyr, "core", "energyRegen", data);
           /*
            * unit type
            */
            writeFromCheck(isBuilding, "core", "isBuilding", data);
            writeFromCheck(isbuilder, "core", "isBuilder", data);
            writeFromCheck(isexperimental, "core", "experimental", data);
            writeFromCheck(isBio, "core", "isBio", data);
           /*
            * movement
            */
            writeFromCombotbox(movement, "movement", "movementType", data);
            writeFromTextbox(moveSpeed, "movement", "moveSpeed", data);
            writeFromTextbox(accSpeed, "movement", "moveAccelerationSpeed", data);
            writeFromTextbox(dSpeed, "movement", "moveDecelerationSpeed", data);
            writeFromTextbox(turnSpeed, "movement", "maxTurnSpeed", data);
            writeFromTextbox(tas, "movement", "turnAcceleration", data);
            if (targeth.Text != null && targeth.Text != "")
            data["movement"]["targetHeight"] = targeth.Text;

            writeFromTextbox(drift,"movement", "targetHeightDrift", data);
            writeFromCombotbox(landOnGround, "movement", "landOnGround", data);
            /*
             * offsets
             */
            writeFromNumeric(iox, "graphics", "image_offsetX", data);
            writeFromNumeric(ioy, "graphics", "image_offsetY", data);
            writeFromNumeric(sox, "graphics", "shadowOffsetX", data);
            writeFromNumeric(soy, "graphics", "shadowOffsetY", data);
            writeFromTextbox(sit, "graphics", "scaleImagesTo", data);
            /*
             * images
             */
            writeFromNumeric(frames, "graphics", "total_frames", data);
            writeFromCombotbox(deadimage, "graphics", "image_wreak", data);
            writeFromCombotbox(turretimage, "graphics", "image_turret", data);
            writeFromCombotbox(shadowimage, "graphics", "image_shadow", data);
           /*
            * move animation 
            */
            writeFromNumeric(animstart, "graphics", "animation_moving_start", data);
            writeFromNumeric(animend, "graphics", "animation_moving_end", data);
            writeFromTextbox(animspeed, "graphics", "animation_moving_speed", data);
            writeFromCheck(moveAnimzpingPong, "graphics", "animation_moving_pingPong", data);
            /*
             * idle animation
             */
            writeFromNumeric(idleAnimstart, "graphics", "animation_idle_start", data);
            writeFromNumeric(idleAnimEnd, "graphics", "animation_idle_end", data);
            writeFromTextbox(idleAnimSpeed, "graphics", "animation_idle_speed", data);
            writeFromCheck(IdleAnimPingPong, "graphics", "animation_idle_pingPong", data);
            /*
             * Attack
             */
            writeFromCheck(canattack, "attack", "canAttack", data);
            writeFromCheck(land, "attack", "canAttackLandUnits", data);
            writeFromCheck(air, "attack", "canAttackFlyingUnits", data);
            writeFromCheck(uwater, "attack", "canAttackUnderwaterUnits", data);
            writeFromNumeric(arange, "attack", "maxAttackRange", data);
            /*
             * repair
             */
            writeFromCheck(autoRepair, "core", "autoRepair", data);
            writeFromCheck(canRepairBuilds, "core", "canRepairBuildings", data);
            writeFromCheck(canRepairUnits, "core", "canRepairUnits", data);
            writeFromTextbox(selfRegenRate, "core", "selfRegenRate", data);
           /*
            * Death
            */
            writeFromCheck(dieonzeroenergy, "core", "dieOnZeroEnergy", data);
            writeFromCheck(dieonconstruct, "core", "dieOnConstruct", data);
            writeFromCheck(eod, "core", "explodeOnDeath", data);
            writeFromCheck(doa, "attack", "dieOnAttack", data);
            writeFromTextbox(def, "core", "effectOnDeath", data);

            writeFromCombotbox(dl, "graphics", "drawLayer", data);
            writeFromNumeric(tslots, "core", "transportSlotsNeeded", data);
            writeFromCheck(sef, "graphics", "splastEffect", data);
            writeFromCheck(dustef, "graphics", "dustEffect", data);
            writeFromCheck(aiasb, "ai", "useAsBuilder", data);

            parser.WriteFile(sss[0], data);
            unitList ul = new unitList();
            Hide();
            ul.ShowDialog();
            Close();
        }
        private void writeFromTextbox(TextBox txt, string section, string param, IniData data)
        {
            if (txt.Text != null && txt.Text != "" && txt.Text != " " && txt.Enabled)
            {
                data[section][param] = txt.Text;
            }
            else if (data[section][param] != null)
            {
                data[section].RemoveKey(param);
            }
        }
        private void writeFromCombotbox(ComboBox txt, string section, string param, IniData data)
        {
            if (txt.Text != null && txt.Text != "" && txt.Text != " " && txt.Enabled)
            {
                data[section][param] = txt.Text;
            }
            else if (data[section][param] != null)
            {
                data[section].RemoveKey(param);
            }
        }

        private void writeFromCheck(CheckBox txt, string section, string param, IniData data)
        {
            if (txt.Enabled)
            {
                data[section][param] = txt.Checked.ToString();
            }
            else if (data[section][param] != null)
            {
                data[section].RemoveKey(param);
            }
        }
        private void writeFromNumeric(NumericUpDown txt, string section, string param, IniData data)
        {
            if (txt.Value != 0 && txt.Enabled)
            {
                data[section][param] = txt.Value.ToString();
            }
            else if (data[section][param] != null)
            {
                data[section].RemoveKey(param);
            }
        }
        private void editUnit_Load(object sender, EventArgs e)
        {

            load();
            loadimages();
            loadlist();
        }
        private void load()
        {
            try
            {
                string[] sss = Directory.GetFiles(path, "*.ini");
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(sss[0]);
                pictureBox1.BackgroundImage = new Bitmap(Path.Combine(path, data["graphics"]["image"]));
            hp.Value = Convert.ToInt32(data["core"]["maxHp"]);
            price.Value = Convert.ToInt32(data["core"]["price"]);
            mass.Value = Convert.ToInt32(data["core"]["mass"]);
            name.Text = data["core"]["displayText"];
            if (data["core"]["displayDescription"] != null)
                descript.Text = data["core"]["displayDescription"].Replace("\\n", "\r\n");
            else
                descript.Text = "-";
            deadimage.Text = data["graphics"]["image_wreak"];
            turretimage.Text = data["graphics"]["image_turret"];
            if (data["graphics"]["image_shadow"] != null)
                shadowimage.Text = data["graphics"]["image_shadow"];
            else
                shadowimage.Text = "NONE";

            movement.Text = data["movement"]["movementType"];
            isexperimental.Checked = Convert.ToBoolean(data["core"]["experimental"]);
            isbuilder.Checked = Convert.ToBoolean(data["core"]["isBuilder"]);
            isBio.Checked = Convert.ToBoolean(data["core"]["isBio"]);
            isBuilding.Checked = Convert.ToBoolean(data["core"]["isBuilding"]);
            frames.Value = Convert.ToInt32(data["graphics"]["total_frames"]);
            level.Value = Convert.ToInt32(data["core"]["techLevel"]);
            buildspeed.Text = data["core"]["buildSpeed"];
            radius.Value = Convert.ToInt32(data["core"]["radius"]);
            if (data["core"]["displayRadius"] != null)
                dradius.Value = Convert.ToInt32(data["core"]["displayRadius"]);
            else
                dradius.Value = radius.Value;
            soy.Value = Convert.ToInt32(data["graphics"]["shadowOffsetY"]);
            sox.Value = Convert.ToInt32(data["graphics"]["shadowOffsetX"]);
            if (data["core"]["transportSlotsNeeded"] != null)
                tslots.Value = Convert.ToInt32(data["core"]["transportSlotsNeeded"]);
            else
                tslots.Value = 0;
            energy.Text = data["core"]["energyMax"];
            energyr.Text = data["core"]["energyRegen"];
            shield.Value = Convert.ToInt32(data["core"]["maxShield"]);
            shieldr.Text = data["core"]["shieldRegen"];
            canattack.Checked = Convert.ToBoolean(data["attack"]["canAttack"]);
            air.Checked = Convert.ToBoolean(data["attack"]["canAttackFlyingUnits"]);
            land.Checked = Convert.ToBoolean(data["attack"]["canAttackLandUnits"]);
            uwater.Checked = Convert.ToBoolean(data["attack"]["canAttackUnderwaterUnits"]);
            multit.Checked = Convert.ToBoolean(data["attack"]["turretMultiTargeting"]);
            moveSpeed.Text = data["movement"]["moveSpeed"];
            accSpeed.Text = data["movement"]["moveAccelerationSpeed"];
            dSpeed.Text = data["movement"]["moveDecelerationSpeed"];
            turnSpeed.Text = data["movement"]["maxTurnSpeed"];
            tas.Text = data["movement"]["turnAcceleration"];
            aiasb.Checked = Convert.ToBoolean(data["ai"]["useAsBuilder"]);
            arange.Value = Convert.ToInt32(data["attack"]["maxAttackRange"]);
            autoRepair.Checked = Convert.ToBoolean(data["core"]["autoRepair"]);
            canRepairBuilds.Checked = Convert.ToBoolean(data["core"]["canRepairBuildings"]);
            canRepairUnits.Checked = Convert.ToBoolean(data["core"]["canRepairUnits"]);
            selfRegenRate.Text = data["core"]["selfRegenRate"];
            nukeOnDeath.Checked = Convert.ToBoolean(data["core"]["nukeOnDeath"]);
            nukeOnDeathRange.Text = data["core"]["nukeOnDeathRange"];
            nukeOnDeathDamage.Text = data["core"]["nukeOnDeathDamage"];
            noNuke.Checked = Convert.ToBoolean(data["core"]["nukeOnDeathDisableWhenNoNuke"]);
            dieonzeroenergy.Checked = Convert.ToBoolean(data["core"]["dieOnZeroEnergy"]);
            dieonconstruct.Checked = Convert.ToBoolean(data["core"]["dieOnConstruct"]);
            def.Text = data["core"]["effectOnDeath"];
            doa.Checked = Convert.ToBoolean(data["attack"]["dieOnAttack"]);
            if (Convert.ToBoolean(data["core"]["explodeOnDeath"]))
                eod.Checked = Convert.ToBoolean(data["core"]["explodeOnDeath"]);
            else
                eod.Checked = true;
            iox.Text = data["graphics"]["image_offsetX"];
            ioy.Text = data["graphics"]["image_offsetY"];
            ssaz.Checked = Convert.ToBoolean(data["core"]["startShieldAtZero"]);
            sit.Text = data["graphics"]["scaleImagesTo"];
            sef.Checked = Convert.ToBoolean(data["graphics"]["splastEffect"]);
            dustef.Checked = Convert.ToBoolean(data["graphics"]["dustEffect"]);
            dl.Text = data["graphics"]["drawLayer"];
            nanoFactorySpeed.Text = data["core"]["nanoFactorySpeed"];
            nanoRange.Text = data["core"]["nanoRange"];
            if (data["core"]["nanoRange"] != null)
                groupBox19.Enabled = true;
            nanoRepairSpeed.Text = data["core"]["nanoRepairSpeed"];
            nanobs.Text = data["core"]["nanoBuildSpeed"];
            nonukelocked.Checked = Convert.ToBoolean(data["core"]["isLockedIfGameModeNoNuke"]);
            targeth.Text = data["movement"]["targetHeight"];
            drift.Text = data["movement"]["targetHeightDrift"];
            landOnGround.Text = data["movement"]["landOnGround"];
            tags.Text = data["core"]["tags"];
                if (data["graphics"]["animation_moving_start"]!=null)
            {
                moveanim.Checked = true;
                animstart.Value =Convert.ToInt32(data["graphics"]["animation_moving_start"]);
                animend.Value =Convert.ToInt32(data["graphics"]["animation_moving_end"]);
                animspeed.Text = data["graphics"]["animation_moving_speed"];
                moveAnimzpingPong.Checked = Convert.ToBoolean(data["graphics"]["animation_moving_pingPong"]);
            }
                if (data["graphics"]["animation_idle_start"] != null)
                {
                    checkBox1.Checked = true;
                    idleAnimstart.Value = Convert.ToInt32(data["graphics"]["animation_idle_start"]);
                    idleAnimEnd.Value = Convert.ToInt32(data["graphics"]["animation_idle_end"]);
                    idleAnimSpeed.Text = data["graphics"]["animation_idle_speed"];
                    IdleAnimPingPong.Checked = Convert.ToBoolean(data["graphics"]["animation_idle_pingPong"]);
                }
                armour.Value = Convert.ToInt32(data["core"]["armour"]);
                lock_body_rotation_with_main_turret.Checked = Convert.ToBoolean(data["graphics"]["lock_body_rotation_with_main_turret"]);
            }
            catch(Exception e)
            {
                MessageBox.Show("Ало, Гитлер? \n-Это п*зда" + e);
            }
        }
        private void loadlist()
        {
            string[] sss = Directory.GetFiles(path, "*.ini");
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(sss[0]);
            string[] strings = data.ToString().Split(new[] { '\r', '\n' });
            bflist.Items.Clear();
            cblist.Items.Clear();
            actionlist.Items.Clear();
            turretlist.Items.Clear();
            projectilelist.Items.Clear();
            armlist.Items.Clear();
            alist.Items.Clear();
            elist.Items.Clear();
            animlist.Items.Clear();
            listBox1.Items.Clear();
            foreach (string s in strings)
            {
                if (s.Contains("#")) ;
                else
                {
                    if (s.Contains("builtFrom_") && s.Contains("_name"))
                    {
                        string[] str;
                        str = s.Split(new char[] { ':','_' });
                        ListBox lst = new ListBox();
                        bflist.Items.Add(str[1]+":"+str[3]);
                    }
                    if (s.Contains("[action_") && s.Contains("]"))
                    {
                        string[] str;
                        str = s.Split(new char[] { '_', ']' });
                        actionlist.Items.Add(str[1]);
                    }
                    if (s.Contains("[canBuild_") && s.Contains("]"))
                    {
                        string[] str;
                        str = s.Split(new char[] { '_', ']' });
                        cblist.Items.Add(str[1]);
                    }
                    if (s.Contains("[turret_") && s.Contains("]"))
                    {
                        string[] str;
                        str = s.Split(new char[] { '_', ']' });
                        turretlist.Items.Add(str[1]);
                    }
                    if (s.Contains("[projectile_") && s.Contains("]"))
                    {
                        string[] str;
                        str = s.Split(new char[] { '_', ']' });
                        projectilelist.Items.Add(str[1]);
                    }
                    if (s.Contains("[leg_") && s.Contains("]"))
                    {
                        string[] str;
                        str = s.Split(new char[] { '_', ']' });
                        armlist.Items.Add(str[1]);
                    }
                    if (s.Contains("[arm_") && s.Contains("]"))
                    {
                        string[] str;
                        str = s.Split(new char[] { '_', ']' });
                        listBox1.Items.Add(str[1]);
                    }
                    if (s.Contains("[attachment_") && s.Contains("]"))
                    {
                        string[] str;
                        str = s.Split(new char[] { '_', ']' });
                        alist.Items.Add(str[1]);
                    }
                    if (s.Contains("[effect_") && s.Contains("]"))
                    {
                        string[] str;
                        str = s.Split(new char[] { '_', ']' });
                        elist.Items.Add(str[1]);
                    }
                    if (s.Contains("[animation_") && s.Contains("]"))
                    {
                        string[] str;
                        str = s.Split(new char[] { '_', ']' });
                        animlist.Items.Add(str[1]);
                    }
                }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string[] sss = Directory.GetFiles(path, "*.ini");
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(sss[0]);
            if (data["core"]["footprint"] != null)
                ft.Text = data["core"]["footprint"];
            else
                ft.Text = "-1,-1,1,1";

            if (data["core"]["constructionFootprint"] != null)
                fc.Text = data["core"]["constructionFootprint"];
            else
                fc.Text = ft.Text;

            if (isBuilding.Checked)
            {
                footprint.Enabled = true;
                tslots.Enabled = dradius.Enabled = radius.Enabled = false;

            }
            else
            {
                footprint.Enabled = false;
                tslots.Enabled = dradius.Enabled = radius.Enabled = true;
            }
        }
        private void loadimages()
        {
            string[] sss = Directory.GetFiles(path, "*.png");
            for (int i = 0; i < sss.Length; i++)
            {
                deadimage.Items.Add(new DirectoryInfo(sss[i]).Name);
                turretimage.Items.Add(new DirectoryInfo(sss[i]).Name);
                shadowimage.Items.Add(new DirectoryInfo(sss[i]).Name);
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (moveanim.Checked)
            {
                groupBox5.Enabled = true;
            }
            else
            {
                groupBox5.Enabled = false;
            }
        }
        private void nukeOnDeath_CheckedChanged(object sender, EventArgs e)
        {

            if (nukeOnDeath.Checked)
            {
                groupBox20.Enabled = true;
            }
            else
            {
                groupBox20.Enabled = false;
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            string[] sss = Directory.GetFiles(path, "*.ini");
            System.Diagnostics.Process.Start(sss[0]);
            load();
            loadimages();
            loadlist();
        }

        private void button19_Click(object sender, EventArgs e)
        {
                canBuild cb = new canBuild();
                cb.ShowDialog();
                loadlist();
        }
        private void button18_Click(object sender, EventArgs e)
        {
            if (cblist.SelectedItem != null)
            {
                lastcb = cblist.SelectedItem.ToString();
                canBuild cb = new canBuild();
                cb.ShowDialog();
                lastcb = null;
            }
            else
            {
                MessageBox.Show("Select item first");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (cblist.SelectedItem != null)
            {
                string[] sss = Directory.GetFiles(path, "*.ini");
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(sss[0]);
                data.Sections.RemoveSection("canBuild_"+cblist.SelectedItem.ToString());
                parser.WriteFile(sss[0], data);
                loadlist();
            }
            else
            {
                MessageBox.Show("Select item first");
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            addTurret at = new addTurret();
            at.ShowDialog();
            loadlist();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (turretlist.SelectedItem != null)
            {
                lastt = turretlist.SelectedItem.ToString();
                addTurret at = new addTurret();
                at.ShowDialog();
                lastt = null;               
            }
            else
            {
                MessageBox.Show("Select turret first");
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (turretlist.SelectedItem != null)
            {
                string[] sss = Directory.GetFiles(path, "*.ini");
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(sss[0]);
                data.Sections.RemoveSection("turret_" + turretlist.SelectedItem.ToString());
                parser.WriteFile(sss[0], data);
                loadlist();
            }
            else
            {
                MessageBox.Show("Select item first");
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            addprojectile prj = new addprojectile();
            prj.ShowDialog();
            loadlist();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (projectilelist.SelectedItem != null)
            {
                 lastprj = projectilelist.SelectedItem.ToString();
                addprojectile at = new addprojectile();
                at.ShowDialog();
                lastprj = null;
            }
            else
            {
                MessageBox.Show("Select projectile first");
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (projectilelist.SelectedItem != null)
            {
                string[] sss = Directory.GetFiles(path, "*.ini");
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(sss[0]);
                data.Sections.RemoveSection("projectile_" + projectilelist.SelectedItem.ToString());
                parser.WriteFile(sss[0], data);
                loadlist();
            }
            else
            {
                MessageBox.Show("Select projectile first");
            }
        }
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                gb22.Enabled = true;
            }
            else
            {
                gb22.Enabled = false;
            }
        }

        private void enableNano_CheckedChanged(object sender, EventArgs e)
        {
            if (enableNano.Checked)
            {
                groupBox19.Enabled = true;
            }
            else
            {
                groupBox19.Enabled = false;
            }
        }
        private void button32_Click(object sender, EventArgs e)
        {
            customs.Text = customp.Text = customv.Text = string.Empty;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            unitList ul = new unitList();
            Hide();
            ul.ShowDialog();
            Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            lastbf = null;
            builtFrom bf = new builtFrom();
            bf.ShowDialog();
            loadlist();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (bflist.SelectedItem != null)
            {
                lastbf = bflist.SelectedItem.ToString();
                builtFrom bf = new builtFrom();
                bf.ShowDialog();
                lastbf = null;
            }
            else
            {
                MessageBox.Show("Select item first");
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            if (bflist.SelectedItem != null)
            {
                string[] sss = Directory.GetFiles(path, "*.ini");
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(sss[0]);
                data.Sections.GetSectionData("core").Keys.RemoveKey("builtFrom_" + bflist.SelectedItem.ToString().Split(':')[0] + "_name");
                data.Sections.GetSectionData("core").Keys.RemoveKey("builtFrom_" + bflist.SelectedItem.ToString().Split(':')[0] + "_pos");
                data.Sections.GetSectionData("core").Keys.RemoveKey("builtFrom_" + bflist.SelectedItem.ToString().Split(':')[0] + "_forceNano");
                data.Sections.GetSectionData("core").Keys.RemoveKey("builtFrom_" + bflist.SelectedItem.ToString().Split(':')[0] + "_isLocked");
                data.Sections.GetSectionData("core").Keys.RemoveKey("builtFrom_" + bflist.SelectedItem.ToString().Split(':')[0] + "_isLockedMessage");
                parser.WriteFile(sss[0],data);
                loadlist();
            }
            else
            {
                MessageBox.Show("Select item first");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            lastact = null;
            action act = new action();
            act.ShowDialog();
            loadlist();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            lastanim = null;
            canim cn = new canim();
            cn.ShowDialog();
            loadlist();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (actionlist.SelectedItem != null)
            {
                lastact = actionlist.SelectedItem.ToString();
                action act = new action();
                act.ShowDialog();
                lastact = null;
                loadlist();
            }
            else
            {
                MessageBox.Show("Select item first");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (alist.SelectedItem != null)
            {
                string[] sss = Directory.GetFiles(path, "*.ini");
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(sss[0]);
                data.Sections.RemoveSection("attachment_" + alist.SelectedItem.ToString());
                parser.WriteFile(sss[0], data);
                loadlist();
            }
            else
            {
                MessageBox.Show("Select item first");
            }
        }

        private void canRepairBuilds_CheckedChanged(object sender, EventArgs e)
        {
            isbuilder.Checked = true;
        }

        private void canRepairUnits_CheckedChanged(object sender, EventArgs e)
        {
            isbuilder.Checked = true;
        }

        private void autoRepair_CheckedChanged(object sender, EventArgs e)
        {
            isbuilder.Checked = true;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            lastleg = null;
            legss act = new legss();
            act.ShowDialog();
            loadlist();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (armlist.SelectedItem != null)
            {
                lastleg = armlist.SelectedItem.ToString();
                legss act = new legss();
                act.ShowDialog();
                lastleg = null;
                loadlist();
            }
            else
            {
                MessageBox.Show("Select item first");
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (armlist.SelectedItem != null)
            {
                string[] sss = Directory.GetFiles(path, "*.ini");
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(sss[0]);
                data.Sections.RemoveSection("leg_" + armlist.SelectedItem.ToString());
                parser.WriteFile(sss[0], data);
                loadlist();
            }
            else
            {
                MessageBox.Show("Select item first");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (animlist.SelectedItem != null)
            {
                lastanim = animlist.SelectedItem.ToString();
                canim act = new canim();
                act.ShowDialog();
                lastanim = null;
                loadlist();
            }
            else
            {
                MessageBox.Show("Select item first");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (animlist.SelectedItem != null)
            {
                string[] sss = Directory.GetFiles(path, "*.ini");
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(sss[0]);
                data.Sections.RemoveSection("animation_" + animlist.SelectedItem.ToString());
                parser.WriteFile(sss[0], data);
                loadlist();
            }
            else
            {
                MessageBox.Show("Select item first");
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            attachments att = new attachments();
            att.ShowDialog();
            loadlist();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (alist.SelectedItem != null)
            {
                lastact = alist.SelectedItem.ToString();
                attachments att = new attachments();
                att.ShowDialog();
                lastact = null;
                loadlist();
            }
            else
            {
                MessageBox.Show("Select item first");
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            effects eff = new effects();
            eff.ShowDialog();
            loadlist();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (elist.SelectedItem != null)
            {
                lastact = elist.SelectedItem.ToString();
                effects att = new effects();
                att.ShowDialog();
                lastact = null;
                loadlist();
            }
            else
            {
                MessageBox.Show("Select item first");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (elist.SelectedItem != null)
            {
                string[] sss = Directory.GetFiles(path, "*.ini");
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(sss[0]);
                data.Sections.RemoveSection("effect_" + elist.SelectedItem.ToString());
                parser.WriteFile(sss[0], data);
                loadlist();
            }
            else
            {
                MessageBox.Show("Select item first");
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            lastleg = null;
            arms act = new arms();
            act.ShowDialog();
            loadlist();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                lastleg = listBox1.SelectedItem.ToString();
                arms act = new arms();
                act.ShowDialog();
                lastleg = null;
                loadlist();
            }
            else
            {
                MessageBox.Show("Select item first");
            }
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string[] sss = Directory.GetFiles(path, "*.ini");
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(sss[0]);
                data.Sections.RemoveSection("arm_" + listBox1.SelectedItem.ToString());
                parser.WriteFile(sss[0], data);
                loadlist();
            }
            else
            {
                MessageBox.Show("Select item first");
            }
        }
    }
}