using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OOPConcepts1
{
    class Program
    {
        static void ExitProt()
        {
            int[] houses = new int[10];
            var pop = 0;
            var ctr = 0;
            for(int i = 0; i < houses.Length; i++)
            {
                Console.Write($"House {i + 1}: ");
                string input = Console.ReadLine();
                if(input.ToUpper() == "EXIT")
                {
                    break;
                }
                else
                {
                    houses[i] = int.Parse(input);
                    pop += houses[i];
                    ctr++;
                }
            }
            double ave = pop / ctr;
            Console.WriteLine("Average Number of People: " + ave);
        }
        static void MikroNot()
        {
            Random rnd = new Random();
            Console.Write("Enter a notaion: ");
            string input = Console.ReadLine();
            string[] numsStr;
            int[] nums = new int[2];
            numsStr = input.Split(' ');
            int i = 0;
            foreach(var num in numsStr)
            {
                nums[i] = int.Parse(num);
                i++;
            }
            int size = nums[0];
            int[] houses = new int[size];
            for(int j = 0; j < houses.Length; j++)
            {
                houses[j] = rnd.Next(0, nums[1]);
                Console.WriteLine($"House {j+1}: {houses[j]}");
            }
        }

        static void Prosthesi()
        {
            Console.Write("Enter a notation: ");
            string input = Console.ReadLine();
            input = input.Replace("-", ",-");
            input = input.Replace("+", ",");
            string[] numStrs = input.Split(',');
            foreach(var numStr in numStrs)
            {
                Console.Write(numStr);
            }
        }

        static void MikroNotFileWrite()
        {
            StreamWriter sw = new StreamWriter("C:\\Users\\HugsGaming\\Documents\\Reports\\Reports.txt");
            try
            {
                Random rnd = new Random();
                int numReports = 1;
                while(true)
                {
                    Console.Write("Enter a notaion: ");
                    string input = Console.ReadLine();
                    if(input.ToUpper() == "EXIT")
                    {
                        break;
                    }else
                    {
                        string[] numsStr;
                        int[] nums = new int[2];
                        numsStr = input.Split(' ');
                        for (int i = 0; i < 2; i++)
                        {
                            nums[i] = int.Parse(numsStr[i]);
                        }
                        int size = nums[0];
                        int[] houses = new int[size];
                        int houseNum = 0;
                        sw.WriteLine($"Report {numReports++}");
                        sw.WriteLine();
                        for (int i = 0; i < houses.Length; i++)
                        {
                            houses[i] = rnd.Next(0, nums[1]);
                            sw.WriteLine($"House {++houseNum} ");
                            for (int j = 0; j < houses[i]; j++)
                            {
                                sw.Write('|');
                            }
                            sw.WriteLine($" {houses[i]}");
                        }
                        sw.WriteLine();
                    }
                }
                sw.Close();
            }
            catch
            {
                throw new Exception();
            }
        }

        static void Main(string[] args)
        {
            //int[] houses = new int[100];
            //var population = 0;
            //const int numOfPeople = 500;
            //var avePopulation = 0;
            //Random rnd = new Random();
            //while(population != numOfPeople)
            //{
            //    for (int i = 0; i < houses.Length; i++)
            //    {
            //        houses[i] = rnd.Next(0, 7);
            //        population += houses[i];
            //    }
            //    Console.WriteLine(population);
            //    if (population > numOfPeople)
            //    {
            //        population = 0;
            //    }else if(population < numOfPeople)
            //    {
            //        population = 0;
            //    }
            //}
            //avePopulation = population/ houses.Length;
            //var houseNum = 1;
            //var initPopulation = 0;
            //foreach (var house in houses)
            //{
            //    Console.Write($"House { houseNum++, 3} ");
            //    for (int i = 0; i < house; i++)
            //    {
            //        Console.Write("*");
            //    }
            //    initPopulation += house;
            //    Console.Write($" {house} {initPopulation} ");
            //    Console.WriteLine();
            //}
            //Console.WriteLine("Total Population: " + population);
            //Console.WriteLine("Average Population: " + avePopulation);
            Prosthesi();
            //MikroNotFileWrite();
        }
    }
}
