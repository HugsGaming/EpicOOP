using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Census
{
    class House
    {
        // Member Variables
        // DO NOT EDIT
        private string id;
        private List<Person> residents;

        // Task: Create Read-only Property ResCount
        // ResCount is the number of residents
        public int ResCount
        {
            get
            {
                return this.residents.Count();
            }
        }

        // Task: Create Read-only Property Residents
        public List<Person> Residents
        {
            get
            {
                return this.residents;
            }
        }

        // Task: Create Read-only Property Id
        public string Id
        {
            get
            {
                return this.id;
            }
        }

        // Task: Complete the constructor
        public House(string pId)
        {
            this.id = pId;
            this.residents = new List<Person>();
        }

        // Task: Complete the method
        // AddResident should add a 
        // person to this house.
        public void AddResident(Person p)
        {
            p.JoinHouse(this);
        }

        // Task: Complete the method
        // RemoveResident should remove
        // a person from this house.
        public bool RemoveResident(string pId)
        {
            for(int i = 0; i < residents.Count; i++)
            {
                if(residents[i].Id == pId)
                {
                    residents.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        // DO NOT EDIT
        // PrintResidents prints all
        // residents from this house
        // using PrintInfo
        public void PrintResidents()
        {
            Console.WriteLine($"Residents of House {this.id}:");
            Console.WriteLine();
            foreach (var p in residents)
            {
                p.PrintInfo();
            }
        }
    }
}
