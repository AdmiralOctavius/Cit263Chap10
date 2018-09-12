using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cit263Chap10
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "Hello";
            SimpleTime test1 = new SimpleTime(12, 3, 12);
            SimpleTime test2 = new SimpleTime(11, 5, 2);
            Console.WriteLine(test2.ToString());
        }

       
    }

    public class SimpleTime
    {

        private int hour;
        private int minute;
        private int second;
        
        public SimpleTime(int hour =0, int minute = 0, int second = 0)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public string ToString()
        {
            string result = this.hour + " " + this.minute + " " + this.second;
            return result;
        }
    }

    public class Employee
    {
        string name;
        string email;
        SimpleTime hiredate;

    }
}
