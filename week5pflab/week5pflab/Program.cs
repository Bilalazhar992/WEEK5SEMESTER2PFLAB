using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5pflab
{
    class Program
    {
        static void Main(string[] args)
        {
            //UMAS();
            //task1();
            task2();
            
        }
        static void logo()
        {
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("                                   UMAS                                  ");
            Console.WriteLine("*************************************************************************");
            Console.WriteLine();
            Console.WriteLine();
        }
        static string menu()
        {
            Console.WriteLine("1-Add Student");
            Console.WriteLine("2-Add Degree Program");
            Console.WriteLine("3-Generate Merit");
            Console.WriteLine("4-View Registered Students");
            Console.WriteLine("5-View Students of a Specific Program");
            Console.WriteLine("6-Register Subjects For a Specific Student ");
            Console.WriteLine("7-Calculate Fee For All Registerd Students");
            string option;
            Console.Write("Enter Your Option ");
            return option = Console.ReadLine();
        }
        static Student InputStudent(List<Degree> degree)
        {
            Console.Write("Enter the Name of Student: ");
            string name = Console.ReadLine();
            Console.Write("Enter the Age of Student: ");
            int age =int.Parse(Console.ReadLine());
            Console.Write("Enter the Fsc Marks of Student: ");
            int fscmarks = int.Parse(Console.ReadLine());
            Console.Write("Enter the Ecat Marks of Student: ");
            int Ecatmarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Available Degree Program ");
            foreach(Degree degrees_available in degree)
            {
                Console.WriteLine(degrees_available.degree_title);
            }
            Console.Write("Enter How Many Prefrences You Want To Add ");
            int no_of_prefrences = int.Parse(Console.ReadLine());
            Student student = new Student(name, age, fscmarks, Ecatmarks, no_of_prefrences);
            return student;
        }
        static Degree InputDetailsOfDegree()
        {
            Console.Write("Enter Degree Name ");
            string degree_name = Console.ReadLine();
            Console.Write("Enter Degree Duration in Year(in numeric figure)");
            int degree_duration =int.Parse(Console.ReadLine());
            Console.Write("Enter Degree Seats ");
            int degree_seats = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Number Of Subjects ");
            int no_of_subjects = int.Parse(Console.ReadLine());
            Degree degree = new Degree(degree_name, degree_duration, degree_seats, no_of_subjects);
            return degree;
        }
       static void Sorting(List<Student>students)
        {
            Student student = new Student();
            for(int i=0;i<students.Count;i++)
            {
                for (int j = 0; j < students.Count-1; j++)
                {
                    if(students[j].merit < students[j + 1].merit)
                    {
                        student = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = student;
                    }
                }
            }
        }
        static void UMAS()
        {
            List<Student> students = new List<Student>();
            List<Degree> degrees = new List<Degree>();
            string student_name;
            while (true)
            {
                logo();
                string choice = menu();
                if (choice == "1")
                {
                    Student student = InputStudent(degrees);
                    student.TakePreferances();
                    students.Add(student);
                }
                else if (choice == "2")
                {
                    Degree degree = InputDetailsOfDegree();
                    degree.EnterDetailsOfSubject();
                    degrees.Add(degree);
                }
                else if (choice == "3")
                {

                    foreach (Student student_address in students)
                    {
                        student_address.MeritCalculator();
                    }
                    foreach (Degree degree_address in degrees)
                    {
                        degree_address.SetMinimunAggregate(students);
                    }

                    Sorting(students);
                    foreach (Student student_address in students)
                    {
                        for (int preferences = 0; preferences <= 9; preferences++)
                        {
                            
                            
                                if (student_address.discipline == null)
                                {
                                    if (student_address.prefrences.Count > preferences)
                                    {
                                        student_address.AsignDisicipline(degrees, preferences);
                                    }

                                }
                            
                        }
                    }
                    
                    foreach (Student student_address in students)
                    {
                        student_address.ShowMeritList();
                    }
                }
                else  if(choice == "4")
                {
                    Console.WriteLine("Name                     FSC                    Ecat                      Age");
                    foreach (Student student_address in students)
                    {
                        student_address.ShowRegistration();
                    }
                }
                else if (choice == "5")
                {

                    Console.Write("Enter Name of Degree: ");
                    string Degree_Name = Console.ReadLine();
                    Console.WriteLine("Name                     FSC                    Ecat                      Age");
                    foreach (Student student_address in students)
                    {
                        student_address.ShowSpecificDegreeStudents(Degree_Name);
                    }
                }
                else if (choice == "6")
                {
                    Student student = new Student();
                    string Subject = "";
                    Console.Write("Enter name of student ");
                    string name = Console.ReadLine();
                    student = student.ReturnStudent(name, students);
                    if(student!=null)
                    {
                        if(student.discipline!=null)
                        {
                        Console.WriteLine("Enter Number of subjects you want to Register ");
                        int no_of_Subjects = int.Parse(Console.ReadLine());
                        for (int i = 0; i < no_of_Subjects; i++)
                        {
                            
                            Console.Write("Enter code of Subject ");
                            int code = int.Parse(Console.ReadLine());


                            
                            foreach (Degree degree_address in degrees)
                            {
                                Subject = degree_address.RegisterSubject(student, code);
                                if (Subject != null)
                                {
                                    break;
                                }
                            }
                            if(student.Check(Subject))
                            {
                                student.AddSubject(Subject);
                            }
                            else
                            {
                                Console.WriteLine("That Subject Has Already being Registered by you");
                            }
                        }
                        }       
                        else
                        {
                            Console.WriteLine("That Student Does Not Found himself to get admission in any discipline  ");
                        }                 
                    }
                    else{
                        Console.WriteLine("That Student Does Not Exsist in Our Record ");
                    }

                }
                else if (choice == "7")
                {
                    int fee;
                    Console.WriteLine("Enter Name Student");
                    student_name = Console.ReadLine();
                    Student student = new Student();
                    student = student.GiveStudent(student_name, students);
                    if (student == null)
                    {
                        Console.WriteLine("That student does not exsist in our university ");
                    }
                    else
                    {
                        fee = student.fee(degrees);
                        if (fee == 0)
                        {
                            student.NoRegisteredSubjects();
                        }
                        else
                        {
                            student.ShowFee(fee);
                        }
                    }


                }
                else if (choice == "8")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Entery by user ");

                }
                Console.WriteLine("Press Any key to go back on menu ");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void task1()
        {
            List<Studentfortask1> students = new List<Studentfortask1>();
            
            while(true)
            {
                logo1();
                string option = main_menu();
                if (option=="1")
                {
                    students.Add(EnterStudent());
                }
                else if(option=="2")
                {
                    foreach(Studentfortask1 student in students)
                    {
                        student.MeritCalculator();
                    }
                    foreach (Studentfortask1 student in students)
                    {
                        student.ShowMerit();
                    }
                }
                else if(option=="3")
                {
                    Console.Write("Enter the Name of Student: ");
                    string name = Console.ReadLine();
                    Studentfortask1 student = new Studentfortask1();
                    student = student.CheckExsistance(students, name);
                    if(student==null)
                    {
                        Console.WriteLine("That Student does not Exsist in Our University");
                    }
                    else
                    {
                         bool flag=student.EligibilityforScholarship();
                        if(flag==true)
                        {
                            Console.WriteLine(name + " is Eligible for ScholarShip ");
                        }
                        else
                        {
                            Console.WriteLine(name + " is not Eligible for ScholarShip ");
                        }
                    }
                   
                }
                else if(option=="4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Entery by user ");
                    
                }
                Console.WriteLine("Press Any key to go back on menu ");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void logo1()
        {
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("                              STUDENT PROFILE                            ");
            Console.WriteLine("*************************************************************************");
            Console.WriteLine();
            Console.WriteLine();
        }
        static string main_menu()
        {
            Console.WriteLine("1-Add Student");
            Console.WriteLine("2-Show merit of each Student");
            Console.WriteLine("3-Check Scholarship Status");
            Console.WriteLine("4-Exit");
            Console.WriteLine("Enter Choice Here");
            string choice = Console.ReadLine();
            return choice;
        }
        static Studentfortask1 EnterStudent()
        {
            Console.Write("Enter the Name of Student: ");
            string name = Console.ReadLine();
            Console.Write("Enter the Age of Student: ");
            string age = Console.ReadLine();
            Console.Write("Enter the Fsc Marks of Student: ");
            int fscmarks = int.Parse(Console.ReadLine());
            Console.Write("Enter the Ecat Marks of Student: ");
            int Ecatmarks = int.Parse(Console.ReadLine());
            Console.Write("Enter the Matric Marks of Student: ");
            int Matricmarks = int.Parse(Console.ReadLine());
            Console.Write("Enter the RollNo of Student: ");
            string rool_no =Console.ReadLine();
            Console.Write("Enter the CGPA of Student: ");
            float cgpa = float.Parse(Console.ReadLine());
            Console.Write("Enter the HomeTown of Student: ");
            string hometown = Console.ReadLine();
            Console.WriteLine("Enter Whether A Student is Hostilite or Not Press(Y or N)");
            string hostile_status = Console.ReadLine();
            Studentfortask1 student = new Studentfortask1(name,age,fscmarks,Ecatmarks,Matricmarks,rool_no,cgpa,hometown,hostile_status);
            return student;
        }
        static void task2()
        {
            List<Book> books = new List<Book>();
            Book book = new Book();
            while(true)
            {
                logo2();
                string option = library_menu();
                if(option=="1")
                {
                    book = AddBook();
                    book.EnterChapters();
                    books.Add(book);
                }
                else if(option=="2")
                {
                    
                    Entery(books,book);
                    if(book==null)
                    {
                        Console.WriteLine("That Book Does Not Present in Our Library");
                    }
                    if(book.bookstatus!="borrowed")
                    {
                        book.Booked();
                        Console.WriteLine("Sucessfully Booked");
                    }
                    else
                    {
                        Console.WriteLine("Not Available for Booking");
                    }
                }
                else if (option == "3")
                {
                    Entery(books, book);

                    if (book == null)
                    {
                        Console.WriteLine("That Book Does Not Present in Our Library");
                    }
                    else
                    {
                        
                        if(book.CheckAvailability())
                        {
                            Console.WriteLine("That is Available");
                        }
                        else
                        {
                            Console.WriteLine("That is Borrowed");
                        }
                    }
                }
                else if(option=="4")
                {
                    Entery(books, book);
                    if (book == null)
                    {
                        Console.WriteLine("That Book Does Not Present in Our Library");
                    }
                    else
                    {
                        Console.WriteLine("Enter the page of book");
                        int page = int.Parse(Console.ReadLine());
                        book.AddBookMark(page);
                    }
                }
                else if(option=="5")
                {
                    Entery(books, book);
                    if (book == null)
                    {
                        Console.WriteLine("That Book Does Not Present in Our Library");
                    }
                    else
                    {
                        
                        int bookMark=book.ShowBookMark();
                        Console.WriteLine(book.title + "  has a bookmark at " + bookMark);
                    }
                }
                else if (option == "6")
                {
                    Console.WriteLine("Enter the name of the chapter ");
                    string chapter = Console.ReadLine();
                    book = book.CheckChapter(books, chapter);
                    if(book==null)
                    {
                        Console.WriteLine("That Chapter Does Not Exsist in any Book");
                    }
                    else
                    {
                        book.ShowChapter(chapter);
                    }
                }
                else if (option == "7")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Entery by user ");

                }
                Console.WriteLine("Press Any key to go back on menu ");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void logo2()
        {
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("                              LIBRARY SYSTEM                             ");
            Console.WriteLine("*************************************************************************");
            Console.WriteLine();
            Console.WriteLine();
        }
        static string library_menu()
        {
            Console.WriteLine("1-Add Book");
            Console.WriteLine("2-Borrow Book");
            Console.WriteLine("3-Check Book Availability");
            Console.WriteLine("4-Add BookMark");
            Console.WriteLine("5-Check BookMark");
            Console.WriteLine("6-Check A Specific Chapter");
            Console.WriteLine("7-Exit");
            Console.WriteLine("Enter Choice Here");
            string choice = Console.ReadLine();
            return choice;
        }
        static Book AddBook()
        {
            Console.WriteLine("Enter the name of book");
            string book_name = Console.ReadLine();
            Console.WriteLine("Enter the Price of Book");
            int price = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter number of pages");
            int no_of_pages = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of chapters in book");
            int no_of_chapters = int.Parse(Console.ReadLine());
            Book book= new Book(book_name, price, no_of_chapters, no_of_pages);
            return book;
        }
        static void Entery(List<Book>books,Book book)
        {
            Console.WriteLine("Enter the name of book");
            string book_name = Console.ReadLine();
            book = book.CheckBook(books, book_name);
        }
    }
}
