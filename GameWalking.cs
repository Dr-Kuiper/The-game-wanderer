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
            int health = 5, maxHilth = 10, positionHilth = 0;
            int mana = 7, maxMana = 10, positionMana = 1;
            bool isOpen = true;
            
            while (isOpen)
            {
                DrawBar(health, maxHilth, ConsoleColor.Green, positionHilth, '-');
                DrawBar(mana, maxMana, ConsoleColor.Blue, positionMana);
                
                Console.SetCursorPosition(0, 5);
                Console.Write("Введите чисто, на которе изменятся жизни: ");
                health += Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите чисто, на которе изменится мана: ");
                mana += Convert.ToInt32(Console.ReadLine());
                if (health <= 0) {
                    Console.SetCursorPosition(0, 7);
                    Console.WriteLine("Вы проиграли!");
                    isOpen = false;
                    Console.ReadKey();
                }
                Console.Clear();
                //Console.ReadKey();




            }


        }

        static void DrawBar(int value, int maxValue, ConsoleColor color, int position, char simbol = '_')
        {
            ConsoleColor defaultColor = Console.BackgroundColor;

            string bar = "";


            for (int i = 0; i < value; i++)
            {
                bar += simbol;
            }


            Console.SetCursorPosition(0, 0 + position);
            Console.Write('[');
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = defaultColor;


            bar = "";

            for (int i = value; i < maxValue; i++)
            {
                bar += simbol;
            }
            Console.Write(bar);
            Console.Write(']');





        }



    }
}
