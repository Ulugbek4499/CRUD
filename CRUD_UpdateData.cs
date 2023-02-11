namespace CRUD
{
    internal class CRUD_UpdateData
    {
        public static void UpdateData(string login, string password)
        {

            DirectoryInfo? dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory())?.Parent?.Parent?.Parent;
            dirInfo = new DirectoryInfo(dirInfo.FullName + "\\PersonData");
            FileInfo files = dirInfo.GetFiles("*.txt")[0];

            List<Person> persona = CRUD_ReadData.ReadData();

            bool isContain = false;

            for (int i = 0; i < persona.Count; i++)
            {
                if (persona[i].Password == password && persona[i].Login == login)
                {
                    Console.Write("Updated Name: ");
                    persona[i].Name = Console.ReadLine();
                    Console.Write("Updated Personal Data:");
                    persona[i].PersonalData = Console.ReadLine();
                    Console.Write("Updated: Login");
                    persona[i].Login = Console.ReadLine();
                    Console.Write("Updated Password: ");
                    persona[i].Password = Console.ReadLine();

                    isContain = true;
                    break;
                }
            }

            File.WriteAllText(files.FullName, string.Empty);

            persona.ForEach(user =>
            {
                File.AppendAllText(files.FullName, user.ToString());
            });

            Console.WriteLine("Your account updated succesffuly!");

        }
    }

}
