using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string u;
        int p;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            u = UserNameT.Text;
            p = Int32.Parse(PasswordT.Text);
            BLClass bl = new BLClass();
            //bl.uP = Int32.Parse(u);
           bool x= bl.Exist(u,p);
            if (x)
            {
                MessageBox.Show("ברוכים הבאים");
                bl.AddHistory(5, 1234);
                TestF t = new TestF(p);
                t.Show();
            }
            else
                MessageBox.Show("הפרטים שגויים");
            u = null;
            p = 0;
            UserNameT.Text = "";
            PasswordT.Text = "";
        }
    }
}
