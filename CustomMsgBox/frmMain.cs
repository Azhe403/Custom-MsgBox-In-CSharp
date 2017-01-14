using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomMsgBox
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //frmMsgBox.Show("Test Message", "Title", frmMsgBox.enumMessageIcon.Information, frmMsgBox.enumMessageButton.YesNo);
           label1.Text = "Dialog Result : "+ frmMsgBox.View("Test Message", "Title", frmMsgBox.enumMessageIcon.Information, frmMsgBox.enumMessageButton.OK).ToString();
        }
    }
}
