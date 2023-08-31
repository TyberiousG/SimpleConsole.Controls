using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsole.Controls
{
    public class ProgressBar
    {
        public double Value { get { return Value; }
            set
            {

                Value = value;
                Redraw();
            }
        }
        public double MaxValue { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public string FillCharacter { get; set; }
        public string EmptyCharacter { get; set; }
        public double BarWidth { get; set; }

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
            // default progress bar will look something like this: [##########----------]
            Console.Write("]");

        }
    }
}
