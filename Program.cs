using System;
using System.Threading;
using Скоропечатание;

namespace TypingSpeed
{
    internal class Program
    {
        static int letter = 0;
        static bool running = true;
        static User user = new User();
        static UserBoard userBoard = new UserBoard();
        static string text = 
            "Тихий вечер. Город угрюмо молчит. Огоньки улиц освещают пустые тротуары. Ветер ласкает лица прохожих, " +
            "несет запах дождя. Вдалеке слышится шум автомобилей, затихающий в ритме городской ночи. На углу старого здания " +
            " стоит мужчина. В его глазах отражается усталость и загадка. Он держит в руках старую фотографию. Лица на ней знакомы," +
            "но время оставило на них свой след. Мужчина поворачивает на переулок, где замерзшая лужайка украшена первыми инеем. " +
            " В его сердце таится воспоминание о прошлом, которое словно давно забыто, но не отпускает. В этом мгновении, под светом " +
            " уличных фонарей, проходит момент решения. Мужчина решает отправиться в путь. Городские огоньки теряют свой смысл, когда" +
            " сердце наполняется тяжким чувством ожидания неизведанного. Так начинается новая глава в его жизни. Впереди непознанные " +
            " её. Но стоило ей положить фигурку в сумку и с облегчением вздохнуть, как один из друзей со свёртками шёлка в руках похлопал " +
            " её по плечу. дороги, таинственные встречи и ответы на вопросы, которые долго прятало прошлое. Его взгляд был устремлен вдаль... ";
        static ConsoleKeyInfo keyInfo;
        
        static void Main()
        {
            do
            {
                Console.WriteLine("Введите ваше имя: ");
                user.UserName = Console.ReadLine();
                SpeedOfTypingTest();
                keyInfo = Console.ReadKey();
                Console.SetCursorPosition(0, 0);
            } while (keyInfo.Key != ConsoleKey.F1);
        }
        
        static void SpeedOfTypingTest()
        {
            Console.Clear();
            Console.WriteLine("Нажмите Enter чтобы начать");
            keyInfo = Console.ReadKey();
            TimeOfTyping();
            
            while (running == true)
            {
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(text);
                    Console.SetCursorPosition(0, 0);

                    while (letter < text.Length)
                    {
                        char symbol = Console.ReadKey(true).KeyChar;
                        if (symbol == text[letter])
                        {
                            letter++;
                            CyanSymbols(letter);
                        }
                    }
                }
            }
        }
        
        private static void TimeOfTyping()
        {
            Thread thread = new Thread(_ =>
            {
                int top = 8;
                DateTime dateTime = DateTime.Now;
                DateTime timer = dateTime.AddMinutes(-1);

                while (dateTime >= timer && running)
                {
                    Console.SetCursorPosition(0, top);
                    if (letter == text.Length)
                    {
                        running = false;
                    }
                    Console.SetCursorPosition(0, top);
                    long ticks = (dateTime - timer).Ticks;
                    Console.SetCursorPosition(0, top);
                    Console.WriteLine(new DateTime(ticks).ToString("ss"));
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(0, top);
                    timer = timer.AddSeconds(1);
                    Console.SetCursorPosition(0, top);
                }
                Console.Clear();
                Console.WriteLine("Ваше время вышло");
                SpeedOfTyping();
                EndOfTypingTest();
            });
            thread.Start();
        }
        
        static void SpeedOfTyping()
        {
            user.CharsPerMinute = letter;
            user.CharsPerSecond = letter / 60;
        }
        
        static void EndOfTypingTest()
        {
            try
            {
                keyInfo = Console.ReadKey();
                while (keyInfo.Key != ConsoleKey.Escape)
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.Enter:
                            Console.Clear();
                            Console.WriteLine("Имя: " + user.UserName);
                            Console.WriteLine("Скорость в минуту: " + user.CharsPerMinute);
                            Console.WriteLine("Скорость в секунду: " + user.CharsPerSecond);
                            Console.WriteLine("                                          ");
                            //userBoard.AddRecords();
                            userBoard.ShowBoard();
                            userBoard.AddUser(user.UserName, user.CharsPerMinute, user.CharsPerSecond);
                            userBoard.Serialization();
                            Console.WriteLine("Чтобы вернуться обратно в меню, вернитесь через Escape");
                            Console.WriteLine("Чтобы закончить программу, нажмите F");
                            break;
                        case ConsoleKey.Escape:
                            Main();
                            break;
                        case ConsoleKey.F:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        static void CyanSymbols(int lenght)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (letter = 0; letter < lenght; letter++)
            {
                Console.Write(text[letter]);
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}
