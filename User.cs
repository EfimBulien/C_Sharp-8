namespace Скоропечатание
{
    public class User
    {
        public string UserName { get; set; }    
        public double CharsPerMinute { get; set; }
        public double CharsPerSecond { get; set; }
        public User( string name, double minutes, double seconds)
        {
            this.UserName = name;
            this.CharsPerMinute = minutes;
            this.CharsPerSecond = seconds;
        }
        public User()
        {
            
        }
    }
}
