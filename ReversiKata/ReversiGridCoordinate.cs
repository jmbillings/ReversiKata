namespace ReversiKata
{
    public class ReversiGridCoordinate
    {
        public int RowIndex { get; private set; }
        public int ColumnIndex { get; private set; }

        public ReversiGridCoordinate(int rowIndex, int columnIndex)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }
    }
}
