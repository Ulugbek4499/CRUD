namespace CRUD
{
    internal class CRUD_Start
    {
        public static void Start()
        {
            bool isTrue = true;
            while (isTrue)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t=====>Welcome to our program, this is for saving your information <=====\t\t\t");
                Console.WriteLine("\t\t\t\t\t Press the key to continue...\t\t\t\t\t");
                Console.ReadKey();
                Console.WriteLine("Choose options:\n1.LogIn\n2.SignIn\n3.SignOut\n4.Exit");
                int? choiseNum = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choiseNum)
                {
                    
                    case 1:
                        {
                            Console.Write("Enter your choice:\n1.See my data \n2.Change my data\n==>");
                            int choiceNum2 = int.Parse(Console.ReadLine());
                            Console.Clear();
                            switch (choiceNum2)
                            {
                                case 1:
                                    {
                                        Console.Write("Login: ");
                                        string? login1 = Console.ReadLine();
                                        Console.Write("Passoword: ");
                                        string? password1 = Console.ReadLine();

                                        List<Person> persona = CRUD_ReadData.ReadData();

                                        bool isContain = false;
                                        foreach (Person item in persona)
                                        {
                                            if (item.Password == password1 && item.Login == login1)
                                            {
                                                Console.WriteLine(item);
                                                isContain = true;
                                                break;
                                            }
                                        }
                                        if (isContain == false) Console.WriteLine("You entered wrong login or password, please try again!");
                                        Console.ReadKey();
                                    }
                                    break;
                                case 2:
                                    {
                                        Console.Write("Login: ");
                                        string? login2 = Console.ReadLine();
                                        
                                        Console.Write("Passoword: ");
                                        string? password2 = Console.ReadLine();

                                        List<Person> persona = CRUD_ReadData.ReadData();

                                        bool isContain = false;
                                        foreach (Person item in persona)
                                        {
                                            if (item.Password == password2 && item.Login == login2)
                                            {
                                                CRUD_UpdateData.UpdateData(login2, password2);
                                                isContain = true;
                                                break;
                                            }
                                        }
                                        if (isContain == false) Console.WriteLine("You entered wrong login or password, please try again!");

                                       
                                        Console.ReadKey();
                                    }
                                    break;
                            }



                        }
                        break;

                    case 2:
                        {
                            Console.WriteLine("In order to create your account please fill the form!");
                            Console.Write("FullName: "); string name = Console.ReadLine();
                            Console.Write("Personal data that you want to save: "); string personalData = Console.ReadLine();
                            Console.Write("Login: "); string login = Console.ReadLine();
                            Console.Write("Password: "); string password = Console.ReadLine();

                            CRUD_CreateData.CreateData(name, personalData, login, password);
                            Console.ReadKey();
                        }
                        break;

                    case 3:
                        {

                            Console.Write("Login: ");
                            string? login3 = Console.ReadLine();
                            Console.Write("Passoword: ");
                            string? password3 = Console.ReadLine();

                            CRUD_DeleteData.Delete(login3, password3);
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Thank you for using our service!");
                            Console.ReadKey();
                            isTrue = false; 
                        } break;
                       

                    default: 
                        {
                            Console.WriteLine("Wrong character!!!");
                            Console.ReadKey();
                        } break;

                }
            }
        }

    }

}
