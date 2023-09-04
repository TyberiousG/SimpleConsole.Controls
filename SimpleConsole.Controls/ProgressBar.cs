using System;

namespace SimpleConsole.Controls
{
    public class ProgressBar
    {
        public double Value
        {
            get { return Value; }
            set
            {

                Value = value;
                Redraw();
            }
        }
        public double MaxValue { get; set; } // the maximum value of the progress bar (default is 100)
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public string FillCharacter { get; set; } // the character used to fill the progress bar
        public string EmptyCharacter { get; set; } // the character used to fill the empty space in the progress bar
        public double BarWidth { get; set; } // the number of cells wide the progress bar will be
        public bool FullSize { get; set; } // if true, the progress bar will be the full width of the console window

        ProgressBar()
        {
            Value = 0;
            MaxValue = 100;
            BarWidth = 20;
            X = 0;
            Y = 0;
            ForegroundColor = ConsoleColor.White;
            BackgroundColor = ConsoleColor.Black;
            FillCharacter = "#";
            EmptyCharacter = "-";
        }
        public override string ToString()
        {
            return Value.ToString();
        }
        public void Redraw()
        {
            if (FullSize)
            {
                BarWidth = Console.WindowWidth;
                X = 0;
            }
            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
            Console.SetCursorPosition(X, Y);

            Console.Write("[");
            //write the fill ((percent complete)) characters
            for (int i = 0; i < BarWidth; i++)
            {
                if (i < (BarWidth * (Value / MaxValue)))
                {
                    Console.Write(FillCharacter);
                }
                else // write the empty characters
                {
                    Console.Write(EmptyCharacter);
                }
            }
            Console.Write("]");
            // default progress bar will look something like this: [##########----------]
        }
    }
}
