using LinkedList;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Snake
{
    public class Snake
    {
        public Snake()
        {
            Direction = InitialDirection();
        }
        public MyLinkedList<SnakeElement> SnakeElements { get; set; } = new MyLinkedList<SnakeElement>();
        public Direction Direction { get; set; }
        public bool Dead { get; set; } = false;
        public void DrawSnake(int difficulty, string border, string drawBorder)
        {
            try
            {
                var snakeNode = SnakeElements.Head;
                int col = 1, row = 1;
                Func<Direction> direction = ChangeDirection;

                while (!Dead)
                {
                    Apple apple = new Apple();
                    apple.SpawnApple();

                    //checks if the snake ate the apple
                    while (!Dead)
                    {
                        if (col == apple.Position.Col && row == apple.Position.Row)
                        {
                            EatApple();
                            break;
                        }
                        
                        Console.Clear();
                        if(border == "y" && drawBorder == "y")
                            DrawBorder();

                        DrawApple(apple.Position.Row, apple.Position.Col);

                        row = SnakeElements.Tail.Value.Position.Row;
                        col = SnakeElements.Tail.Value.Position.Col;

                        int[] coords = ChangePosition(row, col, direction());
                        col = coords[1];
                        row = coords[0];

                        MoveSnake(row, col, border);
                        Thread.Sleep(difficulty);                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                EndGame();
            }
        }
        public void MoveSnake(int row, int col, string border)
        {
            if (CheckSnakePosition(row, col, border))
            {
                SetConsole();

                var tail = SnakeElements.Tail;
                var current = tail;

                while (current.Previous != null)
                {
                    var currRow = current.Value.Position.Row;
                    var currCol = current.Value.Position.Col;

                    current.Value.Position.Row = row;
                    current.Value.Position.Col = col;

                    if (row == 0)
                        current.Value.Position.Row = Console.BufferHeight - 2;
                    else if(row == Console.BufferHeight - 1)
                        current.Value.Position.Row = 1;
                    else
                        row = currRow;

                    if(col == 0)
                        current.Value.Position.Col = Console.BufferWidth - 2;
                    else if(col == Console.BufferWidth - 1)
                        current.Value.Position.Col = 1;
                    else
                        col = currCol;

                    current = current.Previous;
                }
                if (row == 0)
                    current.Value.Position.Row = Console.BufferHeight - 2;
                else if (row == Console.BufferHeight - 1)
                    current.Value.Position.Row = 1;
                else
                    current.Value.Position.Row = row;

                if(col == 0)
                    current.Value.Position.Col = Console.BufferWidth - 2;
                else if(col == Console.BufferWidth - 1)
                    current.Value.Position.Col = 1;
                else
                current.Value.Position.Col = col;

                var traversalNode = SnakeElements.Head;
                while (traversalNode.Next != null)
                {
                    Console.SetCursorPosition(traversalNode.Value.Position.Col,
                        traversalNode.Value.Position.Row);
                    Console.Write(traversalNode.Value.Character);
                    traversalNode = traversalNode.Next;
                }
                Console.SetCursorPosition(traversalNode.Value.Position.Col,
                        traversalNode.Value.Position.Row);
                Console.Write(traversalNode.Value.Character);
            }
            else
                EndGame();
            
        }
        public int[] ChangePosition(int row, int col, Direction direct)
        {
            switch (direct)
            {
                case Direction.right:
                    col++;
                    Direction = Direction.right;
                    break;
                case Direction.left:
                    col--;
                    Direction = Direction.left;
                    break;
                case Direction.up:
                    row--;
                    Direction = Direction.up;
                    break;
                case Direction.down:
                    row++;
                    Direction = Direction.down;
                    break;
            }

            return new int[] { row, col };
        }
        public Direction ChangeDirection()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.RightArrow:
                        if(Direction != Direction.left)
                            return Direction.right;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Direction != Direction.right)
                            return Direction.left;
                        break;
                    case ConsoleKey.UpArrow:
                        if (Direction != Direction.down)
                            return Direction.up;
                        break;
                    case ConsoleKey.DownArrow:
                        if (Direction != Direction.up)
                            return Direction.down;
                        break;
                }
            }

            return Direction;
        }
        public Direction InitialDirection()
        {
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.RightArrow:
                    return Direction.right;
                case ConsoleKey.LeftArrow:
                    return Direction.left;
                case ConsoleKey.UpArrow:
                    return Direction.up;
                default:
                    return Direction.down;
            }
        }
        public void DrawBorder()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BufferHeight = 30;
            Console.BufferWidth = 122;

            Console.WriteLine(new string('=', 122));
            for (int i = 1; i < Console.BufferHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('|');
            }
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                Console.SetCursorPosition(i, Console.BufferHeight - 1);
                Console.Write('=');
            }
            for (int i = 1; i < Console.BufferHeight - 1; i++)
            {
                Console.SetCursorPosition(Console.BufferWidth - 1, i);
                Console.Write('|');
            }
            Console.ForegroundColor = ConsoleColor.Red;

        }
        public void DrawApple(int row, int col)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('O');
        }
        public void EatApple()
        {
            if (Direction == Direction.left)
            {
                SnakeElements.AddFirst(new SnakeElement()
                {
                    Character = '@',
                    Position = new Position(SnakeElements.Head.Value.Position.Row,
                SnakeElements.Head.Value.Position.Col + SnakeElements.Count)
                });
            }
            else
            {
                SnakeElements.AddFirst(new SnakeElement()
                {
                    Character = '@',
                    Position = new Position(SnakeElements.Head.Value.Position.Row,
                    SnakeElements.Head.Value.Position.Col - SnakeElements.Count)
                });
            }
        }
        public bool CheckSnakePosition(int row, int col, string border)
        {
            if (border == "y" &&
                (col == 0 || row == 0 || col == Console.BufferWidth - 1 || row == Console.BufferHeight - 1))
                    return false;
            else
            {
                StepOnBorder(row, col);
            }

            if (SnakeElements.Count > 3 && SnakeEatItself(row, col))
                return false;

            return true;
        }
        public bool SnakeEatItself(int row, int col)
        {
            var tail = SnakeElements.Tail;
            
            if (tail.Previous == null)
                return false;

            var curr = tail.Previous;

            while (curr.Previous != null)
            {
                if (curr.Value.Position.Row == row && curr.Value.Position.Col == col)
                    return true;
                curr = curr.Previous;
            }
            if (curr.Value.Position.Row == row && curr.Value.Position.Col == col)
                return true;

            return false;
        }
        public void EndGame()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new string(' ', 55) + "! YOU LOST !");
            Console.Beep(2200, 700);

            Dead = true;
        }
        public void SetConsole()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
        public void StepOnBorder(int row, int col)
        {
            if(row == 0)
            {
                SnakeElements.Tail.Value.Position.Row = Console.BufferHeight - 2;
            }
        }
    }
}
