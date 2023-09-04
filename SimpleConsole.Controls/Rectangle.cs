using System;

namespace SimpleConsole.Controls
{
    public class Rectangle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public ConsoleColor BColor { get; set; }
        public ConsoleColor FColor { get; set; }

        public Rectangle()
        {
            X = 0;
            Y = 0;
            Width = 0;
            Height = 0;
            BColor = ConsoleColor.Black;
            FColor = ConsoleColor.White;
        }

        public void Draw()
        {
            ConsoleColor currentFG = Console.ForegroundColor;
            ConsoleColor currentBG = Console.BackgroundColor;

            string ulCorner = "╔";
            string urCorner = "╗";
            string llCorner = "╚";
            string lrCorner = "╝";
            string vert = "║";
            string horz = "═";
            int totHorz = Width - 2;
            int totVert = Height - 2;

            Console.SetCursorPosition(X, Y);
            Console.Write(ulCorner);

            for (int i = 1; i <= totHorz; i++)
            {
                Console.Write(horz);
            }

            Console.Write(urCorner);
            Console.WriteLine();

            int curX = Console.CursorLeft;
            int curY = Console.CursorTop;

            for (int j = 1; j <= totVert; j++)
            {
                Console.SetCursorPosition(X, curY);
                Console.Write(vert);

                for (int k = 1; k <= totHorz; k++)
                {
                    Console.Write(" ");
                }

                Console.Write(vert);
                Console.Write(Environment.NewLine);
                curY++;
            }

            Console.SetCursorPosition(X, curY);
            Console.Write(llCorner);

            for (int l = 1; l <= totHorz; l++)
            {
                Console.Write(horz);
            }

            Console.Write(lrCorner);
            Console.BackgroundColor = currentBG;
            Console.ForegroundColor = currentFG;
        }
    }
}