namespace ChessGame.Entities
{
    class ChessPosition
    {
        public int Row { get; set; }
        public char Column { get; set; }

        public ChessPosition(int row, char column)
        {
            Row = row;
            Column = column;
        }

        public static Position StringToPosition(string sPosition)
        {
            char column = sPosition[0];
            int row = int.Parse(sPosition[1] + "");

            return new ChessPosition(row, column).ToPosition();
        }

        public Position ToPosition()
        {
            return new Position(8 - Row, Column - 'a');
        }

    }
}
