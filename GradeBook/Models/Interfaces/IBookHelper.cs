using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.Models.Interfaces
{
    public interface IBookHelper
    {
        List<double> AddGrade(double grade, Book book);

        string PrintAverageGrades(Book book);

        void ListBookGrades(Book book);

        void printAllBooks(List<Book> bookList);

        List<Book> BookListWithGrades(List<Book> fullBookList);

        //Dictionary<string, double> gradeDictionary();
    }

    
}
