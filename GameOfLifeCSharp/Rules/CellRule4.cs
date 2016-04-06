using System;

namespace GameOfLifeCSharp.Rules
{
    /// <summary>
    /// Any dead cell with exactly three live neighbours becomes a live cell
    /// see http://codingdojo.org/cgi-bin/index.pl?KataGameOfLife
    /// </summary>
    public class CellRule4 : ICellRule
    {
        public bool RuleApplies(string currentCellValue, INeighbors neighbors)
        {
            var liveNeighborsCount = neighbors.LiveCount();
            return (currentCellValue == Config.DeadCell && liveNeighborsCount == 3);
        }

        public string NewCellValue => Config.LiveCell;
    }
}
