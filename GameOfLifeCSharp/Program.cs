using System;
using System.Linq;

namespace GameOfLifeCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] firstGeneration = 
            {
                 //Rows
                 //0,0  0,1  0,2  0,3  0,4  0,5  0,6  0,7    // Columns
                 { ".", ".", ".", ".", ".", ".", ".", "." }, // 0,7
                 { ".", ".", ".", ".", "*", ".", ".", "." }, // 1,7
                 { ".", ".", ".", "*", "*", ".", ".", "." }, // 2,7
                 { ".", ".", ".", ".", ".", ".", ".", "." }, // 3,7
            };

            IGameOfLife gof = new GameOfLife();
            string[,] nextGeneration = firstGeneration;
            for (var i = 1; i <= Config.Reptitions; i++)
            {
                Console.WriteLine($"Generation {i}:");
                gof.PrintGeneration(nextGeneration);

                nextGeneration = gof.GetNextGeneration(nextGeneration);
            }
        }
    }
}
