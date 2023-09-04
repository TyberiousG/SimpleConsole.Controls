using System;
using System.Timers;

namespace SimpleConsole.Controls
{
    public class Clock
    {
        private Timer ClockTick = new Timer(1000);
        

        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public bool SeparatorBlink { get; set; }
        public bool TwelveHour { get; set; }
        public Clock()
        {
            X = 0;
            Y = 0;
            ForegroundColor = ConsoleColor.White;
            BackgroundColor = ConsoleColor.Black;
            SeparatorBlink=false;
            TwelveHour = true;
        }

        public void Start()
        {
            ClockTick.Elapsed += OnClockTickElapsed;
            ClockTick.AutoReset = true;
            ClockTick.Enabled = true;
            ClockTick.Start();
        }
        public void Stop()
        {
            // Stop the timer
            ClockTick.Stop();
        }
        private void OnClockTickElapsed(object sender, ElapsedEventArgs e)
        {
            // This method will be called every second
            Draw();
        }
        public void Draw()
        {
            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
            Console.SetCursorPosition(X, Y);
            if (TwelveHour)
            {
                if (SeparatorBlink)
                {
                    Console.Write(DateTime.Now.ToString("hh:mm:ss tt"));
                }
                else
                {
                    Console.Write(DateTime.Now.ToString("hh mm ss tt"));
                }
            }
            else
            {
                if (SeparatorBlink)
                {
                    Console.Write(DateTime.Now.ToString("HH:mm:ss"));
                }
                else
                {
                    Console.Write(DateTime.Now.ToString("HH mm ss"));
                }
            }
            
            
        }
    }
}
