using GradeBook.Models;
using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Book> bookList = new List<Book>();
            BookHelper bookHelper = new BookHelper();

            while (true)
            {
                bookHelper.printAllBooks(bookList);



                Console.WriteLine("Please select an option below:");
                Console.WriteLine(" 1. Create a new grade book.");
                if (bookList.Count > 0)
                {
                    Console.WriteLine(" 2. Add a grade to a current grade book.");

                    if (bookHelper.BookListWithGrades(bookList).Count > 0)
                    {
                        Console.WriteLine(" 3. See a book's grade point average.");

                    }
                }

              

                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        bool continueCase1 = true;
                        while (continueCase1)
                        {
                            Console.WriteLine("\n\nWhat do you want to name the book?");
                            string bookName = Console.ReadLine();
                            if (!String.IsNullOrWhiteSpace(bookName))
                            {
                                Book book = new Book(bookName);

                                bookList.Add(book);
                                Console.WriteLine($"\n\nSuccess! You have added a book called {bookList[bookList.Count - 1].name}.");
                                bookHelper.printAllBooks(bookList);
                                Console.WriteLine("\n\nWould you like to add another book? Yes or No?");
                                string choice = Console.ReadLine().ToLower();
                                if (choice.StartsWith("y"))
                                {
                                    continueCase1 = true;
                                }
                                else
                                {
                                    Console.WriteLine("\n\n\n");
                                    continueCase1 = false;
                                }

                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid name for the book.");
                            }
                        }
             
                        break;
                    case "2":
                        Console.WriteLine("\n\nWhich book would you like to add a grade to?");
                        for (int i = 0; i < bookList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {bookList[i].name}");
                        }
                        int.TryParse(Console.ReadLine(), out int index);
                        //ToDo:  Add logic to prevent selection of book from being out-of-range
                        index -= 1;
                        bool addingGrade = true;
                        while (addingGrade)
                        {
                            Console.WriteLine($"\n\nWhat is the new grade to add to {bookList[index].name}?");

                            if (double.TryParse(Console.ReadLine(), out double parsed) && parsed <= 100 && parsed >= 0)
                            
                            {
                                bookHelper.AddGrade(parsed, bookList[index]);
                                Console.WriteLine($"The grades for {bookList[index].name} are now:");
                                bookHelper.ListBookGrades(bookList[index]);

                                Console.WriteLine("\n\nWould you like to add another grade? Y or N");
                                if (Console.ReadLine().ToLower().StartsWith("y"))
                                {
                                    addingGrade = true;
                                }
                                else
                                {
                                    addingGrade = false;
                                }

                            }
                            else
                            {
                                Console.WriteLine("That is an invalid grade. Please enter an integer between 0 & 100.");
                                addingGrade = true;
                            }
                        }
                        break;
                    case "3":
                        bool avgView = true;
                        while (avgView)
                        {
                            if (bookHelper.BookListWithGrades(bookList).Count != 0)
                                Console.WriteLine("Which book would you like to see the average for?");
                            for (int i = 0; i < bookHelper.BookListWithGrades(bookList).Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {bookHelper.BookListWithGrades(bookList)[i].name}");
                            }
                            int.TryParse(Console.ReadLine(), out int selectedBook);
                            selectedBook -= 1;


                            if (selectedBook > -1 && selectedBook + 1 <= bookList.Count)
                            {


                                Console.WriteLine(bookHelper.PrintAverageGrades(bookHelper.BookListWithGrades(bookList)[selectedBook]));

                                bookHelper.PrintAverageGrades(bookHelper.BookListWithGrades(bookList)[selectedBook]);

                                avgView = false;
                            }
                            else
                            {
                                Console.WriteLine("That book does not exist.");
                                avgView = true;
                            }
                        }
                        break;
                    case "4":
                        foreach (Book bk in bookList)
                        {
                            Console.WriteLine(bk.name);
                        }
                        break;
                }

            }


        }

        //    book.AddGrade(89.1);
        //    book.AddGrade(12.7);
        //    book.AddGrade(10.3);
        //    book.AddGrade(6.11);
        //    book.AddGrade(4.1);
        //}




    }
}

