using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GESTCRM.Formularios
{
    public partial class frmTip : Form
    {
        public frmTip()
        {
            InitializeComponent();
        }

        public new void Show(IWin32Window owner)
        {
            if (Visible)
                return;

            base.Show(owner);
            this.Update();
            Application.DoEvents();
            if (IsWindowsXP())
                while (Opacity < 0.9)
                {
                    Opacity += 0.05;
                    System.Threading.Thread.Sleep(20);
                }            
        }

        public new void Close()
        {
            if (IsWindowsXP())
                while (Opacity > 0)
                {
                    Opacity -= 0.05;
                    System.Threading.Thread.Sleep(20);
                }
            this.Hide();
        }

        private static bool IsWindowsXP()
        {
            return Environment.OSVersion.ToString().Contains("Windows NT 5");
        }
    }
}
