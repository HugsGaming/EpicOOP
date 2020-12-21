using System;
using System.Collections.Generic;
using System.IO;

namespace Census
{
    class Program
    {
        static void EvaluateXMikro(string input, ref string commname, ref int numHouses, ref int houseLimit)
        {
            string[] parsed = input.Split(' ');
            commname = parsed[0];
            numHouses = int.Parse(parsed[1]);
            houseLimit = int.Parse(parsed[2]);
        }

        static void InitializeHouseResidents(ref List<House> houses, string commname, int houseLimit)
        {
            Random r = new Random();
            foreach (var house in houses)
            {
                for (var i = 0; i < r.Next(0, houseLimit + 1); i++)
                {
                    Person p = new Person($"{commname}-P-{r.Next(0, 1000):D4}", Information.RandomName(r));
                    p.Age = r.Next(5, 66);

                    house.AddResident(p);
                }
            }
        }

        static void GenerateCommunityData(Dictionary<string, List<House>> communities)
        {
            StreamWriter sw = new StreamWriter("C:\\Files\\communities.txt");

            foreach (var comm in communities)
            {
                string prosthesi = string.Empty;
                prosthesi += $"{comm.Key}::";

                foreach (var house in comm.Value)
                {
                    prosthesi += $"+{house.ResCount}";
                }

                sw.WriteLine(prosthesi);
            }

            sw.Close();
        }

        static void GenerateHouseData(Dictionary<string, List<House>> communities)
        {
            StreamWriter sw = new StreamWriter("C:\\Files\\houses.txt");

            foreach (var comm in communities)
            {
                foreach (var house in comm.Value)
                {
                    string casa = string.Empty;
                    casa += $"H";
                    casa += $"::{comm.Key}";
                    casa += $"::{house.Id}";
                    sw.WriteLine(casa);
                }
            }

            sw.Close();
        }

        static void GeneratePersonData(Dictionary<string, List<House>> communities)
        {
            StreamWriter sw = new StreamWriter("C:\\Files\\persons.txt");

            foreach (var comm in communities)
            {
                foreach (var house in comm.Value)
                {
                    foreach (var p in house.Residents)
                    {
                        string corpus = string.Empty;
                        corpus += $"P";
                        corpus += $"::{p.Id}";
                        corpus += $"::{p.Name}";
                        corpus += $"::{p.Age}";
                        corpus += $"::{house.Id}";
                        corpus += $"::{comm.Key}";
                        sw.WriteLine(corpus);
                    }
                }
            }

            sw.Close();
        }


        static void Main(string[] args)
        {

            // Main Function Variables
            Random r = new Random();
            string input;
            Dictionary<string, List<House>> communities = new Dictionary<string, List<House>>();
            List<House> houses;

            do
            {
                Console.Write("xMK>> ");
                input = Console.ReadLine();
                if (input.ToUpper() != "EXIT")
                {
                    string commname = string.Empty;
                    int numHouses = 0, houseLimit = 0;
                    EvaluateXMikro(input, ref commname, ref numHouses, ref houseLimit);

                    houses = new List<House>();

                    for (var i = 0; i < numHouses; i++)
                    {
                        houses.Add(new House($"{commname}-H-{i + 1:D3}"));
                    }

                    InitializeHouseResidents(ref houses, commname, houseLimit);
                    communities.Add(commname, houses);

                }


            } while (input.ToUpper() != "EXIT");

            GenerateCommunityData(communities);
            GenerateHouseData(communities);
            GeneratePersonData(communities);

        }
    }
}
