using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5pflab
{
    public class Studentfortask1
    {
        public string name;
        public string age;
        public int fscmarks;
        public int Ecatmarks;
        public int Matricmarks;
        public string rool_no;
        public float cgpa;
        public string hometown;
        public float merit;
        public string hostile_status;
       public Studentfortask1(string name,string age,int fscmarks,int Ecatmarks,int Matricmarks,string rool_no,float cgpa,string hometown,string hostile_status)
       {
            this.name = name;
            this.age = age;
            this.fscmarks = fscmarks;
            this.Ecatmarks = Ecatmarks;
            this.Matricmarks = Matricmarks;
            this.rool_no = rool_no;
            this.cgpa = cgpa;
            this.hometown = hometown;
            this.hostile_status=hostile_status;
       }
        public Studentfortask1()           
        {

        }
        public void MeritCalculator()
        {
            merit = ((fscmarks * 100 / 1100) * 0.6f + (Ecatmarks * 100 / 400) * 0.4f);
        }
        public void ShowMerit()
        {
            Console.WriteLine("Merit of " + name + " is " + merit);
        }

        public bool EligibilityforScholarship()
        {
            bool flag = false;
            if(merit>=80.00f)
            {
                flag = true;
            }
            return flag;
        }
        public Studentfortask1 CheckExsistance(List<Studentfortask1> students, string name)
        {
            foreach (Studentfortask1 student in students)
            {
                if (student.name == name)
                {
                    return student;
                }
            }
            return null;
        }
    }
}

