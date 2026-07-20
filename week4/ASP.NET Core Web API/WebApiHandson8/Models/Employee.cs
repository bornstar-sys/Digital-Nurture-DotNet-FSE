using System;
using System.Collections.Generic;

namespace WebApiHandson8.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public double Salary { get; set; }

        public bool Permanent { get; set; }

        public Department Department { get; set; } = new Department();

        public List<Skill> Skills { get; set; } = new List<Skill>();

        public DateTime DateOfBirth { get; set; }
    }
}