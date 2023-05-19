using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5pflab
{
    public class Student
    {
        public string name;
        public int age;
        public float Fsc_marks;
        public float Ecat_marks;
        public int no_of_preferances;
        public List<string> prefrences=new List<string>();
        public string discipline;
        public float merit;
        List<string> registered_Subjects = new List<string>();
        public Student(string name,int age,float fscmarks,float Ecatmarks,int no_of_prefrences)
        {
            this.name = name;
            this.age = age;
            this.Fsc_marks = fscmarks;
            this.Ecat_marks = Ecatmarks;
            this.no_of_preferances = no_of_prefrences;
        }
        public Student()
        {

        }
        public void TakePreferances()
        {
            Console.WriteLine("Enter Your Priority List Here ");
            for(int i=0;i<no_of_preferances;i++)
            {
                prefrences.Add(Console.ReadLine());
            }
        }
        public void MeritCalculator()
        {
            merit = ((Fsc_marks*100/1100) * 0.6f + (Ecat_marks*100/400) * 0.4f);
        }
        public void AsignDisicipline(List<Degree> degrees,int preference_no)
        {
            foreach(Degree degree in degrees)
            {
                if(prefrences[preference_no]==degree.degree_title)
                {
                    if(merit>=degree.minimumAggregate)
                    {
                        if (degree.seats > 0)
                        {
                            discipline = degree.degree_title;
                            degree.seats--;
                        }
                    }
                    
                }
            }
        }
        public void ShowMeritList()
        {
            if(discipline==null)
            {
                Console.WriteLine(name + "  did not found himself able to get  admission in UET,Lahore "); 
            }
            else
            {
                Console.WriteLine(name + "  got admission in "+discipline);
            }
        }
        public void ShowRegistration()
        {
            if(discipline!="")
            {
                Console.WriteLine(name + "                          " + Fsc_marks + "                         " + Ecat_marks + "                        " + age);   
            }
        }
        public void ShowSpecificDegreeStudents(string Degree_Name)
        {
            if(discipline==Degree_Name)
            {
                Console.WriteLine(name + "                          " + Fsc_marks + "                         " + Ecat_marks + "                        " + age);
            }
        }
        public Student ReturnStudent(string name,List<Student>students)
        {
            
            foreach(Student student in students)
            {
                if (student.name == name)
                {
                    return student;
                }
                
            }

            return null; 
            
        }
        public void AddSubject(string Subject)
        {
            registered_Subjects.Add(Subject);
        }
        public Student GiveStudent(string student_name,List<Student> students)
        {
            foreach(Student student in students)
            {
                if(student_name==student.name)
                {
                    if(student.discipline!=null)
                    {
                        return student;
                    }
                    
                }
            }
            return null;
        }
        public int fee(List<Degree>degrees)
        {
            int fees = 0;
            foreach(Degree degree in degrees)
            {
                if(discipline==degree.degree_title)
                {
                    foreach(string RegisteredSubjects in registered_Subjects)
                    {
                        foreach (Subject subject in degree.subjects)
                        {
                            if(RegisteredSubjects==subject.Subject_Name)
                            {
                                fees = fees + subject.Subject_Fee;
                            }
                        }
                    }
                    
                }
            }
            return fees;
        }
       public void  NoRegisteredSubjects()
       {
            Console.WriteLine(name+ "  has not rigestered in any subject");
       }
        public void ShowFee(int fee)
        {
            Console.WriteLine(name + "  has a fee "+fee);
        }
        public bool Check(string subject)
        {
            foreach(string registeredSubjects in registered_Subjects)
            {
                if(registeredSubjects==subject)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
