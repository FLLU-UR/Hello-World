using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
  public class Statistics
  {
    public Statistics(List<double> grades)
    {
      Grades = grades;
      Average = 0.0;
      High = double.MinValue;
      Low = double.MaxValue;
    }

    public void AddGrade(int grade)
    {
      Grades.Add(grade);
    }
    public void ComputeStatistics()
    {
      foreach (var grade in Grades)
      {
        Low = Math.Min(grade, Low);
        High = Math.Max(grade, High);
        Average += grade;
      }
      Average /= Grades.Count;

      switch (Average)
      {
        case var d when d >= 90.0:
          Letter = 'A';
          break;
        case var d when d >= 80.0:
          Letter = 'B';
          break;
        case var d when d >= 70.0:
          Letter = 'C';
          break;
        case var d when d >= 60.0:
          Letter = 'D';
          break;
        default:
          Letter = 'F';
          break;
      }
    }

   

    private readonly List<double> Grades = new List<double>();
    public double Average;
    public double High;
    public double Low;
    public char Letter;
  }
}
