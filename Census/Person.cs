using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Census
{
    class Person
    {
        // Member Variables
        // DO NOT EDIT
        private string id;
        private string name;
        private int age;

        // Task: Create Read-only Property Id
        public string Id
        {
            get
            {
                return this.id;
            }
        }

        // Task: Create Full-access Property Age
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        // Task: Create Read-only Property Name
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        // Task: Complete the constructor
        public Person(string pId, string pName)
        {
            this.id = pId;
            this.name = pName;
        }

        // Task: Complete the method
        // PrintInfo should print all Person info
        // on separate lines on the system console.
        public void PrintInfo()
        {
            Console.WriteLine($"Name: {this.Name}");
            Console.WriteLine($"ID: {this.id}");
            Console.WriteLine($"Age: {this.age}");
            Console.WriteLine();
        }

        // Task: Complete the method
        // JoinHouse should add this person
        // to the house specified.
        public void JoinHouse(House pHouse)
        {
            pHouse.AddResident(this);
        }
    }

    class Information
    {
        public static string RandomName(Random r)
        {

            string[] first = { "Jane", "Michael", "Sheena", "Minette", "Joanna", "Ley", "Johnny" };
            string[] last = { "Browning", "Black", "McGoogle", "Darcy", "Bazz", "Likom" };

            return $"{first[r.Next(0, first.Length)]} {last[r.Next(0, last.Length)]}";

        }
    }
}
