using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CustomMsgBox
{
    public partial class frmMsgBox : Form
    {
        //public static DialogResult DialogResult;
        public frmMsgBox()
        {
            InitializeComponent();
            Width = SystemInformation.WorkingArea.Width;
        }

        internal enum enumMessageButton
        {
            OK, YesNo, RetryCancel
        }

        internal enum enumMessageIcon
        {
            Error, Warning, Information, Question
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;
            LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Navy, Color.Navy, 60);
            e.Graphics.FillRectangle(brush, rect);
            base.OnPaint(e);
        }

        private void setMessage(string Message)
        {
            //int number = Math.Abs(Message.Length / 30);
            //if (number != 0)
            //{ this.lblMessage.Height = number * 25; }
            this.lblMessage.Text = Message;
        }

        private void addButton(enumMessageButton MessageButton)
        {
            int btnTop = pnlMain.Height - 40;
            int btnWidth = 100; int btnHeight = 35;
            switch (MessageButton)
            {
                case enumMessageButton.OK:
                    {
                        Button btnOK = new Button();
                        btnOK.Text = "OK";
                        btnOK.DialogResult = DialogResult.OK;
                        btnOK.SetBounds(pnlMain.Width - 120, btnTop, btnWidth, btnHeight);
                        this.pnlMain.Controls.Add(btnOK);
                    }
                    break;
                case enumMessageButton.YesNo:
                    {
                        Button btnYes = new Button();
                        btnYes.Text = "Ya";
                        btnYes.DialogResult = DialogResult.Yes;
                        btnYes.SetBounds(pnlMain.Width - 240, btnTop, btnWidth, btnHeight);
                        pnlMain.Controls.Add(btnYes);

                        Button btnNo = new Button();
                        btnNo.Text = "Tidak";
                        btnNo.DialogResult = DialogResult.No;
                        btnNo.SetBounds(pnlMain.Width - 120, btnTop, btnWidth, btnHeight);
                        pnlMain.Controls.Add(btnNo);
                        
                    }
                    break;
                case enumMessageButton.RetryCancel:
                    {
                        Button btnRetry = new Button();
                        btnRetry.Text = "Coba Lagi";
                        btnRetry.DialogResult = DialogResult.Retry;
                        btnRetry.SetBounds(pnlMain.Width - 240, btnTop, btnWidth, btnHeight);
                        pnlMain.Controls.Add(btnRetry);

                        Button btnCancel = new Button();
                        btnCancel.Text = "Batal";
                        btnCancel.DialogResult = DialogResult.Retry;
                        btnRetry.SetBounds(pnlMain.Width - 120, btnTop, btnWidth, btnHeight);
                        pnlMain.Controls.Add(btnCancel);
                                       
                    }
                    break;
            }
        }

        private void AddIconImage(enumMessageIcon MessageIcon)
        {
            switch (MessageIcon)
            {
                case enumMessageIcon.Error:
                    PicIcon.Image = ImgList.Images["error"];
                    break;

                case enumMessageIcon.Information:
                    PicIcon.Image = ImgList.Images["appbar.information.png"];
                    //MyComputer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation);
                    break;

            }
        }

        internal static DialogResult View(string Message, string Title, enumMessageIcon Icon, enumMessageButton Button)
        {
            frmMsgBox MsgBox = new frmMsgBox();
            MsgBox.lblTitle.Text = Title;
            MsgBox.setMessage(Message);
            MsgBox.AddIconImage(Icon);
            MsgBox.addButton(Button);
            MsgBox.ShowDialog();

            return MsgBox.DialogResult;
        }


        private void frmMsgBox_Load(object sender, EventArgs e)
        {

        }

    }
}
