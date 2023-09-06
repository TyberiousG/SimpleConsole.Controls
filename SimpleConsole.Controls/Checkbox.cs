using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsole.Controls
{
    public class Checkbox
    {
        public bool Checked { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public string CheckedCharacter { get; set; }
        public string UncheckedCharacter { get; set; }
        public string Caption { get; set; }
        public Checkbox()
        {
            Checked = false;
            Caption = "";
            X = 0;
            Y = 0;
            ForegroundColor = ConsoleColor.White;
            BackgroundColor = ConsoleColor.Black;
            CheckedCharacter = "X";
            UncheckedCharacter = " ";
        }
        public override string ToString()
        {
            return Checked.ToString();
        }
        public void SetFocus()
        {
            while (true) //
            {
                Draw();
                Console.SetCursorPosition(X + 1, Y);
                char key = Console.ReadKey(true).KeyChar;
                if (key == ' ')
                {

                    if (Checked) // changing from checked to unchecked status
                    {
                        Checked = false;
                        Console.Write(UncheckedCharacter);
                    }
                    else        // changing from unchecked to checked status
                    {
                        Checked = true;
                        Console.Write(CheckedCharacter);
                    }
                    Console.SetCursorPosition(X + 1, Y);
                }
                else if (key == '\r')
                {
                    break;
                }
            }
        }
        public void Draw()
        {
            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
            Console.SetCursorPosition(X, Y);
            if (Checked)
            {
                Console.Write($"[{CheckedCharacter}] {Caption}");
            }
            else
            {
                Console.Write($"[{UncheckedCharacter}] {Caption}");
            }
        }
    }
}
