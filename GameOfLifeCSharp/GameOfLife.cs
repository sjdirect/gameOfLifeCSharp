using System;
using System.Collections.Generic;
using GameOfLifeCSharp.Rules;

namespace GameOfLifeCSharp
{
    public interface IGameOfLife
    {
        string[,] GetNextGeneration(string[,] generation);
        INeighbors GetNeighbors(string[,] generation, int row, int column);
        void PrintGeneration(string[,] generation);
        string ApplyRules(string currentCellValue, INeighbors neighbors);
    }

    public class GameOfLife : IGameOfLife 
    {
        readonly int _rowMax;
        readonly int _columnMax;
        readonly IEnumerable<ICellRule> _rules;

        public GameOfLife()
            : this(
                  Config.MaxRow, 
                  Config.MaxColumns, 
                  new List<ICellRule>()
                  {
                      new CellRule1(),
                      new CellRule2(),
                      new CellRule3(),
                      new CellRule4()
                  })
        {

        }

        public GameOfLife(int rowMax, int columnMax, IEnumerable<ICellRule> rules)
        {
            _rowMax = rowMax - 1;
            _columnMax = columnMax - 1;
            _rules = rules;
        }

        public string[,] GetNextGeneration(string[,] generation)
        {
            string[,] nextGeneration = generation;//new string[generation.GetLength(0), generation.GetLength(1)];
            
            for (var row = 0; row < generation.GetLength(0); row++)
            {
                for (var column = 0; column < generation.GetLength(1); column++)
                {
                    var neighbors = GetNeighbors(generation, row, column);
                    nextGeneration[row, column] = ApplyRules(generation[row, column], neighbors);
                }
                    
                Console.WriteLine("");//For newline
            }

            return generation;
        }

        public string ApplyRules(string currentCellValue, INeighbors neighbors)
        {
            foreach (var rule in _rules)
            {
                if(rule.RuleApplies(currentCellValue, neighbors))
                    return rule.NewCellValue;
            }

            return Config.DeadCell;
        }

        public INeighbors GetNeighbors(string[,] generation, int row, int column)
        {
            var neighbor = new Neighbors();

            //Get left and right values
            if (column > 0)
                neighbor.Left = generation[row, column - 1];

            if (column < _columnMax)
                neighbor.Right = generation[row, column + 1];

            //Get top values
            if (row > 0)
            {
                neighbor.Top = generation[row - 1, column];
                if (column > 0)
                    neighbor.TopLeft = generation[row - 1, column - 1];

                if (column < _columnMax)
                    neighbor.TopRight = generation[row - 1, column + 1];
            }

            //Get bottom values
            if (row < _rowMax)
            {
                neighbor.Bottom = generation[row + 1, column];
                if (column > 0)
                    neighbor.BottomLeft = generation[row + 1, column - 1];

                if (column < _columnMax)
                    neighbor.BottomRight = generation[row + 1, column + 1];
            }

            return neighbor;
        }

        public void PrintGeneration(string[,] generation)
        {
            for (var row = 0; row < generation.GetLength(0); row++)
            {
                for (var column = 0; column < generation.GetLength(1); column++)
                    Console.Write(generation[row, column]);

                Console.Write(Environment.NewLine);
            }
        }
    }
}
