﻿using System;
using System.Collections.Generic;

namespace SimpleConsole.Controls
{
    public class ComboBox
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public List<string> Items { get; set; }
        public int SelectedIndex { get; set; }
        public int MaxLength { get; set; }
        public string SelectedText { get; set; }
        private bool _isExpanded;

        
        public ComboBox()
        {
            X = 0;
            Y = 0;
            ForegroundColor = ConsoleColor.White;
            BackgroundColor = ConsoleColor.Black;
            Items = new List<string>();
            SelectedIndex = 0;
            MaxLength = 20;
            SelectedText = "";
            _isExpanded = false;
        }
        public void HideList()
        {
              Console.SetCursorPosition(X, Y+1);
            for (int i = 0; i < Items.Count; i++)
            {
                for (int j = 0; j < MaxLength; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public void ShowList()
        {
            while (true) // loop to keep the combobox open until the user chooses an item or presses escape
            {
                //draw the list of options (Items) in the combobox
                Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
            Console.SetCursorPosition(X, Y+1);
            for (int i = 0; i < Items.Count; i++)
            {
                if (i==SelectedIndex)
                {
                    Console.Write($">{Items[i]}");
                }
                else {
                    Console.Write($" {Items[i]}");
                     }
                
                for (int j = Items[i].Length-1; j < MaxLength-1; j++) // fill the rest of the line with spaces so the combobox is uniform
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            //switch to catch input from the user choosing an item
            
            
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (SelectedIndex > 0)
                        {
                            SelectedIndex--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (SelectedIndex < Items.Count - 1)
                        {
                            SelectedIndex++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        SelectedText = Items[SelectedIndex];
                        SelectedIndex = Items.IndexOf(SelectedText);
                        Draw();
                        HideList();
                        _isExpanded = false;
                        break;
                    case ConsoleKey.Escape:
                        HideList();
                        _isExpanded = false;
                        break;
                }
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
            Console.Write(SelectedText);
            for (int i = SelectedText.Length; i < MaxLength; i++) // fill the rest of the line with spaces so the combobox is uniform
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(X, Y);

        }
        public void SetFocus()
        {
            Console.SetCursorPosition(X, Y);
            for (int i = 0; i < MaxLength; i++) // paint the background of the combobox
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(X, Y);
            ConsoleKeyInfo key = Console.ReadKey(true);
            if ((key.Key == ConsoleKey.Enter) && (_isExpanded==false))
            {
                ShowList();
            }
            else if (key.Key==ConsoleKey.Tab)
            {
                  HideList();
                _isExpanded = false;
            }

        }
    }
}