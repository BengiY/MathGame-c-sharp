using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class TestF : Form
    {
       
        int markCnt =0;
        int cnt=1;
        int cntAmerican = 0;
        BLClass bl = new BLClass();
        Questions l;
        List<Answers> a;
        List<string> LT =new List<string>();
        List<string> LS = new List<string>();
        public int UserP { get; set; }

        public TestF(int u)
        {
            InitializeComponent();
            l = bl.exerciseReturnTen();
            exercise.Text = l.QuestionText;
            UserP = u;
            LT.Add(l.QuestionText);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            cnt++;
         
            if (Int32.Parse(UserAnswer.Text) == l.QuestionAnswer)
            {
                markCnt += l.Percent.Value;
                mark.Text = markCnt.ToString();
                UserAnswer.Text = "";
            }
            else
            {
                UserAnswer.Text = "";
            }
            if (cnt <= 5)
            {
                l = bl.exerciseReturnTen();
                while (LT.Contains(l.QuestionText))
                {
                    l = bl.exerciseReturnTen();
                }
                LT.Add(l.QuestionText);
                exercise.Text = l.QuestionText;
            }
            else if(cnt>5&&cnt<=9)
            {
                l = bl.exerciseReturnSix();
                while (LS.Contains(l.QuestionText))
                { 
                l = bl.exerciseReturnSix();
                }
                LS.Add(l.QuestionText);
                exercise.Text = l.QuestionText;
            }
            else
            {
                button1.Visible = false;
                americanStart.Visible = true;
                UserAnswer.Visible = false;
                exercise.Text = "";
            }
        

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(UserAnswer.Text) == l.QuestionAnswer)
            {
                markCnt += l.Percent.Value;
                mark.Text = markCnt.ToString();
                UserAnswer.Text = "";
            }
            else
            {
                UserAnswer.Text = "";
            }
            l = bl.exerciseReturnTen();
            exercise.Text = l.QuestionText;
            button1.Visible = true;
            button2.Visible = false;
           
        }

        private void TestF_Load(object sender, EventArgs e)
        {

        }

        private void mark_Click(object sender, EventArgs e)
        {

        }
        private void RandAmericanQ()
        {
            l = bl.exerciseAmerican();
            a = bl.answersAmerican(l.ID);
            for (int i = 0; i < a.Count(); i++)
            {
                for (int j = i; j < this.Controls.OfType<RadioButton>().Count(); j++)
                {
                    Controls.OfType<RadioButton>().ToList()[i].Text = a[i].AnswerValue.ToString();
                    break;
                }
            }
            exercise.Text = l.QuestionText;
        }
        private void checkFuction()
        {
            RadioButton buttonCheck = this.Controls.OfType<RadioButton>()
               .Where(n => n.Checked).FirstOrDefault();
            if (buttonCheck.Text == a[1].AnswerValue.ToString())
            {
                markCnt += l.Percent.Value;
                mark.Text = markCnt.ToString();
                buttonCheck.Checked = false;
            }
        }

        private void americanStart_Click(object sender, EventArgs e)
        {
            foreach (RadioButton rBtn in this.Controls.OfType<RadioButton>())
            {
                rBtn.Visible = true;
            }
            cntAmerican++;
            RandAmericanQ();
            americanStart.Visible = false;
            CAmerican.Visible = true;
        }

        private void CAmerican_Click(object sender, EventArgs e)
        {
        if (cntAmerican >= 1 && cntAmerican <= 5)
        {
            checkFuction();
            RandAmericanQ();
            cntAmerican++;
        }
            else
            {
                CAmerican.Visible = false;
                end.Visible = true;
            }
    }

        private void end_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ציונך הכולל: "+ markCnt);
            bl.AddHistory(markCnt,UserP);
        }
    }
}

