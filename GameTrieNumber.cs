using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random rand = new Random();
            int value = rand.Next(0, 101);

            int beginInt = rand.Next(value - 10, value);
            int endInt = rand.Next(value + 1, value + 10);

            float mevievalInt = (Convert.ToSingle(endInt) - beginInt) / 2;
            int numOfAttemp = Convert.ToInt32(mevievalInt) + 1;
            int userInput;
            Console.WriteLine($"Добро пожаловать в игру угадай число! У Вас будет попток: {numOfAttemp}, чтобы угадасть число от {beginInt} до {endInt + 1}!");

            for (int i = 0; i < numOfAttemp; i++)
            {
                Console.Write("Ваше число: ");
                userInput =  Convert.ToInt32(Console.ReadLine());

                if (userInput == value)
                {
                    Console.WriteLine("Поздравляем, Вы победили! Это число действительно было " + value +".");
                    return;
                }
                else
                {
                    if (i == numOfAttemp - 1)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("К сожалению вы не угадали, попробуйте еще раз ");
                    }
                }

            }
            Console.WriteLine("К сожалению вам не удалось угадать число! Число было: " + value);

        }
    }
}
