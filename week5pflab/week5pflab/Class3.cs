using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5pflab
{
    public class Subject
    {
        public int Subject_Code;
        public string Subject_Name;
        public int Subject_Credit;
        public int Subject_Fee;
        public Subject(int Subject_Code,string Subject_Name,int Subject_Credit,int Subject_Fee)
        {
            this.Subject_Code = Subject_Code;
            this.Subject_Name = Subject_Name;
            this.Subject_Credit = Subject_Credit;
            this.Subject_Fee = Subject_Fee;
        }
        
    }
}
