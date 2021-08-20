using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIT5032_CSharpSample.Models.Exercise
{
    public class Student
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Student(String name, String phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }


    public class ExampleDictionary
    {
        public Dictionary<int, Student> Example()
        {
            Dictionary<int, Student> studentDictionary = new Dictionary<int,Student>();
            Student s1 = new Student("Sagar", "7030363206");
            Student s2 = new Student("Sidhivinayak", "9453123456");
            studentDictionary.Add(1, s1);
            studentDictionary.Add(2, s2);
            Student result = new Student("", "");

            studentDictionary.TryGetValue(1, out result);

            return studentDictionary;
        }
    }
}