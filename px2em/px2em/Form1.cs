using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace px2em
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            doTrans();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBodyEM.ReadOnly)
            {
                txtBodyEM.ReadOnly = false;
                txtPXNew.ReadOnly = false;
                txtPXOld.ReadOnly = false;
            }
            else
            {
                txtBodyEM.ReadOnly = true;
                txtPXNew.ReadOnly = true;
                txtPXOld.ReadOnly = true;
            }
        }

        private void doTrans()
        {

            float bodyem = getContext(txtBodyEM.Text.Trim(), 0);
            float px = getContext(txtPX.Text.Trim(), 0);
            float resultem = 0;
            resultem = bodyem / 16 * px;
            txtResultEM.Text = Math.Round(resultem, 2).ToString();

            float oldpx = getContext(txtPXOld.Text.Trim(), 0);
            float newpx = getContext(txtPXNew.Text.Trim(), 0);
            float resultpercent = 0;
            resultpercent = px / oldpx * 100;
            txtPercent.Text = Math.Round(resultpercent, 2).ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private float getContext(string obj, float defaultresult)
        {
            float result = 0;
            if (IsFloat(obj))
            {
                result = float.Parse(obj.Trim());
            }
            else
                result = defaultresult;
            return result;
        }

        //判断字符串是否为浮点数
        public static bool IsFloat(string str)
        {
            string regextext = @"^(-?\d+)(\.\d+)?$";
            Regex regex = new Regex(regextext, RegexOptions.None);
            return regex.IsMatch(str.Trim());
        }
    }
}
