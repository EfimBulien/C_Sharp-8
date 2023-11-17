namespace Скоропечатание
{
    internal abstract class Program
    {
        static ConsoleKeyInfo key;
        static UserBoard userBoard = new UserBoard();
        static User user = new User();
        
        static string text = 
                "Тихий вечер. Город угрюмо молчит. Огоньки улиц освещают пустые тротуары. Ветер ласкает лица прохожих, " +
                "несет запах дождя. Вдалеке слышится шум автомобилей, затихающий в ритме городской ночи. На углу старого здания " +
                " стоит мужчина. В его глазах отражается усталость и загадка. Он держит в руках старую фотографию. Лица на ней знакомы," +
                "но время оставило на них свой след. Мужчина поворачивает на переулок, где замерзшая лужайка украшена первыми инеем. " +
                " В его сердце таится воспоминание о прошлом, которое словно давно забыто, но не отпускает. В этом мгновении, под светом " +
                " уличных фонарей, проходит момент решения. Мужчина решает отправиться в путь. Городские огоньки теряют свой смысл, когда" +
                " сердце наполняется тяжким чувством ожидания неизведанного. Так начинается новая глава в его жизни. Впереди непознанные " +
                " её. Но стоило ей положить фигурку в сумку и с облегчением вздохнуть, как один из друзей со свёртками шёлка в руках похлопал её по плечу." +
                " дороги, таинственные встречи и ответы на вопросы, которые долго прятало прошлое. Его взгляд был устремлен вдаль... ";
        
        static void Main()
        {
            bool running = true; 
            do
            {
                Console.WriteLine("Введите свое имя: ");
                user.Name = Convert.ToString(Console.ReadLine());
                
                SpeedOfTypingTest(running);
                
                key = Console.ReadKey();
                
                Console.SetCursorPosition(0,0);
            } while (key.Key != ConsoleKey.F1);
        }

        private static void Time(bool running)
        {
            Thread t = new Thread(_ =>
            {
                int top = 0;
                int time = 0;
                DateTime nowDateTime = DateTime.Now;
                DateTime timer = nowDateTime.AddMinutes(-1);
                
                while (nowDateTime >= timer && running)
                {
                    Console.SetCursorPosition(0, top);
                    if (time == text.Length)
                    {
                        running = false;
                    }
                    Console.SetCursorPosition(0, top);
                    var tick = (nowDateTime - timer).Ticks;
                    Console.SetCursorPosition(0, top);
                    Console.WriteLine(new DateTime(tick).ToString("ss"));
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(0, top);
                    timer = timer.AddSeconds(1);
                    Console.SetCursorPosition(0, top);
                }
                
                Console.Clear();
                Console.WriteLine("Время вышло.");
                SpeedOfTyping(time);
                EndOfTypingTest();
            });
            t.Start();
        }
        
        static void SpeedOfTypingTest(bool running)
        {
            Console.Clear();
            Console.WriteLine("Нажмите Enter чтобы начать");
            key = Console.ReadKey();
            Time(running);
            
            while (running == true)
            {
                int i = 0;
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine(text);
                    Console.SetCursorPosition(0, 4);
                    while (i < text.Length)
                    {
                        char symbol = Console.ReadKey(true).KeyChar;
                        if (symbol == text[i])
                        {
                            i++;
                            CyanSymbols(i);
                        }
                    }
                }
                key = Console.ReadKey();
                Console.WriteLine("Нажмите что-то");
            }

        }
        
        static void EndOfTypingTest()
        {
            key = Console.ReadKey();
            while (key.Key != ConsoleKey.Escape)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.WriteLine("Имя: " + user.Name);
                        Console.WriteLine("Скорость в минуту: " + user.CharsPerMinute);
                        Console.WriteLine("Скорость в секунду: " + user.CharsPerSecond);
                        Console.WriteLine("                                          ");
                        userBoard.ShowBoard(); 
                        userBoard.AddUser(user.Name, user.CharsPerMinute, user.CharsPerSecond);
                        Console.WriteLine("Чтобы вернуться обратно в меню, нажмите F2");
                        Console.WriteLine("Чтобы закончить программу, нажмите Escape ");
                        break;
                    case ConsoleKey.F2:
                        Main();
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        static void SpeedOfTyping(int time)
        {
            int seconds = time / 60;
            user.CharsPerMinute = time;
            user.CharsPerSecond = seconds;
        }
        static void CyanSymbols(int length)
        {
            Console.SetCursorPosition(0, 2);
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < length; i++)
            {
                Console.Write(text[i]);
            }
            Console.SetCursorPosition(0, 2);
        }
    }
}