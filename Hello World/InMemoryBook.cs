﻿using System;
using System.Collections.Generic;

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

  public abstract class Book : NamedObject
  {
    protected Book(string name) : base(name)
    {
    }

    public abstract void AddGrade(double grade);
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

    public event GradeAddedDelegate GradeAdded;

    public Statistics GetStatistics() 
    {
      var result = new Statistics
      {
        Average = 0.0,
        High = double.MinValue,
        Low = double.MaxValue
      };

      foreach (var grade in grades)
      {
        result.Low = Math.Min(grade, result.Low);
        result.High = Math.Max(grade, result.High);
        result.Average += grade;
      }
      result.Average /= grades.Count;

      switch (result.Average)
      {
        case var d when d >= 90.0:
          result.Letter = 'A';
          break;
        case var d when d >= 80.0:
          result.Letter = 'B';
          break;
        case var d when d >= 70.0:
          result.Letter = 'C';
          break;
        case var d when d >= 60.0:
          result.Letter = 'D';
          break;
        default:
          result.Letter = 'F';
          break;
      }

      return result;
    }

    private List<double> grades;
    
  }
}