using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsole.Controls
{
    public class TextBox
    {
        public string Value { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int MaxLength { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public bool IsFocused { get; set; }

        public TextBox()
        {
            Value = "";
            X = 0;
            Y = 0;
            MaxLength = 0;
            ForegroundColor = ConsoleColor.White;
            BackgroundColor = ConsoleColor.Black;
            IsFocused = true;
        }
        public override string ToString()
        {
            return Value;
        }
        public void SetFocus()
        {
            string retval = Value;
            IsFocused = true;
            Console.SetCursorPosition(X+Value.Length, Y);
            while (true)
                {
                ConsoleKeyInfo Capture = Console.ReadKey(true);
                if (Capture.Key == ConsoleKey.Enter)
                {
                    Value=retval;
                    break;
                }
                if (Capture.Key == ConsoleKey.Backspace)
                {
                    if (retval.Length > 0)
                    {
                        retval = retval.Remove(retval.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    if (retval.Length < MaxLength)
                    {
                        retval += Capture.KeyChar;
                        Console.Write(Capture.KeyChar);
                    }
                }
                }
            }

        }
    }
}
