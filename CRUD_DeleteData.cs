using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    internal class CRUD_DeleteData
    {
        public static void Delete(string login, string password)
        {
            DirectoryInfo? dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory())?.Parent?.Parent?.Parent;
            dirInfo = new DirectoryInfo(dirInfo.FullName + "\\PersonData");
            FileInfo files = dirInfo.GetFiles("*.txt")[0];
            

            List<Person> people = CRUD_ReadData.ReadData();
            List<Person>peopleNew= new List<Person>();

            foreach (var person in people)
            {
                if(!(person.Password==password && person.Login==login))
                {
                    peopleNew.Add(new Person()
                    {
                        Name = person.Name,
                        PersonalData = person.PersonalData,
                        Password = person.Password,
                        Login = person.Login,
                        Id = person.Id
                    });
                }
            }

            FileInfo[] listOfFiles = dirInfo.GetFiles("*.txt", SearchOption.AllDirectories);

            File.WriteAllText(files.FullName, string.Empty);

            peopleNew.ForEach(user =>
            {
                    File.AppendAllText(files.FullName, user.ToString());
            });

            Console.WriteLine("Your account removed succesffuly!");

        }
    }

}
