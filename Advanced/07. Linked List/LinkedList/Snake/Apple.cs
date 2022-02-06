﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    public class Apple
    {
        public char Character { get; set; }
        public Position Position { get; set; }
        public void SpawnApple()
        {
            var rand = new Random();
            int col = rand.Next(2, 118);
            int row = rand.Next(2, 29);
            Position = new Position(row, col);
            Console.SetCursorPosition(col, row);
            Console.Write('Q');
        }
    }
}
