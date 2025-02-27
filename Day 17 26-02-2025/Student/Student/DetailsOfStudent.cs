using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    internal class DetailsOfStudent
    {
        public string Name { get; set; }
        public int RollNo { get; set; }

        public double Percentage { get; set; }

        public DetailsOfStudent(string name , int rollno , double percentage) { 
            Name = name;
            RollNo = rollno;
            Percentage = percentage; 
        }




    }
}
