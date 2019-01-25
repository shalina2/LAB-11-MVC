using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Personoftheyear
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }
       // public static IEnumerable<object> PersonData { get; private set; }

        public static List<Personoftheyear> GetPersons(int startYear, int endyear)
        {
            List<Personoftheyear> PersonData = new List<Personoftheyear>();

            string Filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../wwwroot/personOfTheYear.csv");
            var lines = File.ReadAllLines(Filepath).Skip(1);
            //List<string> lists = new List<string>();

            //converting string
            //foreach (var item in line.Split('\n'))
            //{
            //    lists.Add(line);
            //}
            //lists.RemoveAt(0);



            foreach (var item in lines)
            { 
               // if (startYear >= 1927 && endyear <= 2016)
               // {

                    string[] columns = item.Split(',');
                    Personoftheyear person = new Personoftheyear();
                    person.Year = (columns[0] == "" ? 0 : Convert.ToInt32(columns[0]));
                    person.Honor = columns[1];
                    person.Name = columns[2];
                    person.Country = columns[3];
                    person.BirthYear = (columns[4] == "" ? 0 : Convert.ToInt32(columns[4]));
                    person.DeathYear = (columns[5] == "" ? 0 : Convert.ToInt32(columns[5]));
                    person.Title = columns[6];
                    person.Category = columns[7];
                    person.Context = columns[8];
                PersonData.Add(person);
                }

                List<Personoftheyear> listofPeople = PersonData.Where(p => (p.Year >= startYear) && (p.Year <= endyear)).ToList();
                return listofPeople;
            }
           
        }
    }


