using Newtonsoft.Json;

namespace Скоропечатание
{
    public class UserBoard
    {
        static List<User> Users = new List<User>();
        
        public void AddUser( string name, double minute, double second)
        {
            try
            {
                Users.Add(new User(name, minute, second));
            }
            catch
            {
                if (Users.Any(item => item.Name == name))
                {
                    Environment.Exit(0);
                    Console.WriteLine("Error");
                }
            }
        }
        
        public static void AddRecords(User record)
        {
            Users.Add(record);
        }

        public static void Serialization()
        {
            string json = JsonConvert.SerializeObject(Users);
            File.WriteAllText("C:\\Users\\efimb\\OneDrive\\Desktop\\", json);
        }
        
        public void ShowBoard()
        {
            foreach (User user in Users)
            {
                Console.WriteLine("Имя: " + user.Name);
                Console.WriteLine("Скорость в минуту: " + user.CharsPerMinute);
                Console.WriteLine("Скорость в секунду: " + user.CharsPerSecond);
                Console.WriteLine("                                          ");
            }
        }
    }
}