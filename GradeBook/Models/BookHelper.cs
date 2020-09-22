using GradeBook.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.Models
{
    public class BookHelper : IBookHelper
    {
     

        public List<double> AddGrade(double grade, Book book)
        {
           
            book.Grades.Add(grade);
            return book.Grades;
        }


        public string PrintAverageGrades(Book book)
        {
            var result = 0.0;
            foreach (double grade in book.Grades)
            {
                result += grade;
            }
            result /= book.Grades.Count;
            string avgGradeOutput = $"The average grade for book {book.name} is {result:N1}";
            return (avgGradeOutput);

        }

        public void ListBookGrades(Book book)
        {
            foreach (double grade in book.Grades)
                Console.WriteLine(grade);
        }

        public List<Book> BookListWithGrades(List<Book> fullBookList)
        {
            List<Book> booksWithGradesList = new List<Book>();
            if (fullBookList.Count > 0)
            {
                for (int i = 0; i < fullBookList.Count; i++)
                {
                    if (fullBookList[i].Grades.Count != 0)
                    {
                        booksWithGradesList.Add(fullBookList[i]);
                    }
                }

            }
            return booksWithGradesList;

        }

        public void printAllBooks(List<Book> bookList)
        {
            if (bookList.Count > 0)
            {
                Console.WriteLine("______________________");
                Console.WriteLine("Current Books:");
                foreach (Book book in bookList)
                {
                    Console.WriteLine("   *" + book.name);
                }
                Console.WriteLine("______________________");

                Console.WriteLine("\n\n\n");

            }
            else
            {
                Console.WriteLine("______________________");

                Console.WriteLine("There are no books currently.");
                Console.WriteLine("______________________\n");

            }
        }


    }
}
