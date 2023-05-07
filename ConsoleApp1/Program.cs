using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(20, 10);
            int answ = 0;
            while(answ != 2)
            {
                Console.WriteLine("Choose option:\n1 - Start new Game\n2 - Exit");
                answ = Convert.ToInt32(Console.ReadLine());
                switch(answ)
                {
                    case 1:
                        Console.Clear();
                        game.GameOver = false;
                        // сама игра
                        while (!game.GameOver)
                        {
                            game.CreateFigure(); // создаем фигуры
                            game.DrawBoard(); // отрисовываем экран
                            game.MoveDown(); // перемещаем фигуры вниз
                            game.ErraseFull(); // стираем заполненые строки
                            game.EndGame(); // конец игры
                            game.HandleAction(); // перемещаем в лево и в право
                        }

                        // завершаем игру
                        Console.Clear();
                        Console.WriteLine("Game over!");
                        Console.WriteLine("Score: " + Player.Score);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Good bye");
                        break;
                    default:
                        Console.WriteLine("Wrong input!");
                        break;
                }
            }
        }
    }
}