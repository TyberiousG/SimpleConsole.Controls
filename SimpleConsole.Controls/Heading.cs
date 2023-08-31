using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsole.Controls
{
    public class Heading // This is the Heading class -- this is a label that is centered on the screen between the constraints of the entire console window.
    {
        public string Caption
        {
            get { return Caption; }
            set
            {
                Caption = value;
                Console.SetCursorPosition((Console.WindowWidth/2) - Caption.Length, Y);
                Console.ForegroundColor = ForegroundColor;
                Console.BackgroundColor = BackgroundColor;
                Console.Write(Caption);
            }
        }
        
        public int Y { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }

        public Heading()
        {
            Caption = "";
            
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
