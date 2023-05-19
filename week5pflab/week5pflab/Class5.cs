using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5pflab
{
    public class Book
    {
        public string title;
        public int pages;
        public int price;
        public  int BookMark;
        public int no_of_chapters;
        public string bookstatus = "available";
        List<string> Chapters = new List<string>();
        public Book()
        {

        }
        public Book(string book_name,int price,int no_of_chapters,int no_of_pages)
        {
            title = book_name;
            this.price = price;
            this.no_of_chapters = no_of_chapters;
            pages = no_of_pages;
        }
        public void EnterChapters()
        {
            for(int i=0;i<no_of_chapters;i++)
            {
                Console.Write("Enter name of chapter no " + (i + 1)+" ");
                Chapters.Add(Console.ReadLine());
            }
        }
        public Book CheckBook(List<Book> books,string book_name)
        {
            foreach(Book book in books)
            {
                if(book_name==book.title)
                {
                    return book;
                }
            }
            return null;
        }
        public void Booked()
        {
            bookstatus = "borrowed";
        }
        public bool CheckAvailability()
        {
            bool flag = false;
            if(bookstatus=="available")
            {
                flag = true;
            }
            return flag;
        }
        public void AddBookMark(int page)
        {
            if(page<=pages)
            {
                BookMark = page;
            }
            else
            {
                Console.WriteLine("That Page Does Not Exsist in " + title);
            }
        }
        public int ShowBookMark()
        {
            return BookMark;
        }
        public Book CheckChapter(List<Book>books,string chapter)
        {
            foreach(Book book in books)
            {
                foreach(string chapters in book.Chapters)
                {
                    if(chapters==chapter)
                    {
                        return book;
                    }
                }
            }
            return null;
        }
        public void ShowChapter(string chapter)
        {
            Console.WriteLine(chapter + " is present in " + title);
        }
    }
}
