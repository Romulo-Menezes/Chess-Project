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

        public Position ToPosition()
        {
            return new Position(8 - Row, Column - 'a');
        }

    }
}
