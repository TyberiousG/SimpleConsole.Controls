using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsole.Controls
{
    public class Label
    {
        public string Caption
        { get { return Caption; }
            set
            {
                Caption = value;
                Console.SetCursorPosition(X, Y);
                Console.ForegroundColor = ForegroundColor;
                Console.BackgroundColor = BackgroundColor;
                Console.Write(Caption);
            }
        }
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }

        public Label()
        {
            Caption = "";
            X = 0;
            Y = 0;
            ForegroundColor = ConsoleColor.White;
            BackgroundColor = ConsoleColor.Black;
        }
        public override string ToString()
        {
            return Caption;
        }

    }
}
