using System;

namespace SimpleConsole.Controls
{
    public class TextBox // This is the TextBox class -- this can also function as a password box with a masked input of "*" characters if the IsPassword property is set to true.
    {
        public string Value { get; set; }
        public int X { get; set; } // defines in which row of the window the first character of the textbox will be placed.
        public int Y { get; set; } // defines in which column of the window the first character of the textbox will be placed.
        public int MaxLength { get; set; } // defines the maximum number of characters that can be entered into the textbox.
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public bool HasFocus { get; set; } // defines whether or not the textbox has focus. ((is actively being typed into))
        public bool IsPassword { get; set; } // defines whether or not the textbox is a password box. ((if true, the input will be masked with "*" characters.))
        public TextBox() // default constructor.
        {
            Value = "";
            X = 0;
            Y = 0;
            MaxLength = 0;
            IsPassword = false;
            ForegroundColor = ConsoleColor.White;
            BackgroundColor = ConsoleColor.Black;
            HasFocus = true;
        }
        public override string ToString() // override the ToString() method to return the value of the textbox. ((this is useful for debugging purposes, but at runtime the Textbox.Value property should be used instead.))
        {
            return Value;
        }
        public void SetFocus() 
        {

            string retval = Value;
            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(Value); // if this textbox has already been constructed, then the value of the textbox will be written to the screen.
            HasFocus = true;
            Console.SetCursorPosition(X + Value.Length, Y);
            while (true)
            {
                ConsoleKeyInfo Capture = Console.ReadKey(true);
                if (Capture.Key == ConsoleKey.Enter) // if the user presses the enter key, then the value of the textbox will be finalized and the loop will be broken.
                {
                    Value = retval;
                    HasFocus = false;
                    break;
                }
                if (Capture.Key == ConsoleKey.Backspace) // if the user presses the backspace key, then the last character of the textbox will be removed.
                {
                    if (retval.Length > 0)
                    {
                        retval = retval.Remove(retval.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    if ((retval.Length < MaxLength) && (Capture.Key != ConsoleKey.Backspace) && (Capture.Key != ConsoleKey.Enter))
                    {
                        retval += Capture.KeyChar;
                        if(IsPassword)
                            Console.Write("*");
                        else
                        Console.Write(Capture.KeyChar);
                    }
                }
            }
            Value = retval; // finalize the value of the textbox and commit it to the Value property.
            HasFocus = false;
        }

    }
}
