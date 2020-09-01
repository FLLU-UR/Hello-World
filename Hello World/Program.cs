using Hello_World;
using System;
using System.Collections.Generic;

namespace GradeBook
{

  class Program
  {
    static void Main(string[] args)
    {
      var book = new InMemoryBook("New Book");
      book.GradeAdded += OnGradeAdded;
      EnterGrades(book);

      var stats = book.GetStatistics();
      Console.WriteLine($"The lowest grade is{stats.Low}");
      Console.WriteLine($"The highest grade is{stats.High}");
      Console.WriteLine($"The average grade is{stats.Average}");
      Console.WriteLine($"The average grade is{stats.Letter}");
      Console.ReadLine();


    }

    private static void EnterGrades(Book book)
    {
      
      while (true)
      {
        Console.WriteLine("Please entere a Grade or Q to Quit");
        var input = Console.ReadLine();
        if (input == "Q")
        {
          break;
        }

        try
        {
          book.AddGrade(double.Parse(input));
        }
        catch (ArgumentException ex)
        {
          Console.WriteLine(ex.Message);
        }
        catch (FormatException ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
    }

    static void OnGradeAdded(object sender, EventArgs e)
    {
      Console.WriteLine("A grade was added");
    }
  }
}
