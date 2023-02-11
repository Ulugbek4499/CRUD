namespace CRUD
{
    internal class CRUD_CreateData
    {
        public static void CreateData(string name, string personalData, string login, string password)
        {
            string path = Directory.GetCurrentDirectory();
            DirectoryInfo? dirInfo = new DirectoryInfo(path);
            dirInfo = dirInfo?.Parent?.Parent?.Parent;

            dirInfo = new DirectoryInfo(dirInfo?.FullName + "\\PersonData");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            string[] nameOfFiles = { "File1", "File2", "File3" };

            foreach (string fileName in nameOfFiles)
            {
                if (!File.Exists(dirInfo.FullName + $"\\{fileName}.txt"))
                {
                    File.Create(dirInfo.FullName + $"\\{fileName}.txt").Dispose();
                }
            }

            List<Person> users = new List<Person>();
            users.Add(new Person()
            {
                Name = name,
                PersonalData = personalData,
                Password = password,
                Login = login,
                Id = Guid.NewGuid()
            });


            FileInfo[] listOfFiles = dirInfo.GetFiles("*.txt", SearchOption.AllDirectories);

            users.ForEach(user =>
            {
                if (!File.ReadAllText(listOfFiles[0].FullName).Contains(user.Password))
                {
                    File.AppendAllText(listOfFiles[0].FullName, user.ToString());
                    Console.WriteLine("Your account has created successfully");

                }
                else
                {
                    Console.WriteLine("This information is already exists please enter another password and login!");

                }

            });
        }
    }
}
