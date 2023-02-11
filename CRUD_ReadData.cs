using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CRUD
{
    internal class CRUD_ReadData
    {
        public static List<Person> ReadData()
        {
            List<Person> people = new();

            DirectoryInfo PersonDir = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent;
            PersonDir = new DirectoryInfo(PersonDir?.FullName + "\\PersonData");

            FileInfo PersonData1 = PersonDir.GetFiles("*.txt")[0];

            string[] AllLines = File.ReadAllLines(PersonData1.FullName);

            foreach (string person in AllLines)
            {
                Match match = Regex.Match(person, @"Id:(.*),Name:(.*),PersonalData:(.*),Login:(.*),Password:(.*)");

                if (match.Success)
                {
                    people.Add(new Person()
                    {
                        Id = Guid.Parse(match.Groups[1].Value),
                        Name = match.Groups[2].Value,
                        PersonalData = match.Groups[3].Value,
                        Login = match.Groups[4].Value,
                        Password = match.Groups[5].Value
                    });
                }
            }

            return people;
        }

    }
}
