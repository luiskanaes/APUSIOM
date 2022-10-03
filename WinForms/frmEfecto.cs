using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class frmEfecto : Form
    {
        public frmEfecto()
        {
            InitializeComponent();
        }

        private void frmEfecto_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + .005;
            if (this.Opacity==1)
            {
                
                timer1.Stop();


                this.Hide();

                new frmLogin().ShowDialog();
                this.Close();
            }

        }
    }
}
