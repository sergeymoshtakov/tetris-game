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
            int[,] board = new int[20, 10]; // экран
            int score = 0;
            bool gameOver = false;

            // фигуры
            int[,] shapeI = { { 1, 1, 1, 1 } };
            int[,] shapeO = { { 2, 2 }, { 2, 2 } };
            int[,] shapeT = { { 0, 3, 0 }, { 3, 3, 3 } };
            int[,] shapeS = { { 0, 4, 4 }, { 4, 4, 0 } };
            int[,] shapeZ = { { 5, 5, 0 }, { 0, 5, 5 } };
            int[,] shapeJ = { { 6, 0, 0 }, { 6, 6, 6 } };
            int[,] shapeL = { { 0, 0, 7 }, { 7, 7, 7 } };

            Random random = new Random();
            int[,] currentShape = null;
            int currentShapeRow = 0;
            int currentShapeCol = 0;

            // сама игра
            while (!gameOver)
            {
                // создаем фигуру, если ее нет
                if (currentShape == null)
                {
                    int shapeIndex = random.Next(7);
                    switch (shapeIndex)
                    {
                        case 0: 
                            currentShape = shapeI; 
                            break;
                        case 1: 
                            currentShape = shapeO; 
                            break;
                        case 2: 
                            currentShape = shapeT; 
                            break;
                        case 3: 
                            currentShape = shapeS; 
                            break;
                        case 4: 
                            currentShape = shapeZ; 
                            break;
                        case 5: 
                            currentShape = shapeJ; 
                            break;
                        case 6: 
                            currentShape = shapeL; 
                            break;
                    }
                    currentShapeRow = 0;
                    currentShapeCol = board.GetLength(1) / 2 - currentShape.GetLength(1) / 2;
                }

                // отрисовка
                Console.Clear();
                Console.WriteLine("Score: " + score);
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (row >= currentShapeRow && row < currentShapeRow + currentShape.GetLength(0) &&
                            col >= currentShapeCol && col < currentShapeCol + currentShape.GetLength(1) &&
                            currentShape[row - currentShapeRow, col - currentShapeCol] != 0)
                        {
                            Console.Write(currentShape[row - currentShapeRow, col - currentShapeCol]);
                        }
                        else
                        {
                            Console.Write(board[row, col]);
                        }
                    }
                    Console.WriteLine();
                }

                // перемещение фигуры вниз
                System.Threading.Thread.Sleep(1000);
                if (currentShapeRow + currentShape.GetLength(0) == board.GetLength(0))
                {
                    // если фигура достигла дна
                    for (int row = 0; row < currentShape.GetLength(0); row++)
                    {
                        for (int col = 0; col < currentShape.GetLength(1); col++)
                        {
                            if (currentShape[row, col] != 0)
                            {
                                board[currentShapeRow + row, currentShapeCol + col] = currentShape[row, col];
                            }
                        }
                    }
                    currentShape = null;
                }
                else
                {
                    // перемещенее текущей фигуры вниз
                    currentShapeRow++;
                }

                // проверка строк
                for (int row = board.GetLength(0) - 1; row >= 0; row--)
                {
                    bool complete = true;
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (board[row, col] == 0)
                        {
                            complete = false;
                            break;
                        }
                    }
                    if (complete)
                    {
                        // удаляем заполненые строки
                        for (int r = row; r > 0; r--)
                        {
                            for (int c = 0; c < board.GetLength(1); c++)
                            {
                                board[r, c] = board[r - 1, c];
                            }
                        }
                        score += 10;
                        row++;
                    }
                }

                // проверка на завершение игры
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[0, col] != 0)
                    {
                        gameOver = true;
                        break;
                    }
                }

                // читаем вод с клавиатуры
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.LeftArrow && currentShapeCol > 0)
                    {
                        currentShapeCol--;
                    }
                    else if (key.Key == ConsoleKey.RightArrow && currentShapeCol + currentShape.GetLength(1) < board.GetLength(1))
                    {
                        currentShapeCol++;
                    }
                }
            }

            // завершаем игру
            Console.Clear();
            Console.WriteLine("Game over!");
            Console.WriteLine("Score: " + score);
            Console.ReadKey();
        }
    }
}
