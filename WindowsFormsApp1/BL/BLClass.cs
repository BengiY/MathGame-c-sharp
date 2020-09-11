using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLClass
    {
        TestDBEntities db = new TestDBEntities();
        public bool Exist(string u,int p)
        {
            var answer = db.Users.Where(x => x.UserName == u && x.Userpassword == p).Select(x=>x.UserName).Any();
            if (answer)
            {
                return true;
            }
            else
                return false;
        }
        Questions l;
       List< Answers> a;
        public Questions exerciseReturnTen()
        {
            l = db.Questions.Where(y=>y.ID<11&&y.Percent==10).Select(y => y).OrderBy(y => Guid.NewGuid()).FirstOrDefault();
            return l;
        }
        public Questions exerciseReturnSix()
        {
            l = db.Questions.Where(y => y.ID <11 && y.Percent == 6).Select(y => y).OrderBy(y => Guid.NewGuid()).FirstOrDefault();
            return l;
        }
        public Questions exerciseAmerican()
        {
            l = db.Questions.Where(y => y.ID > 11).Select(y => y).OrderBy(y => Guid.NewGuid()).FirstOrDefault();
            return l;
        }
        public List<Answers> answersAmerican(int id)
        {
            a=db.Answers.Where(y => y.QuestionID == id).ToList();
            return a;
        }


        public void AddHistory(int m,int uP)
        {
            //db.Answers.Add(new Answers() { ID = 9000, AnswerValue = 2, QuestionID = 12 });
            //db.SaveChanges();
            using (var DB=new TestDBEntities())
            {
                History history = new History
                {
                    Userpassword = uP,
                    TestDate =DateTime.Now,
                    Mark = m
                };
                db.History.Add(history);
                db.SaveChanges();
            }
            //DateTime d = DateTime.Now;            
        }
    }
}
