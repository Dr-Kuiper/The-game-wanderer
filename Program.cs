using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Roman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);
            ConsoleColor defaultColor = Console.ForegroundColor;
            char[,] map = ReadMap("map.txt");

            Task.Run(() =>
            {
                while (true)
                {
                    pressedKey = Console.ReadKey();
                }
            });


            Random rand = new Random();
            bool isGame = true;
            int xPosition = 1, yPosition = 1, xEnemyPosition = 0, yEnemiyPosition = 0;
            int score = 0;

            while (true)
            {
                xEnemyPosition = rand.Next(0, map.GetLength(0) - 1);
                yEnemiyPosition = rand.Next(0, map.GetLength(1) - 1);
                if (map[xEnemyPosition, yEnemiyPosition] == ' ')
                {
                    break;
                }
            }


            while (isGame)
            {

                Console.Clear();
                Console.CursorVisible = false;

                Console.ForegroundColor = ConsoleColor.Blue;
                DrawMap(map);

                Console.SetCursorPosition(xEnemyPosition, yEnemiyPosition);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write('&');

                Console.SetCursorPosition(xPosition, yPosition);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write('@');

                Console.SetCursorPosition(58, 0);
                Console.Write($"Score: {score}.");

                Console.ForegroundColor = defaultColor;
                Console.SetCursorPosition(0, 10);
                Console.WriteLine("Здравствуйте, мы приветствуем вас на игре Пакман, вы можете перемещаться по карте с помощью стрелочек.");

                Thread.Sleep(1000);






                HandleInput(pressedKey, ref xPosition, ref yPosition, map, ref score);
            }
        }

        private static void HandleInput(ConsoleKeyInfo pressedKey, ref int xPosition, ref int yPosition, char[,] map, ref int score)
        {
            int[] direction = GetDirection(pressedKey);

            int nextPacmanPositionX = xPosition + direction[0];
            int nextPacmanPositionY = yPosition + direction[1];

            char nextCell = map[nextPacmanPositionX, nextPacmanPositionY];

            if (nextCell == ' ' || nextCell == '.')
            {
                xPosition = nextPacmanPositionX;
                yPosition = nextPacmanPositionY;

                if (nextCell == '.') 
                {
                    score += 1;
                    map[nextPacmanPositionX, nextPacmanPositionY] = ' ';
                }

            }
        }

        private static int[] GetDirection(ConsoleKeyInfo pressedKey)
        {
            int[] direction = { 0, 0 };

            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    direction[1] = -1;
                    break;
                case ConsoleKey.DownArrow:
                    direction[1] = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    direction[0] = -1;
                    break;
                case ConsoleKey.RightArrow:
                    direction[0] = 1;
                    break;
                default:
                    Console.WriteLine("Введено неверное значение.");
                    //Console.ReadKey();
                    break;

            }

            return direction;
        }

        private static void DrawMap(char[,] map)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    Console.Write(map[i, j]);

                }
                Console.WriteLine();
            }
        }

        private static char[,] ReadMap(string path)
        {
            string[] file = File.ReadAllLines(path);

            char[,] map = new char[GetMaxLengthOfLine(file), file.Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = file[j][i];

                }
            }

            return map;
        }

        private static int GetMaxLengthOfLine(string[] lines)
        {
            int maxLength = lines[0].Length;

            foreach (string line in lines)
            {
                if (line.Length > maxLength)
                {
                    maxLength = line.Length;
                }
            }
            return maxLength;

        }
    }
}
