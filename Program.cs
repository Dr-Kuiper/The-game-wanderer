using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NextStadi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            bool isOpen = true;
            bool isPlauerInMap = false;
            int TresherInMap = 0;
            int userBalanse = 0;
            Random rand = new Random();

            char[,] map = {
                {'#', '#','#', '#', '#', '#','#', '#','#', '#','#', '#','#', '#','#', '#','#', '#','#', '#','#', '#','#', '#','#', '#','#', '#','#', '#','#'},
                {'#', ' ',' ', '#', ' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ','#'},
                {'#', ' ',' ', '#', ' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', '#',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ','#'},
                {'#', ' ',' ', '#', ' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', '#',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ','#'},
                {'#', ' ',' ', ' ', ' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', '#',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ','#'},
                {'#', ' ',' ', '#', ' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', '#',' ', ' ',' ', ' ','#', '#','#', '#',' ', ' ',' ', ' ',' ', ' ',' ', ' ','#'},
                {'#', ' ',' ', '#', ' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', '#',' ', ' ',' ', ' ','#', ' ',' ', '#',' ', ' ',' ', ' ',' ', ' ',' ', ' ','#'},
                {'#', ' ',' ', '#', '#', '#','#', '#',' ', ' ',' ', ' ',' ', '#',' ', ' ',' ', ' ','#', ' ',' ', '#',' ', ' ',' ', ' ',' ', ' ',' ', ' ','#'},
                {'#', ' ',' ', ' ', ' ', ' ',' ', '#',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ','#', ' ',' ', '#',' ', ' ',' ', ' ',' ', ' ',' ', ' ','#'},
                {'#', ' ',' ', ' ', ' ', ' ',' ', '#',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', '#',' ', ' ',' ', ' ',' ', ' ',' ', ' ','#'},
                {'#', ' ',' ', ' ', ' ', ' ',' ', '#',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ',' ', ' ','#'},
                {'#', '#','#', '#', '#', '#','#', '#','#', '#','#', '#','#', '#','#', '#','#', '#','#', '#','#', '#','#', '#','#', '#','#', '#','#', '#','#'},
            };

            int xPlauerPosition = 0;
            int yPlauerPosition = 0;

            while (!isPlauerInMap)
            {
                xPlauerPosition = rand.Next(1, map.GetLength(0) - 1);
                yPlauerPosition = rand.Next(1, map.GetLength(1) - 1);

                if (map[xPlauerPosition, yPlauerPosition] != '#')
                {
                    map[xPlauerPosition, yPlauerPosition] = '&';
                    isPlauerInMap = true;
                }

            }

            while (isOpen)
            {

                while (TresherInMap < 3)
                {
                    int xTresherPosition = rand.Next(1, map.GetLength(0) - 1);
                    int yTresherPosition = rand.Next(1, map.GetLength(1) - 1);

                    if (map[xTresherPosition, yTresherPosition] == ' ')
                    {
                        map[xTresherPosition, yTresherPosition] = '$';
                        TresherInMap++;
                    }
                    ;
                }

                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }

                Console.SetCursorPosition(0, 13);
                Console.Write("Здравствуйте мы приветствуем вас в нашей игре! \n" +
                    "Вы можете перемещаться по карте с помощью клавиш движения. \n" +
                    "Собирайте драгоценности, у вас на счету " + userBalanse + " сокровищ!\n" +
                    "Чтобы выйти из игры нажмите E - Esc. \n" +
                    "Чтобы двигаться нажимайте клавиши W - вверх, S - вниз, D - в право, A - в лево.\n" +
                    "Куда отправимся? ");



                string plauerInput = Console.ReadLine().ToUpper();
                switch (plauerInput)
                {
                    case "W":
                    case "S":
                    case "A":
                    case "D":
                        int newYPlauerPosition = 0;
                        int newXPlauerPosition = 0;

                        if (plauerInput == "W")
                        {
                            newXPlauerPosition = xPlauerPosition - 1;
                            newYPlauerPosition = yPlauerPosition;
                        }
                        else if (plauerInput == "S")
                        {
                            newXPlauerPosition = xPlauerPosition + 1;
                            newYPlauerPosition = yPlauerPosition;
                        }
                        else if (plauerInput == "A")
                        {
                            newXPlauerPosition = xPlauerPosition;
                            newYPlauerPosition = yPlauerPosition - 1;
                        }
                        else
                        {
                            newXPlauerPosition = xPlauerPosition;
                            newYPlauerPosition = yPlauerPosition + 1;
                        }

                        if (map[newXPlauerPosition, newYPlauerPosition] != '#')
                        {
                            if (map[newXPlauerPosition, newYPlauerPosition] == '$')
                            {
                                userBalanse++;
                                TresherInMap--;
                            }

                            map[xPlauerPosition, yPlauerPosition] = ' ';
                            map[newXPlauerPosition, newYPlauerPosition] = '&';

                            xPlauerPosition = newXPlauerPosition;
                            yPlauerPosition = newYPlauerPosition;
                        }
                        else
                        {
                            Console.WriteLine("К сожалению вы уткнулись в стену");
                            Console.ReadKey();
                        }

                        break;
                    case "E":
                        Console.WriteLine("Выходим из игры. \n" +
                            "Вы закончили с " + userBalanse + " сокровищ, возвращайтесь еще!");
                        Console.ReadKey();

                        isOpen = false;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод!");
                        Console.ReadKey();
                        break;





                }
                //Console.ReadKey();
                Console.Clear();
                Console.SetCursorPosition(0, 0);
            }

        }
    }
}
