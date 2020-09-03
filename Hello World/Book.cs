using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hello_World
{
  public delegate void GradeAddedDelegate(object sender, EventArgs args);



  public class NamedObject
  {
    public NamedObject(string name)
    {
      Name = name;
    }

    public string Name
    {
      get;
      set;
    }
  }
  
  public interface IBook
  {
    void AddGrade(double grade);
    Statistics GetStatistics();
    string Name { get; }
    event GradeAddedDelegate GradeAdded;
  }

  public abstract class Book : NamedObject, IBook
  {
    public Book(string name) : base(name)
    {
    }

    public abstract event GradeAddedDelegate GradeAdded;
    public abstract void AddGrade(double grade);
    public abstract Statistics GetStatistics();
  }

  public class DiskBook : Book
  {
    public DiskBook(string name) : base(name)
    {
      Name = name;
      ClearBook();
    }
    public void ClearBook()
    {
      File.Delete(@"C:\Users\Sonix\source\repos\Hello World\" + Name + ".txt");
    }
    public override void AddGrade(double grade)
    {
      if (grade <= 100 && grade >= 0)
      {
        using (var writer = File.AppendText(@"C:\Users\Sonix\source\repos\Hello World\" + Name + ".txt"))
        {
          writer.WriteLine(grade);
          if (GradeAdded != null)
          {
            GradeAdded(this, new EventArgs());
          }
        }
      }
      else
      {
        throw new ArgumentException($"Invalid {nameof(grade)}");
      }          
    }

    public override Statistics GetStatistics()
    {
      if (File.Exists(@"C:\Users\Sonix\source\repos\Hello World\" + Name + ".txt"))
      {
        var readString = File.ReadLines(@"C:\Users\Sonix\source\repos\Hello World\" + Name + ".txt");
        grades = readString.Select(x => double.Parse(x)).ToList();
      }    
      var result = new Statistics(grades);
      result.ComputeStatistics();
      return result;
    }

    private List<double> grades;
    public override event GradeAddedDelegate GradeAdded;
  }

  public class InMemoryBook : Book
  {
    public InMemoryBook(string name) : base(name)
    {
      grades = new List<double>();
      Name = name;
    }
    public override void AddGrade(double grade)
    {
      if(grade <= 100 && grade >=0)
      {
        grades.Add(grade);
        if (GradeAdded != null)
        {
          GradeAdded(this, new EventArgs());
        }
      }
      else
      {
        throw new ArgumentException($"Invalid {nameof(grade)}");
      }
      
    }

    public override event GradeAddedDelegate GradeAdded;

    public override Statistics GetStatistics() 
    {
      var result = new Statistics(grades);
      result.ComputeStatistics();
      return result;
    }

    private List<double> grades;
    
  }
}
