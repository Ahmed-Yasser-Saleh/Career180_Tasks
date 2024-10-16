namespace Task_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Duration a = new Duration(15000);
            Duration b = new Duration(18000);
            Console.WriteLine(a + b);
            int num_min = 5;
            Console.WriteLine(a + num_min); //increase number of minutes
            Console.WriteLine(++a); //increase minute
            Console.WriteLine(--a); //decrease minute
            Console.WriteLine(a < b);
            Console.WriteLine(a > b);
            Console.WriteLine(a <= b);
            Console.WriteLine(a >= b);
            DateTime obj = (DateTime)b;
            Console.WriteLine(obj);
            Console.WriteLine(a.Equals(b));
        }
        class Duration
        {
            private int duration;
            public int Hour { get; set; }
            public int Minute { get; set; }

            public int Second { get; set; }

            public Duration(int duration)
            {
                this.duration = duration;
                this.Hour = duration / 3600;
                this.Minute = (duration % 3600) / 60;
                this.Second = duration % 60;
            }
            public static Duration operator +(Duration d1, Duration d2)
            {
                var value = d1.duration + d2.duration;
                return new Duration(value);
            }

            public static Duration operator +(Duration d1, int min)
            {
                var value = d1.duration + 60 * min;
                return new Duration(value);
            }

            public static Duration operator ++(Duration d2)
            {
                var value = d2.duration + 60;
                return new Duration(value);
            }

            public static Duration operator --(Duration d2)
            {
                var value = d2.duration - 60;
                return new Duration(value);
            }

            public static bool operator <(Duration d1, Duration d2)
            {
                return d1.duration < d2.duration;
            }

            public static bool operator >(Duration d1, Duration d2)
            {
                return d1.duration > d2.duration;
            }
            public static bool operator <=(Duration d1, Duration d2)
            {
                return d1.duration <= d2.duration;
            }

            public static bool operator >=(Duration d1, Duration d2)
            {
                return d1.duration >= d2.duration;
            }
            public static explicit operator DateTime(Duration d1)
            {
                DateTime referenceDate = DateTime.MinValue;  // 1/1/0001
                return referenceDate.AddHours(d1.Hour).AddMinutes(d1.Minute).AddSeconds(d1.Second);
            }
            public override bool Equals(object? obj)
            {
                var Dur = obj as Duration;
                if(Dur == null) return false;
                return this.duration == Dur.duration;
            }
            public override string ToString()
            {
                return $"Duraion: {duration} -> Hours: {Hour}, Minutes: {Minute}, Seconds: {Second}";
            }
        }
    }
}
