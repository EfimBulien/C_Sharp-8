namespace Скоропечатание
{
    public class User
    {
        public User( string name, double minute, double second)
        {
            this.Name = name;
            this.CharsPerMinute = minute;
            this.CharsPerSecond = second;
        }
        
        public string Name { get; set; }    
        public double CharsPerMinute { get; set; }
        public double CharsPerSecond { get; set; }
        
        public User()
        {
            
        }
    }
}