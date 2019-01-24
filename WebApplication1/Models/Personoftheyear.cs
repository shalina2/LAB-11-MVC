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


        public static List<Personoftheyear> GetPersons(int startYear, int endyear)
        {
            List<Personoftheyear> PersonData = new List<Personoftheyear>();

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../wwwroot/personOfTheYear.csv");
            var personData = File.ReadAllText(path);
            List<string> lists = new List<string>();

            //converting string
            foreach (var line in personData.Split('\n'))
            {
                lists.Add(line);
            }
            lists.RemoveAt(0);



            foreach (var item in PersonData)
            { 
                if (startYear >= 1927 && endyear <= 2016)
                {

                    string[] lists = item.Split(',');
                    Personoftheyear person = new Personoftheyear();
                    person.Year = (lists[0] == "" ? 0 : Convert.ToInt32(lists[0]));
                    person.Honor = lists[1];
                    person.Name = lists[2];
                    person.Country = lists[3];
                    person.BirthYear = (lists[4] == "" ? 0 : Convert.ToInt32(lists[4]));
                    person.DeathYear = (lists[5] == "" ? 0 : Convert.ToInt32(lists[5]));
                    person.Title = lists[6];
                    person.Category = lists[7];
                    person.Context = lists[8];
                    personData.Add(person);
                }

            }
            List<Personoftheyear> listofPeople = personData.Where(p => (p.Year >= startYear) && (p.Year <= endyear)).ToList();
            return listofPeople;
        }
    }
}

