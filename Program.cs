
using System;

namespace ToyRobot
{
    public enum Direction
    {
        NORTH,
        SOUTH,
        EAST,
        WEST
    }

    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Facing { get; set; }
        public bool IsPlaced { get; set; }

        public Robot()
        {
            IsPlaced = false;
        }

        public void Place(int x, int y, Direction facing)
        {
            if (IsValidPosition(x, y))
            {
                X = x;
                Y = y;
                Facing = facing;
                IsPlaced = true;
            }
        }

        public void Move()
        {
            if (!IsPlaced)
                return;

            int newX = X;
            int newY = Y;

            switch (Facing)
            {
                case Direction.NORTH:
                    newY++;
                    break;
                case Direction.SOUTH:
                    newY--;
                    break;
                case Direction.EAST:
                    newX++;
                    break;
                case Direction.WEST:
                    newX--;
                    break;
            }

            if (IsValidPosition(newX, newY))
            {
                X = newX;
                Y = newY;
            }
        }

        public void RotateLeft()
        {
            if (!IsPlaced)
                return;

            switch (Facing)
            {
                case Direction.NORTH:
                    Facing = Direction.WEST;
                    break;
                case Direction.SOUTH:
                    Facing = Direction.EAST;
                    break;
                case Direction.EAST:
                    Facing = Direction.NORTH;
                    break;
                case Direction.WEST:
                    Facing = Direction.SOUTH;
                    break;
            }
        }

        public void RotateRight()
        {
            if (!IsPlaced)
                return;

            switch (Facing)
            {
                case Direction.NORTH:
                    Facing = Direction.EAST;
                    break;
                case Direction.SOUTH:
                    Facing = Direction.WEST;
                    break;
                case Direction.EAST:
                    Facing = Direction.SOUTH;
                    break;
                case Direction.WEST:
                    Facing = Direction.NORTH;
                    break;
            }
        }

        public void Report()
        {
            if (!IsPlaced)
                return;

            Console.WriteLine($"{X},{Y},{Facing}");
        }

        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < 5 && y >= 0 && y < 5;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Robot robot = new Robot();

            // Example commands
            var inputX = int.Parse(Console.ReadLine());

            var inputY = int.Parse(Console.ReadLine());
           

            Console.WriteLine("Choose the direction \n 1 NORTH \n 2 SOUTH \n 3 EAST \n 4 WEST");
            string Dir = "0";
            Dir = Console.ReadLine();
            switch (Dir)
            {
                case "1":                    
                    robot.Place(inputX, inputY, Direction.NORTH);
                    robot.Move();
                    robot.Report();
                    break;
                case "2":
                    robot.Place(inputX, inputY, Direction.SOUTH);
                    robot.Move();
                    robot.Report();
                    break;
                case "3":
                    robot.Place(inputX, inputY, Direction.EAST);
                    robot.Move();
                    robot.Report();
                    break;
                case "4":
                    robot.Place(inputX, inputY, Direction.WEST);
                    robot.Move();
                    robot.Report();
                    break;
            }


            robot.Place(0, 0, Direction.NORTH);
            robot.RotateLeft();
            robot.Report();
        }
    }
}

