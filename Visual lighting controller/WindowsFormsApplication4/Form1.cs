using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        string fnlCmd = "";
        int modeslct;
        int modeslctb;
        bool runSeq;
        string[] effModes = new string[12] {"Solid", "Solid", "Solid", "Solid", "Solid", "Solid", "Solid", "Solid", "Solid", "Solid", "Solid", "Solid" };
        //All value arrays for each sequencing effect
        string[] eff1v = new string[10] {"0","0","0","0","0","0","0","0","0","1"};
        string[] eff2v = new string[10] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "1" };
        string[] eff3v = new string[10] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "1" };
        string[] eff4v = new string[10] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "1" };
        string[] eff5v = new string[10] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "1" };
        string[] eff6v = new string[10] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "1" };
        string[] eff7v = new string[10] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "1" };
        string[] eff8v = new string[10] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "1" };
        string[] eff9v = new string[10] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "1" };
        string[] eff10v = new string[10] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "1" };
        string[] eff11v = new string[10] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "1" };
        string[] eff12v = new string[10] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "1" };
        //Final commands for sequencing effects
        string eff1s="", eff2s="", eff3s = "", eff4s = "", eff5s = "", eff6s = "", eff7s = "", eff8s = "", eff9s = "", eff10s = "", eff11s = "", eff12s = "";

        //Is the effect a custom command?
        bool eff1isCC = false, eff2isCC = false, eff3isCC = false, eff4isCC = false, eff5isCC = false, eff6isCC = false, eff7isCC = false, eff8isCC = false, eff9isCC = false, eff10isCC = false, eff11isCC = false, eff12isCC = false;

        int selectedEff;
        int fan;
        public Form1()
        {
            InitializeComponent();
            getAvailablePorts();
        }
        void getAvailablePorts()
        {
            String[] ports = SerialPort.GetPortNames();
            comboBox2.Items.AddRange(ports);
            comboBox3.Items.AddRange(ports);
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var1l.Enabled = false;
            var1l.Visible = false;
            var1.Enabled = false;
            var1.Visible = false;
            var2l.Enabled = false;
            var2l.Visible = false;
            var2.Enabled = false;
            var2.Visible = false;
            var3l.Enabled = false;
            var3l.Visible = false;
            var3.Enabled = false;
            var3.Visible = false;
            var4l.Enabled = false;
            var4l.Visible = false;
            var4.Enabled = false;
            var4.Visible = false;
            var5l.Enabled = false;
            var5l.Visible = false;
            var5.Enabled = false;
            var5.Visible = false;
            var6l.Enabled = false;
            var6l.Visible = false;
            var6.Enabled = false;
            var6.Visible = false;
            var7l.Enabled = false;
            var7l.Visible = false;
            var7.Enabled = false;
            var7.Visible = false;
            fnlCmd = "";
            modeslct = 0;
            if (mode.Text == "Solid")
            {
                var1l.Text = "Red Value";
                var1l.Enabled = true;
                var1l.Visible = true;
                var1.Enabled = true;
                var1.Visible = true;
                var2l.Text = "Green Value";
                var2l.Enabled = true;
                var2l.Visible = true;
                var2.Enabled = true;
                var2.Visible = true;
                var3l.Text = "Blue Value";
                var3l.Enabled = true;
                var3l.Visible = true;
                var3.Enabled = true;
                var3.Visible = true;
                modeslct = 9;
            }
            if (mode.Text == "Hue Shift")
            {
                var1l.Text = "Starting Hue";
                var1l.Enabled = true;
                var1l.Visible = true;
                var1.Enabled = true;
                var1.Visible = true;
                var2l.Text = "Ending Hue";
                var2l.Enabled = true;
                var2l.Visible = true;
                var2.Enabled = true;
                var2.Visible = true;
                var3l.Text = "Hue Offset";
                var3l.Enabled = true;
                var3l.Visible = true;
                var3.Enabled = true;
                var3.Visible = true;
                var5l.Text = "Phase Offset";
                var5l.Enabled = true;
                var5l.Visible = true;
                var5.Enabled = true;
                var5.Visible = true;
                var7l.Text = "Rate";
                var7l.Enabled = true;
                var7l.Visible = true;
                var7.Enabled = true;
                var7.Visible = true;
                modeslct = 0;
            }
            if (mode.Text == "Single-Point Spinner")
            {
                var1l.Text = "Hue";
                var1l.Enabled = true;
                var1l.Visible = true;
                var1.Enabled = true;
                var1.Visible = true;
                var2l.Text = "0/1 = CW/CCW";
                var2l.Enabled = true;
                var2l.Visible = true;
                var2.Enabled = true;
                var2.Visible = true;
                var3l.Text = "0/1 = Hue/Rainbow";
                var3l.Enabled = true;
                var3l.Visible = true;
                var3.Enabled = true;
                var3.Visible = true;
                var4l.Text = "Rainbow change rate";
                var4l.Enabled = true;
                var4l.Visible = true;
                var4.Enabled = true;
                var4.Visible = true;
                var5l.Text = "Offset";
                var5l.Enabled = true;
                var5l.Visible = true;
                var5.Enabled = true;
                var5.Visible = true;
                var6l.Text = "Fade Speed";
                var6l.Enabled = true;
                var6l.Visible = true;
                var6.Enabled = true;
                var6.Visible = true;
                var7l.Text = "Spin Speed";
                var7l.Enabled = true;
                var7l.Visible = true;
                var7.Enabled = true;
                var7.Visible = true;
                modeslct = 1;
            }
            if (mode.Text == "Two-Point Spinner")
            {
                var1l.Text = "Hue";
                var1l.Enabled = true;
                var1l.Visible = true;
                var1.Enabled = true;
                var1.Visible = true;
                var2l.Text = "0/1 = CW/CCW";
                var2l.Enabled = true;
                var2l.Visible = true;
                var2.Enabled = true;
                var2.Visible = true;
                var3l.Text = "0/1 = Hue/Rainbow";
                var3l.Enabled = true;
                var3l.Visible = true;
                var3.Enabled = true;
                var3.Visible = true;
                var4l.Text = "Rainbow change rate";
                var4l.Enabled = true;
                var4l.Visible = true;
                var4.Enabled = true;
                var4.Visible = true;
                var5l.Text = "Hue shift";
                var5l.Enabled = true;
                var5l.Visible = true;
                var5.Enabled = true;
                var5.Visible = true;
                var6l.Text = "Fade Speed";
                var6l.Enabled = true;
                var6l.Visible = true;
                var6.Enabled = true;
                var6.Visible = true;
                var7l.Text = "Spin Speed";
                var7l.Enabled = true;
                var7l.Visible = true;
                var7.Enabled = true;
                var7.Visible = true;
                modeslct = 5;
            }
            if (mode.Text == "Four-Point Spinner")
            {
                var1l.Text = "Hue";
                var1l.Enabled = true;
                var1l.Visible = true;
                var1.Enabled = true;
                var1.Visible = true;
                var2l.Text = "0/1 = CW/CCW";
                var2l.Enabled = true;
                var2l.Visible = true;
                var2.Enabled = true;
                var2.Visible = true;
                var3l.Text = "0/1 = Hue/Rainbow";
                var3l.Enabled = true;
                var3l.Visible = true;
                var3.Enabled = true;
                var3.Visible = true;
                var4l.Text = "Rainbow change rate";
                var4l.Enabled = true;
                var4l.Visible = true;
                var4.Enabled = true;
                var4.Visible = true;
                var5l.Text = "Hue shift";
                var5l.Enabled = true;
                var5l.Visible = true;
                var5.Enabled = true;
                var5.Visible = true;
                var6l.Text = "Fade Speed";
                var6l.Enabled = true;
                var6l.Visible = true;
                var6.Enabled = true;
                var6.Visible = true;
                var7l.Text = "Spin Speed";
                var7l.Enabled = true;
                var7l.Visible = true;
                var7.Enabled = true;
                var7.Visible = true;
                modeslct = 3;
            }
            if(mode.Text == "Rainbow span across LEDs")
            {
                var1l.Text = "Sparkle chance";
                var1l.Enabled = true;
                var1l.Visible = true;
                var1.Enabled = true;
                var1.Visible = true;
                var2l.Text = "Hue step per LED";
                var2l.Enabled = true;
                var2l.Visible = true;
                var2.Enabled = true;
                var2.Visible = true;
                var7l.Text = "Spin Speed";
                var7l.Enabled = true;
                var7l.Visible = true;
                var7.Enabled = true;
                var7.Visible = true;
                modeslct = 2;
            }
            if(mode.Text == "Double Scan")
            {
                var1l.Text = "Hue";
                var1l.Enabled = true;
                var1l.Visible = true;
                var1.Enabled = true;
                var1.Visible = true;
                var2l.Text = "Rotation Offset";
                var2l.Enabled = true;
                var2l.Visible = true;
                var2.Enabled = true;
                var2.Visible = true;
                var3l.Text = "0/1 = Hue/Rainbow";
                var3l.Enabled = true;
                var3l.Visible = true;
                var3.Enabled = true;
                var3.Visible = true;
                var4l.Text = "Rainbow change rate";
                var4l.Enabled = true;
                var4l.Visible = true;
                var4.Enabled = true;
                var4.Visible = true;
                var5l.Text = "Hue shift";
                var5l.Enabled = true;
                var5l.Visible = true;
                var5.Enabled = true;
                var5.Visible = true;
                var6l.Text = "Fade Speed";
                var6l.Enabled = true;
                var6l.Visible = true;
                var6.Enabled = true;
                var6.Visible = true;
                var7l.Text = "Spin Speed";
                var7l.Enabled = true;
                var7l.Visible = true;
                var7.Enabled = true;
                var7.Visible = true;
                modeslct = 4;
            }
            if(mode.Text == "BPM Mode")
            {
                var1l.Text = "Hue Multiplier";
                var1l.Enabled = true;
                var1l.Visible = true;
                var1.Enabled = true;
                var1.Visible = true;
                var2l.Text = "Beat Multiplier";
                var2l.Enabled = true;
                var2l.Visible = true;
                var2.Enabled = true;
                var2.Visible = true;
                var7l.Text = "Rate";
                var7l.Enabled = true;
                var7l.Visible = true;
                var7.Enabled = true;
                var7.Visible = true;
                modeslct = 6;
            }
            if(mode.Text == "Split Sides")
            {
                var1l.Text = "West Hue";
                var1l.Enabled = true;
                var1l.Visible = true;
                var1.Enabled = true;
                var1.Visible = true;
                var2l.Text = "East Hue";
                var2l.Enabled = true;
                var2l.Visible = true;
                var2.Enabled = true;
                var2.Visible = true;
                var4l.Text = "Fan pulse offset";
                var4l.Enabled = true;
                var4l.Visible = true;
                var4.Enabled = true;
                var4.Visible = true;
                var5l.Text = "Side pulse offset";
                var5l.Enabled = true;
                var5l.Visible = true;
                var5.Enabled = true;
                var5.Visible = true;
                var6l.Text = "Pulse Type";
                var6l.Enabled = true;
                var6l.Visible = true;
                var6.Enabled = true;
                var6.Visible = true;
                var7l.Text = "Pulse Rate";
                var7l.Enabled = true;
                var7l.Visible = true;
                var7.Enabled = true;
                var7.Visible = true;
                modeslct = 7;
            }
            if (mode.Text == "Split Quarters")
            {
                var1l.Text = "NW Hue";
                var1l.Enabled = true;
                var1l.Visible = true;
                var1.Enabled = true;
                var1.Visible = true;
                var2l.Text = "NE Hue";
                var2l.Enabled = true;
                var2l.Visible = true;
                var2.Enabled = true;
                var2.Visible = true;
                var3l.Text = "SE Hue";
                var3l.Enabled = true;
                var3l.Visible = true;
                var3.Enabled = true;
                var3.Visible = true;
                var4l.Text = "SW Hue";
                var4l.Enabled = true;
                var4l.Visible = true;
                var4.Enabled = true;
                var4.Visible = true;
                var5l.Text = "Side pulse offset";
                var5l.Enabled = true;
                var5l.Visible = true;
                var5.Enabled = true;
                var5.Visible = true;
                var6l.Text = "Pulse Type";
                var6l.Enabled = true;
                var6l.Visible = true;
                var6.Enabled = true;
                var6.Visible = true;
                var7l.Text = "Pulse Rate";
                var7l.Enabled = true;
                var7l.Visible = true;
                var7.Enabled = true;
                var7.Visible = true;
                modeslct = 8;
            }
            if(mode.Text == "Fade to Black")
            {
                var1l.Text = "Fade Rate";
                var1l.Enabled = true;
                var1l.Visible = true;
                var1.Enabled = true;
                var1.Visible = true;
                modeslct = 10;
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void var1_TextChanged(object sender, EventArgs e)
        {

        }

        private void var2_TextChanged(object sender, EventArgs e)
        {

        }

        private void var3_TextChanged(object sender, EventArgs e)
        {

        }

        private void var4_TextChanged(object sender, EventArgs e)
        {

        }

        private void lightSelB_SelectedIndexChanged(object sender, EventArgs e)
        {
            button6.Visible = true;
            button6.Enabled = true;
            checkBox1.Visible = true;
            checkBox1.Enabled = true;
            ccB.Enabled = true;
            ccB.Visible = true;
            if (selectedEff == 1)
            {
                if (lightSelB.Text == "Fan 1")
                {
                    eff1v[9] = "1";
                }
                if (lightSelB.Text == "Fan 2")
                {
                    eff1v[9] = "2";
                }
                if (lightSelB.Text == "Fan 3")
                {
                    eff1v[9] = "3";
                }
                if (lightSelB.Text == "Fan 4")
                {
                    eff1v[9] = "4";
                }
                if (lightSelB.Text == "Fan 5")
                {
                    eff1v[9] = "5";
                }
                if (lightSelB.Text == "Fan 6")
                {
                    eff1v[9] = "6";
                }
                if (lightSelB.Text == "LED Strip 1")
                {
                    eff1v[9] = "7";
                }
                if (lightSelB.Text == "LED Strip 2")
                {
                    eff1v[9] = "8";
                }
                if (lightSelB.Text == "LED Strip 3")
                {
                    eff1v[9] = "9";
                }
                if (lightSelB.Text == "LED Strip 4")
                {
                    eff1v[9] = "10";
                }
            }
            if (selectedEff == 2)
            {
                if (lightSelB.Text == "Fan 1")
                {
                    eff2v[9] = "1";
                }
                if (lightSelB.Text == "Fan 2")
                {
                    eff2v[9] = "2";
                }
                if (lightSelB.Text == "Fan 3")
                {
                    eff2v[9] = "3";
                }
                if (lightSelB.Text == "Fan 4")
                {
                    eff2v[9] = "4";
                }
                if (lightSelB.Text == "Fan 5")
                {
                    eff2v[9] = "5";
                }
                if (lightSelB.Text == "Fan 6")
                {
                    eff2v[9] = "6";
                }
                if (lightSelB.Text == "LED Strip 1")
                {
                    eff2v[9] = "7";
                }
                if (lightSelB.Text == "LED Strip 2")
                {
                    eff2v[9] = "8";
                }
                if (lightSelB.Text == "LED Strip 3")
                {
                    eff2v[9] = "9";
                }
                if (lightSelB.Text == "LED Strip 4")
                {
                    eff2v[9] = "10";
                }
            }
            if (selectedEff == 3)
            {
                if (lightSelB.Text == "Fan 1")
                {
                    eff3v[9] = "1";
                }
                if (lightSelB.Text == "Fan 2")
                {
                    eff3v[9] = "2";
                }
                if (lightSelB.Text == "Fan 3")
                {
                    eff3v[9] = "3";
                }
                if (lightSelB.Text == "Fan 4")
                {
                    eff3v[9] = "4";
                }
                if (lightSelB.Text == "Fan 5")
                {
                    eff3v[9] = "5";
                }
                if (lightSelB.Text == "Fan 6")
                {
                    eff3v[9] = "6";
                }
                if (lightSelB.Text == "LED Strip 1")
                {
                    eff3v[9] = "7";
                }
                if (lightSelB.Text == "LED Strip 2")
                {
                    eff3v[9] = "8";
                }
                if (lightSelB.Text == "LED Strip 3")
                {
                    eff3v[9] = "9";
                }
                if (lightSelB.Text == "LED Strip 4")
                {
                    eff3v[9] = "10";
                }
            }
            if (selectedEff == 4)
            {
                if (lightSelB.Text == "Fan 1")
                {
                    eff4v[9] = "1";
                }
                if (lightSelB.Text == "Fan 2")
                {
                    eff4v[9] = "2";
                }
                if (lightSelB.Text == "Fan 3")
                {
                    eff4v[9] = "3";
                }
                if (lightSelB.Text == "Fan 4")
                {
                    eff4v[9] = "4";
                }
                if (lightSelB.Text == "Fan 5")
                {
                    eff4v[9] = "5";
                }
                if (lightSelB.Text == "Fan 6")
                {
                    eff4v[9] = "6";
                }
                if (lightSelB.Text == "LED Strip 1")
                {
                    eff4v[9] = "7";
                }
                if (lightSelB.Text == "LED Strip 2")
                {
                    eff4v[9] = "8";
                }
                if (lightSelB.Text == "LED Strip 3")
                {
                    eff4v[9] = "9";
                }
                if (lightSelB.Text == "LED Strip 4")
                {
                    eff4v[9] = "10";
                }
            }
            if (selectedEff == 5)
            {
                if (lightSelB.Text == "Fan 1")
                {
                    eff5v[9] = "1";
                }
                if (lightSelB.Text == "Fan 2")
                {
                    eff5v[9] = "2";
                }
                if (lightSelB.Text == "Fan 3")
                {
                    eff5v[9] = "3";
                }
                if (lightSelB.Text == "Fan 4")
                {
                    eff5v[9] = "4";
                }
                if (lightSelB.Text == "Fan 5")
                {
                    eff5v[9] = "5";
                }
                if (lightSelB.Text == "Fan 6")
                {
                    eff5v[9] = "6";
                }
                if (lightSelB.Text == "LED Strip 1")
                {
                    eff5v[9] = "7";
                }
                if (lightSelB.Text == "LED Strip 2")
                {
                    eff5v[9] = "8";
                }
                if (lightSelB.Text == "LED Strip 3")
                {
                    eff5v[9] = "9";
                }
                if (lightSelB.Text == "LED Strip 4")
                {
                    eff5v[9] = "10";
                }
            }
            if (selectedEff == 6)
            {
                if (lightSelB.Text == "Fan 1")
                {
                    eff6v[9] = "1";
                }
                if (lightSelB.Text == "Fan 2")
                {
                    eff6v[9] = "2";
                }
                if (lightSelB.Text == "Fan 3")
                {
                    eff6v[9] = "3";
                }
                if (lightSelB.Text == "Fan 4")
                {
                    eff6v[9] = "4";
                }
                if (lightSelB.Text == "Fan 5")
                {
                    eff6v[9] = "5";
                }
                if (lightSelB.Text == "Fan 6")
                {
                    eff6v[9] = "6";
                }
                if (lightSelB.Text == "LED Strip 1")
                {
                    eff6v[9] = "7";
                }
                if (lightSelB.Text == "LED Strip 2")
                {
                    eff6v[9] = "8";
                }
                if (lightSelB.Text == "LED Strip 3")
                {
                    eff6v[9] = "9";
                }
                if (lightSelB.Text == "LED Strip 4")
                {
                    eff6v[9] = "10";
                }
            }
            if (selectedEff == 7)
            {
                if (lightSelB.Text == "Fan 1")
                {
                    eff7v[9] = "1";
                }
                if (lightSelB.Text == "Fan 2")
                {
                    eff7v[9] = "2";
                }
                if (lightSelB.Text == "Fan 3")
                {
                    eff7v[9] = "3";
                }
                if (lightSelB.Text == "Fan 4")
                {
                    eff7v[9] = "4";
                }
                if (lightSelB.Text == "Fan 5")
                {
                    eff7v[9] = "5";
                }
                if (lightSelB.Text == "Fan 6")
                {
                    eff7v[9] = "6";
                }
                if (lightSelB.Text == "LED Strip 1")
                {
                    eff7v[9] = "7";
                }
                if (lightSelB.Text == "LED Strip 2")
                {
                    eff7v[9] = "8";
                }
                if (lightSelB.Text == "LED Strip 3")
                {
                    eff7v[9] = "9";
                }
                if (lightSelB.Text == "LED Strip 4")
                {
                    eff7v[9] = "10";
                }
            }
            if (selectedEff == 8)
            {
                if (lightSelB.Text == "Fan 1")
                {
                    eff8v[9] = "1";
                }
                if (lightSelB.Text == "Fan 2")
                {
                    eff8v[9] = "2";
                }
                if (lightSelB.Text == "Fan 3")
                {
                    eff8v[9] = "3";
                }
                if (lightSelB.Text == "Fan 4")
                {
                    eff8v[9] = "4";
                }
                if (lightSelB.Text == "Fan 5")
                {
                    eff8v[9] = "5";
                }
                if (lightSelB.Text == "Fan 6")
                {
                    eff8v[9] = "6";
                }
                if (lightSelB.Text == "LED Strip 1")
                {
                    eff8v[9] = "7";
                }
                if (lightSelB.Text == "LED Strip 2")
                {
                    eff8v[9] = "8";
                }
                if (lightSelB.Text == "LED Strip 3")
                {
                    eff8v[9] = "9";
                }
                if (lightSelB.Text == "LED Strip 4")
                {
                    eff8v[9] = "10";
                }
            }
            if (selectedEff == 9)
            {
                if (lightSelB.Text == "Fan 1")
                {
                    eff9v[9] = "1";
                }
                if (lightSelB.Text == "Fan 2")
                {
                    eff9v[9] = "2";
                }
                if (lightSelB.Text == "Fan 3")
                {
                    eff9v[9] = "3";
                }
                if (lightSelB.Text == "Fan 4")
                {
                    eff9v[9] = "4";
                }
                if (lightSelB.Text == "Fan 5")
                {
                    eff9v[9] = "5";
                }
                if (lightSelB.Text == "Fan 6")
                {
                    eff9v[9] = "6";
                }
                if (lightSelB.Text == "LED Strip 1")
                {
                    eff9v[9] = "7";
                }
                if (lightSelB.Text == "LED Strip 2")
                {
                    eff9v[9] = "8";
                }
                if (lightSelB.Text == "LED Strip 3")
                {
                    eff9v[9] = "9";
                }
                if (lightSelB.Text == "LED Strip 4")
                {
                    eff9v[9] = "10";
                }
            }
            if (selectedEff == 10)
            {
                if (lightSelB.Text == "Fan 1")
                {
                    eff10v[9] = "1";
                }
                if (lightSelB.Text == "Fan 2")
                {
                    eff10v[9] = "2";
                }
                if (lightSelB.Text == "Fan 3")
                {
                    eff10v[9] = "3";
                }
                if (lightSelB.Text == "Fan 4")
                {
                    eff10v[9] = "4";
                }
                if (lightSelB.Text == "Fan 5")
                {
                    eff10v[9] = "5";
                }
                if (lightSelB.Text == "Fan 6")
                {
                    eff10v[9] = "6";
                }
                if (lightSelB.Text == "LED Strip 1")
                {
                    eff10v[9] = "7";
                }
                if (lightSelB.Text == "LED Strip 2")
                {
                    eff10v[9] = "8";
                }
                if (lightSelB.Text == "LED Strip 3")
                {
                    eff10v[9] = "9";
                }
                if (lightSelB.Text == "LED Strip 4")
                {
                    eff10v[9] = "10";
                }
            }
            if (selectedEff == 11)
            {
                if (lightSelB.Text == "Fan 1")
                {
                    eff11v[9] = "1";
                }
                if (lightSelB.Text == "Fan 2")
                {
                    eff11v[9] = "2";
                }
                if (lightSelB.Text == "Fan 3")
                {
                    eff11v[9] = "3";
                }
                if (lightSelB.Text == "Fan 4")
                {
                    eff11v[9] = "4";
                }
                if (lightSelB.Text == "Fan 5")
                {
                    eff11v[9] = "5";
                }
                if (lightSelB.Text == "Fan 6")
                {
                    eff11v[9] = "6";
                }
                if (lightSelB.Text == "LED Strip 1")
                {
                    eff11v[9] = "7";
                }
                if (lightSelB.Text == "LED Strip 2")
                {
                    eff11v[9] = "8";
                }
                if (lightSelB.Text == "LED Strip 3")
                {
                    eff11v[9] = "9";
                }
                if (lightSelB.Text == "LED Strip 4")
                {
                    eff11v[9] = "10";
                }
            }
            if (selectedEff == 12)
            {
                if (lightSelB.Text == "Fan 1")
                {
                    eff12v[9] = "1";
                }
                if (lightSelB.Text == "Fan 2")
                {
                    eff12v[9] = "2";
                }
                if (lightSelB.Text == "Fan 3")
                {
                    eff12v[9] = "3";
                }
                if (lightSelB.Text == "Fan 4")
                {
                    eff12v[9] = "4";
                }
                if (lightSelB.Text == "Fan 5")
                {
                    eff12v[9] = "5";
                }
                if (lightSelB.Text == "Fan 6")
                {
                    eff12v[9] = "6";
                }
                if (lightSelB.Text == "LED Strip 1")
                {
                    eff12v[9] = "7";
                }
                if (lightSelB.Text == "LED Strip 2")
                {
                    eff12v[9] = "8";
                }
                if (lightSelB.Text == "LED Strip 3")
                {
                    eff12v[9] = "9";
                }
                if (lightSelB.Text == "LED Strip 4")
                {
                    eff12v[9] = "10";
                }
            }
        }

        private void eff2_Click(object sender, EventArgs e)
        {
            modeB.Text = effModes[1];
            label1.Enabled = true;
            label1.Visible = true;
            label1.Text = "Effect 2 settings: ";
            lightSelB.Visible = true;
            lightSelB.Enabled = true;
            modeB.Visible = true;
            modeB.Enabled = true;
            selectedEff = 2;
            var1b.Text = eff2v[0];
            var2b.Text = eff2v[1];
            var3b.Text = eff2v[2];
            var4b.Text = eff2v[3];
            var5b.Text = eff2v[4];
            var6b.Text = eff2v[5];
            var7b.Text = eff2v[6];
            TNE.Text = eff2v[8];
            lightSelB.Text = "Fan " + eff2v[9];
            if (eff2isCC)
            {
                checkBox1.Checked = true;
                ccB.Text = eff2s;
            }
            if (!eff2isCC)
            {
                checkBox1.Checked = false;
                ccB.Text = "";
            }
        }

        private void eff4_Click(object sender, EventArgs e)
        {
            modeB.Text = effModes[3];
            label1.Enabled = true;
            label1.Visible = true;
            label1.Text = "Effect 4 settings: ";
            lightSelB.Visible = true;
            lightSelB.Enabled = true;
            modeB.Visible = true;
            modeB.Enabled = true;
            selectedEff = 4;
            var1b.Text = eff4v[0];
            var2b.Text = eff4v[1];
            var3b.Text = eff4v[2];
            var4b.Text = eff4v[3];
            var5b.Text = eff4v[4];
            var6b.Text = eff4v[5];
            var7b.Text = eff4v[6];
            TNE.Text = eff4v[8];
            lightSelB.Text = "Fan " + eff4v[9];
            if (eff4isCC)
            {
                checkBox1.Checked = true;
                ccB.Text = eff4s;
            }
            if (!eff4isCC)
            {
                checkBox1.Checked = false;
                ccB.Text = "";
            }
        }

        private void eff5_Click(object sender, EventArgs e)
        {
            modeB.Text = effModes[4];
            label1.Enabled = true;
            label1.Visible = true;
            label1.Text = "Effect 5 settings: ";
            lightSelB.Visible = true;
            lightSelB.Enabled = true;
            modeB.Visible = true;
            modeB.Enabled = true;
            selectedEff = 5;
            var1b.Text = eff5v[0];
            var2b.Text = eff5v[1];
            var3b.Text = eff5v[2];
            var4b.Text = eff5v[3];
            var5b.Text = eff5v[4];
            var6b.Text = eff5v[5];
            var7b.Text = eff5v[6];
            TNE.Text = eff5v[8];
            lightSelB.Text = "Fan " + eff5v[9];
            if (eff5isCC)
            {
                checkBox1.Checked = true;
                ccB.Text = eff5s;
            }
            if (!eff5isCC)
            {
                checkBox1.Checked = false;
                ccB.Text = "";
            }
        }

        private void eff7_Click(object sender, EventArgs e)
        {
            modeB.Text = effModes[6];
            label1.Enabled = true;
            label1.Visible = true;
            label1.Text = "Effect 7 settings: ";
            lightSelB.Visible = true;
            lightSelB.Enabled = true;
            modeB.Visible = true;
            modeB.Enabled = true;
            selectedEff = 7;
            var1b.Text = eff7v[0];
            var2b.Text = eff7v[1];
            var3b.Text = eff7v[2];
            var4b.Text = eff7v[3];
            var5b.Text = eff7v[4];
            var6b.Text = eff7v[5];
            var7b.Text = eff7v[6];
            TNE.Text = eff7v[8];
            lightSelB.Text = "Fan " + eff7v[9];
            if (eff7isCC)
            {
                checkBox1.Checked = true;
                ccB.Text = eff7s;
            }
            if (!eff7isCC)
            {
                checkBox1.Checked = false;
                ccB.Text = "";
            }
        }

        private void eff8_Click(object sender, EventArgs e)
        {
            modeB.Text = effModes[7];
            label1.Enabled = true;
            label1.Visible = true;
            label1.Text = "Effect 8 settings: ";
            lightSelB.Visible = true;
            lightSelB.Enabled = true;
            modeB.Visible = true;
            modeB.Enabled = true;
            selectedEff = 8;
            var1b.Text = eff8v[0];
            var2b.Text = eff8v[1];
            var3b.Text = eff8v[2];
            var4b.Text = eff8v[3];
            var5b.Text = eff8v[4];
            var6b.Text = eff8v[5];
            var7b.Text = eff8v[6];
            TNE.Text = eff8v[8];
            lightSelB.Text = "Fan " + eff8v[9];
            if (eff8isCC)
            {
                checkBox1.Checked = true;
                ccB.Text = eff8s;
            }
            if (!eff8isCC)
            {
                checkBox1.Checked = false;
                ccB.Text = "";
            }
        }

        private void eff9_Click(object sender, EventArgs e)
        {
            modeB.Text = effModes[8];
            label1.Enabled = true;
            label1.Visible = true;
            label1.Text = "Effect 9 settings: ";
            lightSelB.Visible = true;
            lightSelB.Enabled = true;
            modeB.Visible = true;
            modeB.Enabled = true;
            selectedEff = 9;
            var1b.Text = eff9v[0];
            var2b.Text = eff9v[1];
            var3b.Text = eff9v[2];
            var4b.Text = eff9v[3];
            var5b.Text = eff9v[4];
            var6b.Text = eff9v[5];
            var7b.Text = eff9v[6];
            TNE.Text = eff9v[8];
            lightSelB.Text = "Fan " + eff9v[9];
            if (eff9isCC)
            {
                checkBox1.Checked = true;
                ccB.Text = eff9s;
            }
            if (!eff9isCC)
            {
                checkBox1.Checked = false;
                ccB.Text = "";
            }
        }

        private void eff10_Click(object sender, EventArgs e)
        {
            modeB.Text = effModes[9];
            label1.Enabled = true;
            label1.Visible = true;
            label1.Text = "Effect 10 settings: ";
            lightSelB.Visible = true;
            lightSelB.Enabled = true;
            modeB.Visible = true;
            modeB.Enabled = true;
            selectedEff = 10;
            var1b.Text = eff10v[0];
            var2b.Text = eff10v[1];
            var3b.Text = eff10v[2];
            var4b.Text = eff10v[3];
            var5b.Text = eff10v[4];
            var6b.Text = eff10v[5];
            var7b.Text = eff10v[6];
            TNE.Text = eff10v[8];
            lightSelB.Text = "Fan " + eff10v[9];
            if (eff10isCC)
            {
                checkBox1.Checked = true;
                ccB.Text = eff10s;
            }
            if (!eff10isCC)
            {
                checkBox1.Checked = false;
                ccB.Text = "";
            }
        }

        private void eff11_Click(object sender, EventArgs e)
        {
            modeB.Text = effModes[10];
            label1.Enabled = true;
            label1.Visible = true;
            label1.Text = "Effect 11 settings: ";
            lightSelB.Visible = true;
            lightSelB.Enabled = true;
            modeB.Visible = true;
            modeB.Enabled = true;
            selectedEff = 11;
            var1b.Text = eff11v[0];
            var2b.Text = eff11v[1];
            var3b.Text = eff11v[2];
            var4b.Text = eff11v[3];
            var5b.Text = eff11v[4];
            var6b.Text = eff11v[5];
            var7b.Text = eff11v[6];
            TNE.Text = eff11v[8];
            lightSelB.Text = "Fan " + eff11v[9];
            if (eff11isCC)
            {
                checkBox1.Checked = true;
                ccB.Text = eff11s;
            }
            if (!eff11isCC)
            {
                checkBox1.Checked = false;
                ccB.Text = "";
            }
        }

        private void eff12_Click(object sender, EventArgs e)
        {
            modeB.Text = effModes[11];
            label1.Enabled = true;
            label1.Visible = true;
            label1.Text = "Effect 12 settings: ";
            lightSelB.Visible = true;
            lightSelB.Enabled = true;
            modeB.Visible = true;
            modeB.Enabled = true;
            selectedEff = 12;
            var1b.Text = eff12v[0];
            var2b.Text = eff12v[1];
            var3b.Text = eff12v[2];
            var4b.Text = eff12v[3];
            var5b.Text = eff12v[4];
            var6b.Text = eff12v[5];
            var7b.Text = eff12v[6];
            TNE.Text = eff12v[8];
            lightSelB.Text = "Fan " + eff12v[9];
            if (eff12isCC)
            {
                checkBox1.Checked = true;
                ccB.Text = eff12s;
            }
            if (!eff12isCC)
            {
                checkBox1.Checked = false;
                ccB.Text = "";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            runSeq = true;
            while (runSeq)
            {
                if (eff1on.Checked)
                {
                    serialPort1.WriteLine(eff1s);
                    wait(Int32.Parse(eff1v[8]));
                }
                if (eff2on.Checked)
                {
                    serialPort1.WriteLine(eff2s);
                    wait(Int32.Parse(eff2v[8]));
                }
                if (eff3on.Checked)
                {
                    serialPort1.WriteLine(eff3s);
                    wait(Int32.Parse(eff3v[8]));
                }
                if (eff4on.Checked)
                {
                    serialPort1.WriteLine(eff4s);
                    wait(Int32.Parse(eff4v[8]));
                }
                if (eff5on.Checked)
                {
                    serialPort1.WriteLine(eff5s);
                    wait(Int32.Parse(eff5v[8]));
                }
                if (eff6on.Checked)
                {
                    serialPort1.WriteLine(eff6s);
                    wait(Int32.Parse(eff6v[8]));
                }
                if (eff7on.Checked)
                {
                    serialPort1.WriteLine(eff7s);
                    wait(Int32.Parse(eff7v[8]));
                }
                if (eff8on.Checked)
                {
                    serialPort1.WriteLine(eff8s);
                    wait(Int32.Parse(eff8v[8]));
                }
                if (eff9on.Checked)
                {
                    serialPort1.WriteLine(eff9s);
                    wait(Int32.Parse(eff9v[8]));
                }
                if (eff10on.Checked)
                {
                    serialPort1.WriteLine(eff10s);
                    wait(Int32.Parse(eff10v[8]));
                }
                if (eff11on.Checked)
                {
                    serialPort1.WriteLine(eff11s);
                    wait(Int32.Parse(eff11v[8]));
                }
                if (eff12on.Checked)
                {
                    serialPort1.WriteLine(eff12s);
                    wait(Int32.Parse(eff12v[8]));
                }
            }
        }
        private void wait(int milliseconds)
        {
            if (milliseconds < 1) return;
            DateTime _desired = DateTime.Now.AddMilliseconds(milliseconds);
            while (DateTime.Now < _desired)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }
        private void eff1on_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            runSeq = false;
        }

        private void var2b_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox2.Text = comboBox3.Text;
        }

        private void TNE_TextChanged(object sender, EventArgs e)
        {

        }

        private void var5_TextChanged(object sender, EventArgs e)
        {

        }

        private void var6_TextChanged(object sender, EventArgs e)
        {

        }

        private void var7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text=="Fan 1")
            {
                fan = 1;
            }
            if (comboBox1.Text == "Fan 2")
            {
                fan = 2;
            }
            if (comboBox1.Text == "Fan 3")
            {
                fan = 3;
            }
            if (comboBox1.Text == "Fan 4")
            {
                fan = 4;
            }
            if (comboBox1.Text == "Fan 5")
            {
                fan = 5;
            }
            if (comboBox1.Text == "Fan 6")
            {
                fan = 6;
            }
            if(comboBox1.Text == "LED Strip 1")
            {
                fan = 7;
            }
            if (comboBox1.Text == "LED Strip 2")
            {
                fan = 8;
            }
            if (comboBox1.Text == "LED Strip 3")
            {
                fan = 9;
            }
            if (comboBox1.Text == "LED Strip 4")
            {
                fan = 10;
            }
        }

        private void stageSet_Click(object sender, EventArgs e)
        {
            fnlCmd = "^" + fan + " 0 " + modeslct +"^" + fan + " 1 " + var1.Text + "^" + fan + " 2 " + var2.Text + "^" + fan + " 3 " + var3.Text + "^" + fan + " 4 " + var4.Text + "^" + fan + " 5 " + var5.Text + "^" + fan + " 6 " + var6.Text + "^" + fan + " 7 " + var7.Text;
            serialPort1.WriteLine(fnlCmd);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fnlCmd = ">" + fan + " 0 " + modeslct + ">" + fan + " 1 " + var1.Text + ">" + fan + " 2 " + var2.Text + ">" + fan + " 3 " + var3.Text + ">" + fan + " 4 " + var4.Text + ">" + fan + " 5 " + var5.Text + ">" + fan + " 6 " + var6.Text + ">" + fan + " 7 " + var7.Text;
            serialPort1.WriteLine(fnlCmd);
            cstCmd.Text = fnlCmd;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("<");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("$");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine(cstCmd.Text);
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox2.Text;
            serialPort1.Open();
        }

        private void eff1_Click(object sender, EventArgs e)
        {
            modeB.Text = effModes[0];
            label1.Enabled = true;
            label1.Visible = true;
            label1.Text = "Effect 1 settings: ";
            lightSelB.Visible = true;
            lightSelB.Enabled = true;
            modeB.Visible = true;
            modeB.Enabled = true;
            selectedEff = 1;
            var1b.Text = eff1v[0];
            var2b.Text = eff1v[1];
            var3b.Text = eff1v[2];
            var4b.Text = eff1v[3];
            var5b.Text = eff1v[4];
            var6b.Text = eff1v[5];
            var7b.Text = eff1v[6];
            TNE.Text = eff1v[8];
            lightSelB.Text = "Fan " + eff1v[9];
            if (eff1isCC)
            {
                checkBox1.Checked = true;
                ccB.Text = eff1s;
            }
            if (!eff1isCC)
            {
                checkBox1.Checked = false;
                ccB.Text = "";
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
                if(selectedEff == 1)
                {
                    if (checkBox1.Checked)
                    {
                        eff1isCC = true;
                    }
                    effModes[0] = modeB.Text;
                    eff1v[7] = Convert.ToString(modeslctb);
                    eff1v[0] = var1b.Text;
                    eff1v[1] = var2b.Text;
                    eff1v[2] = var3b.Text;
                    eff1v[3] = var4b.Text;
                    eff1v[4] = var5b.Text;
                    eff1v[5] = var6b.Text;
                    eff1v[6] = var7b.Text;
                    eff1v[8] = TNE.Text;
                    eff1s = ">" + eff1v[9] + " 0 " + eff1v[7] + ">" + eff1v[9] + " 1 " + eff1v[0] + ">" + eff1v[9] + " 2 " + eff1v[1] + ">" + eff1v[9] + " 3 " + eff1v[2] + ">" + eff1v[9] + " 4 " + eff1v[3] + ">" + eff1v[9] + " 5 " + eff1v[4] + ">" + eff1v[9] + " 6 " + eff1v[5] + ">" + eff1v[9] + " 7 " + eff1v[6];
                    if (eff1isCC)
                    {
                    eff1s = ccB.Text;
                    }
                }
                if (selectedEff == 2)
                {
                    if (checkBox1.Checked)
                    {
                        eff2isCC = true;
                    }
                    effModes[1] = modeB.Text;
                    eff2v[7] = Convert.ToString(modeslctb);
                    eff2v[0] = var1b.Text;
                    eff2v[1] = var2b.Text;
                    eff2v[2] = var3b.Text;
                    eff2v[3] = var4b.Text;
                    eff2v[4] = var5b.Text;
                    eff2v[5] = var6b.Text;
                    eff2v[6] = var7b.Text;
                    eff2v[8] = TNE.Text;
                    eff2s = ">" + eff2v[9] + " 0 " + eff2v[7] + ">" + eff2v[9] + " 1 " + eff2v[0] + ">" + eff2v[9] + " 2 " + eff2v[1] + ">" + eff2v[9] + " 3 " + eff2v[2] + ">" + eff2v[9] + " 4 " + eff2v[3] + ">" + eff2v[9] + " 5 " + eff2v[4] + ">" + eff2v[9] + " 6 " + eff2v[5] + ">" + eff2v[9] + " 7 " + eff2v[6];
                    if (eff2isCC)
                    {
                        eff2s = ccB.Text;
                    }
            }
                if (selectedEff == 3)
                {
                    if (checkBox1.Checked)
                    {
                        eff3isCC = true;
                    }
                    effModes[2] = modeB.Text;
                    eff3v[7] = Convert.ToString(modeslctb);
                    eff3v[0] = var1b.Text;
                    eff3v[1] = var2b.Text;
                    eff3v[2] = var3b.Text;
                    eff3v[3] = var4b.Text;
                    eff3v[4] = var5b.Text;
                    eff3v[5] = var6b.Text;
                    eff3v[6] = var7b.Text;
                    eff3v[8] = TNE.Text;
                    eff3s = ">" + eff3v[9] + " 0 " + eff3v[7] + ">" + eff3v[9] + " 1 " + eff3v[0] + ">" + eff3v[9] + " 2 " + eff3v[1] + ">" + eff3v[9] + " 3 " + eff3v[2] + ">" + eff3v[9] + " 4 " + eff3v[3] + ">" + eff3v[9] + " 5 " + eff3v[4] + ">" + eff3v[9] + " 6 " + eff3v[5] + ">" + eff3v[9] + " 7 " + eff3v[6];
                    if (eff3isCC)
                    {
                        eff3s = ccB.Text;
                    }
                }
                if (selectedEff == 4)
                {
                    if (checkBox1.Checked)
                    {
                        eff4isCC = true;
                    }
                    effModes[3] = modeB.Text;
                    eff4v[7] = Convert.ToString(modeslctb);
                    eff4v[0] = var1b.Text;
                    eff4v[1] = var2b.Text;
                    eff4v[2] = var3b.Text;
                    eff4v[3] = var4b.Text;
                    eff4v[4] = var5b.Text;
                    eff4v[5] = var6b.Text;
                    eff4v[6] = var7b.Text;
                    eff4v[8] = TNE.Text;
                    eff4s = ">" + eff4v[9] + " 0 " + eff4v[7] + ">" + eff4v[9] + " 1 " + eff4v[0] + ">" + eff4v[9] + " 2 " + eff4v[1] + ">" + eff4v[9] + " 3 " + eff4v[2] + ">" + eff4v[9] + " 4 " + eff4v[3] + ">" + eff4v[9] + " 5 " + eff4v[4] + ">" + eff4v[9] + " 6 " + eff4v[5] + ">" + eff4v[9] + " 7 " + eff4v[6];
                    if (eff4isCC)
                    {
                        eff4s = ccB.Text;
                    }
                }
                if (selectedEff == 5)
                {
                    if (checkBox1.Checked)
                    {
                        eff5isCC = true;
                    }
                    effModes[4] = modeB.Text;
                    eff5v[7] = Convert.ToString(modeslctb);
                    eff5v[0] = var1b.Text;
                    eff5v[1] = var2b.Text;
                    eff5v[2] = var3b.Text;
                    eff5v[3] = var4b.Text;
                    eff5v[4] = var5b.Text;
                    eff5v[5] = var6b.Text;
                    eff5v[6] = var7b.Text;
                    eff5v[8] = TNE.Text;
                    eff5s = ">" + eff5v[9] + " 0 " + eff5v[7] + ">" + eff5v[9] + " 1 " + eff5v[0] + ">" + eff5v[9] + " 2 " + eff5v[1] + ">" + eff5v[9] + " 3 " + eff5v[2] + ">" + eff5v[9] + " 4 " + eff5v[3] + ">" + eff5v[9] + " 5 " + eff5v[4] + ">" + eff5v[9] + " 6 " + eff5v[5] + ">" + eff5v[9] + " 7 " + eff5v[6];
                    if (eff5isCC)
                    {
                        eff5s = ccB.Text;
                    }
                }
                if (selectedEff == 6)
                {
                    if (checkBox1.Checked)
                    {
                        eff6isCC = true;
                    }
                    effModes[5] = modeB.Text;
                    eff6v[7] = Convert.ToString(modeslctb);
                    eff6v[0] = var1b.Text;
                    eff6v[1] = var2b.Text;
                    eff6v[2] = var3b.Text;
                    eff6v[3] = var4b.Text;
                    eff6v[4] = var5b.Text;
                    eff6v[5] = var6b.Text;
                    eff6v[6] = var7b.Text;
                    eff6v[8] = TNE.Text;
                    eff6s = ">" + eff6v[9] + " 0 " + eff6v[7] + ">" + eff6v[9] + " 1 " + eff6v[0] + ">" + eff6v[9] + " 2 " + eff6v[1] + ">" + eff6v[9] + " 3 " + eff6v[2] + ">" + eff6v[9] + " 4 " + eff6v[3] + ">" + eff6v[9] + " 5 " + eff6v[4] + ">" + eff6v[9] + " 6 " + eff6v[5] + ">" + eff6v[9] + " 7 " + eff6v[6];
                    if (eff6isCC)
                    {
                        eff6s = ccB.Text;
                    }
                }
                if (selectedEff == 7)
                {
                    if (checkBox1.Checked)
                    {
                        eff7isCC = true;
                    }
                    effModes[6] = modeB.Text;
                    eff7v[7] = Convert.ToString(modeslctb);
                    eff7v[0] = var1b.Text;
                    eff7v[1] = var2b.Text;
                    eff7v[2] = var3b.Text;
                    eff7v[3] = var4b.Text;
                    eff7v[4] = var5b.Text;
                    eff7v[5] = var6b.Text;
                    eff7v[6] = var7b.Text;
                    eff7v[8] = TNE.Text;
                    eff7s = ">" + eff7v[9] + " 0 " + eff7v[7] + ">" + eff7v[9] + " 1 " + eff7v[0] + ">" + eff7v[9] + " 2 " + eff7v[1] + ">" + eff7v[9] + " 3 " + eff7v[2] + ">" + eff7v[9] + " 4 " + eff7v[3] + ">" + eff7v[9] + " 5 " + eff7v[4] + ">" + eff7v[9] + " 6 " + eff7v[5] + ">" + eff7v[9] + " 7 " + eff7v[6];
                    if (eff7isCC)
                    {
                        eff7s = ccB.Text;
                    }
                }
                if (selectedEff == 8)
                {
                    if (checkBox1.Checked)
                    {
                        eff8isCC = true;
                    }
                    effModes[7] = modeB.Text;
                    eff8v[7] = Convert.ToString(modeslctb);
                    eff8v[0] = var1b.Text;
                    eff8v[1] = var2b.Text;
                    eff8v[2] = var3b.Text;
                    eff8v[3] = var4b.Text;
                    eff8v[4] = var5b.Text;
                    eff8v[5] = var6b.Text;
                    eff8v[6] = var7b.Text;
                    eff8v[8] = TNE.Text;
                    eff8s = ">" + eff8v[9] + " 0 " + eff8v[7] + ">" + eff8v[9] + " 1 " + eff8v[0] + ">" + eff8v[9] + " 2 " + eff8v[1] + ">" + eff8v[9] + " 3 " + eff8v[2] + ">" + eff8v[9] + " 4 " + eff8v[3] + ">" + eff8v[9] + " 5 " + eff8v[4] + ">" + eff8v[9] + " 6 " + eff8v[5] + ">" + eff8v[9] + " 7 " + eff8v[6];
                    if (eff8isCC)
                    {
                        eff8s = ccB.Text;
                    }
                }
                if (selectedEff == 9)
                {
                    if (checkBox1.Checked)
                    {
                        eff9isCC = true;
                    }
                    effModes[8] = modeB.Text;
                    eff9v[7] = Convert.ToString(modeslctb);
                    eff9v[0] = var1b.Text;
                    eff9v[1] = var2b.Text;
                    eff9v[2] = var3b.Text;
                    eff9v[3] = var4b.Text;
                    eff9v[4] = var5b.Text;
                    eff9v[5] = var6b.Text;
                    eff9v[6] = var7b.Text;
                    eff9v[8] = TNE.Text;
                    eff9s = ">" + eff9v[9] + " 0 " + eff9v[7] + ">" + eff9v[9] + " 1 " + eff9v[0] + ">" + eff9v[9] + " 2 " + eff9v[1] + ">" + eff9v[9] + " 3 " + eff9v[2] + ">" + eff9v[9] + " 4 " + eff9v[3] + ">" + eff9v[9] + " 5 " + eff9v[4] + ">" + eff9v[9] + " 6 " + eff9v[5] + ">" + eff9v[9] + " 7 " + eff9v[6];
                    if (eff9isCC)
                    {
                        eff9s = ccB.Text;
                    }
                }
                if (selectedEff == 10)
                {
                    if (checkBox1.Checked)
                    {
                        eff10isCC = true;
                    }
                    effModes[9] = modeB.Text;
                    eff10v[7] = Convert.ToString(modeslctb);
                    eff10v[0] = var1b.Text;
                    eff10v[1] = var2b.Text;
                    eff10v[2] = var3b.Text;
                    eff10v[3] = var4b.Text;
                    eff10v[4] = var5b.Text;
                    eff10v[5] = var6b.Text;
                    eff10v[6] = var7b.Text;
                    eff10v[8] = TNE.Text;
                    eff10s = ">" + eff10v[9] + " 0 " + eff10v[7] + ">" + eff10v[9] + " 1 " + eff10v[0] + ">" + eff10v[9] + " 2 " + eff10v[1] + ">" + eff10v[9] + " 3 " + eff10v[2] + ">" + eff10v[9] + " 4 " + eff10v[3] + ">" + eff10v[9] + " 5 " + eff10v[4] + ">" + eff10v[9] + " 6 " + eff10v[5] + ">" + eff10v[9] + " 7 " + eff10v[6];
                    if (eff10isCC)
                    {
                        eff10s = ccB.Text;
                    }
                }
                if (selectedEff == 11)
                {
                    if (checkBox1.Checked)
                    {
                        eff11isCC = true;
                    }
                    effModes[10] = modeB.Text;
                    eff11v[7] = Convert.ToString(modeslctb);
                    eff11v[0] = var1b.Text;
                    eff11v[1] = var2b.Text;
                    eff11v[2] = var3b.Text;
                    eff11v[3] = var4b.Text;
                    eff11v[4] = var5b.Text;
                    eff11v[5] = var6b.Text;
                    eff11v[6] = var7b.Text;
                    eff11v[8] = TNE.Text;
                    eff11s = ">" + eff11v[9] + " 0 " + eff11v[7] + ">" + eff11v[9] + " 1 " + eff11v[0] + ">" + eff11v[9] + " 2 " + eff11v[1] + ">" + eff11v[9] + " 3 " + eff11v[2] + ">" + eff11v[9] + " 4 " + eff11v[3] + ">" + eff11v[9] + " 5 " + eff11v[4] + ">" + eff11v[9] + " 6 " + eff11v[5] + ">" + eff11v[9] + " 7 " + eff11v[6];
                    if (eff11isCC)
                    {
                        eff11s = ccB.Text;
                    }
                }
                if (selectedEff == 12)
                {
                    if (checkBox1.Checked)
                    {
                        eff12isCC = true;
                    }
                    effModes[10] = modeB.Text;
                    eff12v[7] = Convert.ToString(modeslctb);
                    eff12v[0] = var1b.Text;
                    eff12v[1] = var2b.Text;
                    eff12v[2] = var3b.Text;
                    eff12v[3] = var4b.Text;
                    eff12v[4] = var5b.Text;
                    eff12v[5] = var6b.Text;
                    eff12v[6] = var7b.Text;
                    eff12v[8] = TNE.Text;
                    eff12s = ">" + eff12v[9] + " 0 " + eff12v[7] + ">" + eff12v[9] + " 1 " + eff12v[0] + ">" + eff12v[9] + " 2 " + eff12v[1] + ">" + eff12v[9] + " 3 " + eff12v[2] + ">" + eff12v[9] + " 4 " + eff12v[3] + ">" + eff12v[9] + " 5 " + eff12v[4] + ">" + eff12v[9] + " 6 " + eff12v[5] + ">" + eff12v[9] + " 7 " + eff12v[6];
                    if (eff12isCC)
                    {
                        eff12s = ccB.Text;
                    }
                }
        }

        private void var1b_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ccB.BackColor = Color.White;
                ccB.Enabled = true;
                if (selectedEff == 1)
                {
                    eff1isCC = true;
                }
                if (selectedEff == 2)
                {
                    eff2isCC = true;
                }
                if (selectedEff == 3)
                {
                    eff3isCC = true;
                }
                if (selectedEff == 4)
                {
                    eff4isCC = true;
                }
                if (selectedEff == 5)
                {
                    eff5isCC = true;
                }
                if (selectedEff == 6)
                {
                    eff6isCC = true;
                }
                if (selectedEff == 7)
                {
                    eff7isCC = true;
                }
                if (selectedEff == 8)
                {
                    eff8isCC = true;
                }
                if (selectedEff == 9)
                {
                    eff9isCC = true;
                }
                if (selectedEff == 10)
                {
                    eff10isCC = true;
                }
                if (selectedEff == 11)
                {
                    eff11isCC = true;
                }
                if (selectedEff == 12)
                {
                    eff12isCC = true;
                }
            }
            if (!checkBox1.Checked)
            {
                ccB.BackColor = Color.Gray;
                ccB.Enabled = false;
                if (selectedEff == 1)
                {
                    eff1isCC = false;
                }
                if (selectedEff == 2)
                {
                    eff2isCC = false;
                }
                if (selectedEff == 3)
                {
                    eff3isCC = false;
                }
                if (selectedEff == 4)
                {
                    eff4isCC = false;
                }
                if (selectedEff == 5)
                {
                    eff5isCC = false;
                }
                if (selectedEff == 6)
                {
                    eff6isCC = false;
                }
                if (selectedEff == 7)
                {
                    eff7isCC = false;
                }
                if (selectedEff == 8)
                {
                    eff8isCC = false;
                }
                if (selectedEff == 9)
                {
                    eff9isCC = false;
                }
                if (selectedEff == 10)
                {
                    eff10isCC = false;
                }
                if (selectedEff == 11)
                {
                    eff11isCC = false;
                }
                if (selectedEff == 12)
                {
                    eff12isCC = false;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            modeB.Text = effModes[2];
            label1.Enabled = true;
            label1.Visible = true;
            label1.Text = "Effect 3 settings: ";
            lightSelB.Visible = true;
            lightSelB.Enabled = true;
            modeB.Visible = true;
            modeB.Enabled = true;
            selectedEff = 3;
            var1b.Text = eff3v[0];
            var2b.Text = eff3v[1];
            var3b.Text = eff3v[2];
            var4b.Text = eff3v[3];
            var5b.Text = eff3v[4];
            var6b.Text = eff3v[5];
            var7b.Text = eff3v[6];
            TNE.Text = eff3v[8];
            lightSelB.Text = "Fan " + eff3v[9];
            if (eff3isCC)
            {
                checkBox1.Checked = true;
                ccB.Text = eff3s;
            }
            if (!eff3isCC)
            {
                checkBox1.Checked = false;
                ccB.Text = "";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            modeB.Text = effModes[5];
            label1.Enabled = true;
            label1.Visible = true;
            label1.Text = "Effect 6 settings: ";
            lightSelB.Visible = true;
            lightSelB.Enabled = true;
            modeB.Visible = true;
            modeB.Enabled = true;
            selectedEff = 6;
            var1b.Text = eff6v[0];
            var2b.Text = eff6v[1];
            var3b.Text = eff6v[2];
            var4b.Text = eff6v[3];
            var5b.Text = eff6v[4];
            var6b.Text = eff6v[5];
            var7b.Text = eff6v[6];
            TNE.Text = eff6v[8];
            lightSelB.Text = "Fan " + eff6v[9];
            if (eff6isCC)
            {
                checkBox1.Checked = true;
                ccB.Text = eff6s;
            }
            if (!eff6isCC)
            {
                checkBox1.Checked = false;
                ccB.Text = "";
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            TNE.Enabled = true;
            TNE.Visible = true;
            label10.Visible = true;
            label10.Enabled = true;
            var1lb.Enabled = false;
            var1lb.Visible = false;
            var1b.Enabled = false;
            var1b.Visible = false;
            var2lb.Enabled = false;
            var2lb.Visible = false;
            var2b.Enabled = false;
            var2b.Visible = false;
            var3lb.Enabled = false;
            var3lb.Visible = false;
            var3b.Enabled = false;
            var3b.Visible = false;
            var4lb.Enabled = false;
            var4lb.Visible = false;
            var4b.Enabled = false;
            var4b.Visible = false;
            var5lb.Enabled = false;
            var5lb.Visible = false;
            var5b.Enabled = false;
            var5b.Visible = false;
            var6lb.Enabled = false;
            var6lb.Visible = false;
            var6b.Enabled = false;
            var6b.Visible = false;
            var7lb.Enabled = false;
            var7lb.Visible = false;
            var7b.Enabled = false;
            var7b.Visible = false;
            modeslctb = 0;
            if (modeB.Text == "Solid")
            {
                var1lb.Text = "Red Value";
                var1lb.Enabled = true;
                var1lb.Visible = true;
                var1b.Enabled = true;
                var1b.Visible = true;
                var2lb.Text = "Green Value";
                var2lb.Enabled = true;
                var2lb.Visible = true;
                var2b.Enabled = true;
                var2b.Visible = true;
                var3lb.Text = "Blue Value";
                var3lb.Enabled = true;
                var3lb.Visible = true;
                var3b.Enabled = true;
                var3b.Visible = true;
                modeslctb = 9;
            }
            if (modeB.Text == "Hue Shift")
            {
                var1lb.Text = "Starting Hue";
                var1lb.Enabled = true;
                var1lb.Visible = true;
                var1b.Enabled = true;
                var1b.Visible = true;
                var2lb.Text = "Ending Hue";
                var2lb.Enabled = true;
                var2lb.Visible = true;
                var2b.Enabled = true;
                var2b.Visible = true;
                var3lb.Text = "Hue Offset";
                var3lb.Enabled = true;
                var3lb.Visible = true;
                var3b.Enabled = true;
                var3b.Visible = true;
                var5lb.Text = "Phase Offset";
                var5lb.Enabled = true;
                var5lb.Visible = true;
                var5b.Enabled = true;
                var5b.Visible = true;
                var7lb.Text = "Rate";
                var7lb.Enabled = true;
                var7lb.Visible = true;
                var7b.Enabled = true;
                var7b.Visible = true;
                modeslctb = 0;
            }
            if (modeB.Text == "Single-Point Spinner")
            {
                var1lb.Text = "Hue";
                var1lb.Enabled = true;
                var1lb.Visible = true;
                var1b.Enabled = true;
                var1b.Visible = true;
                var2lb.Text = "0/1 = CW/CCW";
                var2lb.Enabled = true;
                var2lb.Visible = true;
                var2b.Enabled = true;
                var2b.Visible = true;
                var3lb.Text = "0/1 = Hue/Rainbow";
                var3lb.Enabled = true;
                var3lb.Visible = true;
                var3b.Enabled = true;
                var3b.Visible = true;
                var4lb.Text = "Rainbow change rate";
                var4lb.Enabled = true;
                var4lb.Visible = true;
                var4b.Enabled = true;
                var4b.Visible = true;
                var5lb.Text = "Offset";
                var5lb.Enabled = true;
                var5lb.Visible = true;
                var5b.Enabled = true;
                var5b.Visible = true;
                var6lb.Text = "Fade Speed";
                var6lb.Enabled = true;
                var6lb.Visible = true;
                var6b.Enabled = true;
                var6b.Visible = true;
                var7lb.Text = "Spin Speed";
                var7lb.Enabled = true;
                var7lb.Visible = true;
                var7b.Enabled = true;
                var7b.Visible = true;
                modeslctb = 1;
            }
            if (modeB.Text == "Two-Point Spinner")
            {
                var1lb.Text = "Hue";
                var1lb.Enabled = true;
                var1lb.Visible = true;
                var1b.Enabled = true;
                var1b.Visible = true;
                var2lb.Text = "0/1 = CW/CCW";
                var2lb.Enabled = true;
                var2lb.Visible = true;
                var2b.Enabled = true;
                var2b.Visible = true;
                var3lb.Text = "0/1 = Hue/Rainbow";
                var3lb.Enabled = true;
                var3lb.Visible = true;
                var3b.Enabled = true;
                var3b.Visible = true;
                var4lb.Text = "Rainbow change rate";
                var4lb.Enabled = true;
                var4lb.Visible = true;
                var4b.Enabled = true;
                var4b.Visible = true;
                var5lb.Text = "Hue shift";
                var5lb.Enabled = true;
                var5lb.Visible = true;
                var5b.Enabled = true;
                var5b.Visible = true;
                var6lb.Text = "Fade Speed";
                var6lb.Enabled = true;
                var6lb.Visible = true;
                var6b.Enabled = true;
                var6b.Visible = true;
                var7lb.Text = "Spin Speed";
                var7lb.Enabled = true;
                var7lb.Visible = true;
                var7b.Enabled = true;
                var7b.Visible = true;
                modeslctb = 5;
            }
            if (modeB.Text == "Four-Point Spinner")
            {
                var1lb.Text = "Hue";
                var1lb.Enabled = true;
                var1lb.Visible = true;
                var1b.Enabled = true;
                var1b.Visible = true;
                var2lb.Text = "0/1 = CW/CCW";
                var2lb.Enabled = true;
                var2lb.Visible = true;
                var2b.Enabled = true;
                var2b.Visible = true;
                var3lb.Text = "0/1 = Hue/Rainbow";
                var3lb.Enabled = true;
                var3lb.Visible = true;
                var3b.Enabled = true;
                var3b.Visible = true;
                var4lb.Text = "Rainbow change rate";
                var4lb.Enabled = true;
                var4lb.Visible = true;
                var4b.Enabled = true;
                var4b.Visible = true;
                var5lb.Text = "Hue shift";
                var5lb.Enabled = true;
                var5lb.Visible = true;
                var5b.Enabled = true;
                var5b.Visible = true;
                var6lb.Text = "Fade Speed";
                var6lb.Enabled = true;
                var6lb.Visible = true;
                var6b.Enabled = true;
                var6b.Visible = true;
                var7lb.Text = "Spin Speed";
                var7lb.Enabled = true;
                var7lb.Visible = true;
                var7b.Enabled = true;
                var7b.Visible = true;
                modeslctb = 3;
            }
            if (modeB.Text == "Rainbow span across LEDs")
            {
                var1lb.Text = "Sparkle chance";
                var1lb.Enabled = true;
                var1lb.Visible = true;
                var1b.Enabled = true;
                var1b.Visible = true;
                var2lb.Text = "Hue step per LED";
                var2lb.Enabled = true;
                var2lb.Visible = true;
                var2b.Enabled = true;
                var2b.Visible = true;
                var7lb.Text = "Spin Speed";
                var7lb.Enabled = true;
                var7lb.Visible = true;
                var7b.Enabled = true;
                var7b.Visible = true;
                modeslctb = 2;
            }
            if (modeB.Text == "Double Scan")
            {
                var1lb.Text = "Hue";
                var1lb.Enabled = true;
                var1lb.Visible = true;
                var1b.Enabled = true;
                var1b.Visible = true;
                var2lb.Text = "Rotation Offset";
                var2lb.Enabled = true;
                var2lb.Visible = true;
                var2b.Enabled = true;
                var2b.Visible = true;
                var3lb.Text = "0/1 = Hue/Rainbow";
                var3lb.Enabled = true;
                var3lb.Visible = true;
                var3b.Enabled = true;
                var3b.Visible = true;
                var4lb.Text = "Rainbow change rate";
                var4lb.Enabled = true;
                var4lb.Visible = true;
                var4b.Enabled = true;
                var4b.Visible = true;
                var5lb.Text = "Hue shift";
                var5lb.Enabled = true;
                var5lb.Visible = true;
                var5b.Enabled = true;
                var5b.Visible = true;
                var6lb.Text = "Fade Speed";
                var6lb.Enabled = true;
                var6lb.Visible = true;
                var6b.Enabled = true;
                var6b.Visible = true;
                var7lb.Text = "Spin Speed";
                var7lb.Enabled = true;
                var7lb.Visible = true;
                var7b.Enabled = true;
                var7b.Visible = true;
                modeslctb = 4;
            }
            if (modeB.Text == "BPM Mode")
            {
                var1lb.Text = "Hue Multiplier";
                var1lb.Enabled = true;
                var1lb.Visible = true;
                var1b.Enabled = true;
                var1b.Visible = true;
                var2lb.Text = "Beat Multiplier";
                var2lb.Enabled = true;
                var2lb.Visible = true;
                var2b.Enabled = true;
                var2b.Visible = true;
                var7lb.Text = "Rate";
                var7lb.Enabled = true;
                var7lb.Visible = true;
                var7b.Enabled = true;
                var7b.Visible = true;
                modeslctb = 6;
            }
            if (modeB.Text == "Split Sides")
            {
                var1lb.Text = "West Hue";
                var1lb.Enabled = true;
                var1lb.Visible = true;
                var1b.Enabled = true;
                var1b.Visible = true;
                var2lb.Text = "East Hue";
                var2lb.Enabled = true;
                var2lb.Visible = true;
                var2b.Enabled = true;
                var2b.Visible = true;
                var4lb.Text = "Fan pulse offset";
                var4lb.Enabled = true;
                var4lb.Visible = true;
                var4b.Enabled = true;
                var4b.Visible = true;
                var5lb.Text = "Side pulse offset";
                var5lb.Enabled = true;
                var5lb.Visible = true;
                var5b.Enabled = true;
                var5b.Visible = true;
                var6lb.Text = "Pulse Type";
                var6lb.Enabled = true;
                var6lb.Visible = true;
                var6b.Enabled = true;
                var6b.Visible = true;
                var7lb.Text = "Pulse Rate";
                var7lb.Enabled = true;
                var7lb.Visible = true;
                var7b.Enabled = true;
                var7b.Visible = true;
                modeslct = 7;
            }
            if (modeB.Text == "Split Quarters")
            {
                var1lb.Text = "NW Hue";
                var1lb.Enabled = true;
                var1lb.Visible = true;
                var1b.Enabled = true;
                var1b.Visible = true;
                var2lb.Text = "NE Hue";
                var2lb.Enabled = true;
                var2lb.Visible = true;
                var2b.Enabled = true;
                var2b.Visible = true;
                var3lb.Text = "SE Hue";
                var3lb.Enabled = true;
                var3lb.Visible = true;
                var3b.Enabled = true;
                var3b.Visible = true;
                var4lb.Text = "SW Hue";
                var4lb.Enabled = true;
                var4lb.Visible = true;
                var4b.Enabled = true;
                var4b.Visible = true;
                var5lb.Text = "Side pulse offset";
                var5lb.Enabled = true;
                var5lb.Visible = true;
                var5b.Enabled = true;
                var5b.Visible = true;
                var6lb.Text = "Pulse Type";
                var6lb.Enabled = true;
                var6lb.Visible = true;
                var6b.Enabled = true;
                var6b.Visible = true;
                var7lb.Text = "Pulse Rate";
                var7lb.Enabled = true;
                var7lb.Visible = true;
                var7b.Enabled = true;
                var7b.Visible = true;
                modeslctb = 8;
            }
            if (modeB.Text == "Fade to Black")
            {
                var1lb.Text = "Fade Rate";
                var1lb.Enabled = true;
                var1lb.Visible = true;
                var1b.Enabled = true;
                var1b.Visible = true;
                modeslctb = 10;
            }
        }

        private void eff2on_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
