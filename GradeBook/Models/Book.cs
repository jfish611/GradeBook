using GradeBook.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Book 
    {
        private List<double> grades = new List<double>();

        private string Name { get => name; set => name = value; }



        public List<double> Grades { get => grades; set => grades = value; }
        public string name { get; private set; }


        public Book(string name)
        {
            Name = name;
        }

        public Book() { }




    }
}
