namespace GameOfLifeCSharp.Rules
{
    /// <summary>
    /// Any live cell with more than three live neighbours dies, as if by overcrowding.
    /// see http://codingdojo.org/cgi-bin/index.pl?KataGameOfLife
    /// </summary>
    public class CellRule2 : ICellRule
    {
        public bool RuleApplies(string currentCellValue, INeighbors neighbors)
        {
            var liveNeighborsCount = neighbors.LiveCount();
            return (currentCellValue == Config.LiveCell && liveNeighborsCount > 3);
        }

        public string NewCellValue => Config.DeadCell;
    }
}
