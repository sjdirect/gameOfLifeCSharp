using System;

namespace GameOfLifeCSharp.Rules
{
    /// <summary>
    /// Any live cell with fewer than two live neighbours dies, as if caused by underpopulation
    /// see http://codingdojo.org/cgi-bin/index.pl?KataGameOfLife
    /// </summary>
    public class CellRule1 : ICellRule
    {
        public bool RuleApplies(string currentCellValue, INeighbors neighbors)
        {
            var liveNeighborsCount = neighbors.LiveCount();
            return (currentCellValue == Config.LiveCell && liveNeighborsCount < 2);
        }

        public string NewCellValue => Config.DeadCell;
    }
}
