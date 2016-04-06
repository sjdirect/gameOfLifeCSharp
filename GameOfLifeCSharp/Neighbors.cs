using System.Linq;

namespace GameOfLifeCSharp
{
    public interface INeighbors
    {
        string Bottom { get; set; }
        string BottomLeft { get; set; }
        string BottomRight { get; set; }
        string Left { get; set; }
        string Right { get; set; }
        string Top { get; set; }
        string TopLeft { get; set; }
        string TopRight { get; set; }

        int DeadCount();
        int LiveCount();
        string[] ToArray();
    }

    public class Neighbors : INeighbors
    {
        public string Left { get; set; }
        public string Right { get; set; }

        public string Top { get; set; }
        public string TopLeft { get; set; }
        public string TopRight { get; set; }

        public string Bottom { get; set; }
        public string BottomLeft { get; set; }
        public string BottomRight { get; set; }

        public int LiveCount()
        {
            return ToArray().Count(v => v != null && v == Config.LiveCell);
        }

        public int DeadCount()
        {
            return ToArray().Count(v => v != null && v == Config.DeadCell);
        }

        public string[] ToArray()
        {
            return new[] { Left, Right, Top, Bottom, TopLeft, TopRight, BottomLeft, BottomRight };
        }
    }
}
