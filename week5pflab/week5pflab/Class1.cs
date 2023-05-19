using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5pflab
{
    public class Degree
    {
        public string degree_title;
        public int degree_time;
        public int seats;
        public int Subjects;
        public float minimumAggregate;
        public List<Subject> subjects = new List<Subject>();
        
        public Degree(string degree_name, int degree_duration, int degree_seats, int no_of_subjects)
        {
            degree_title = degree_name;
            degree_time = degree_duration;
            seats = degree_seats;
            Subjects = no_of_subjects;
        }
        public void EnterDetailsOfSubject()
        {
            for (int i = 0; i < Subjects; i++)
            {
                Console.WriteLine("Enter Details of Subject No: " + (i + 1));
                Console.Write("Enter Subject Code ");
                int Subject_Code=int.Parse(Console.ReadLine());
                Console.Write("Enter Subject Name ");
                string Subject_Name=Console.ReadLine();
                Console.Write("Enter Subject Credits ");
                int Subject_Credit=int.Parse(Console.ReadLine());
                Console.Write("Enter Subject Fees ");
                int Subject_Fee= int.Parse(Console.ReadLine());
                Subject subject = new Subject(Subject_Code, Subject_Name, Subject_Credit, Subject_Fee);
                subjects.Add(subject);
            }

        }
        public void SetMinimunAggregate(List<Student> students)
        {
            float set = 0;
            int Student_no=0;
            foreach(Student student in students)
            {
                if(student.prefrences[0]==degree_title)
                {
                    set = set + student.merit;
                    Student_no++;
                }
            }
            minimumAggregate = set/Student_no;
        }
       public string RegisterSubject(Student student,int code)
       {
            int flag = 0;
            if(degree_title==student.discipline)
            {
                for(int i=0;i<subjects.Count;i++)
                {
                    if (subjects[i].Subject_Code==code)
                    {
                        flag++;
                        return subjects[i].Subject_Name;
                    }
                }
                if(flag==0)
                {
                    Console.WriteLine("This Course is not available in " + student.discipline);
                }
                else
                {
                    Console.WriteLine("Your Course is Registered ");
                }
            }
            return null;
       }
    }
}

