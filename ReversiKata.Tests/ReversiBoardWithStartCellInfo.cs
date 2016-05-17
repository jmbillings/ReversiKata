namespace ReversiKata.Tests
{
    public class ReversiBoardWithStartCellInfo
    {
        internal ReversiBoard Board { get; private set; }
        internal ReversiGridCoordinate StartCell { get; private set; }

        public ReversiBoardWithStartCellInfo(ReversiBoard reversiBoard, ReversiGridCoordinate startCell)
        {
            Board = reversiBoard;
            StartCell = startCell;
        }
    }
}
