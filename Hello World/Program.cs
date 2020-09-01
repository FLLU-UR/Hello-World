using Hello_World;
using System;
using System.Collections.Generic;

namespace GradeBook
{

  class Program
  {
    static void Main(string[] args)
    {
      var book = new Book("New Book");
      book.AddGrade(12.6);
      book.AddGrade(10.3);
      book.AddGrade(6.11);
      book.AddGrade(4.1);
      book.AddGrade(56.1);

      var stats = book.GetStatistics();
      Console.WriteLine($"The lowest grade is{stats.Low}");
      Console.WriteLine($"The highest grade is{stats.High}");
      Console.WriteLine($"The average grade is{stats.Average}");
      Console.ReadLine();


    }
  }
}
