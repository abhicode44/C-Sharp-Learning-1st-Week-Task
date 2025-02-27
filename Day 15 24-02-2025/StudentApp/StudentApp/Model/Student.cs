using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentApp.Model
{
    internal class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public double CGPA { get; set; }

        public double Percentage { get; set; }


        public Student(int rollno, string name, double cgpa)
        {
            RollNo = rollno;
            Name = name;
            CGPA = cgpa;
            Percentage = CalculatePercentage();
        }



        public double CalculatePercentage()
        {
            return CGPA * 9.5;
        } 


       
        
    }
}
