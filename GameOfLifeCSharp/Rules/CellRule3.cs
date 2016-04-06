namespace GameOfLifeCSharp.Rules
{
    /// <summary>
    /// Any live cell with two or three live neighbours lives on to the next generation.
    /// see http://codingdojo.org/cgi-bin/index.pl?KataGameOfLife
    /// </summary>
    public class CellRule3 : ICellRule
    {
        public bool RuleApplies(string currentCellValue, INeighbors neighbors)
        {
            var liveNeighborsCount = neighbors.LiveCount();
            return (currentCellValue == Config.LiveCell && 
                (liveNeighborsCount == 2 || liveNeighborsCount == 3));
        }

        public string NewCellValue => Config.LiveCell;
    }
}
