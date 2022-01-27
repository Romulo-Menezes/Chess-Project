using ChessGame.Entities.Enums;
using ChessGame.Entities.Exceptions;

namespace ChessGame.Entities
{
    class Board
    {
        public int QtyRows { get; private set; }
        public int QtyColumns { get; private set; }
        public Piece[,] Pieces { get; private set; }

        public Board()
        {
            QtyRows = 8;
            QtyColumns = 8;
            Pieces = new Piece[QtyRows, QtyColumns];
        }

        public Piece GetPiece(Position position)
        {
            return Pieces[position.Row, position.Column];
        }

        public bool IsEmpty(Position position)
        {
            ValidatePosition(position);
            return Pieces[position.Row, position.Column] == null;
        }

        public bool IsPositionValid(Position position)
        {
            if (position.Row < 0 || position.Row >= QtyRows || position.Column < 0 || position.Column >= QtyColumns)
            {
                return false;
            }
            return true;
        }
        public void ValidatePosition(Position position)
        {
            if (!IsPositionValid(position))
            {
                throw new ChessboardException($"The position {position} is invalid!");
            }
        }

        public void AddPiece(Piece piece, Position position)
        {
            if (!IsEmpty(position))
            {
                throw new ChessboardException("There is already a piece in that position!");
            }

            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public Piece RemovePiece(Position position)
        {
            if (IsEmpty(position))
            {
                return null;
            }

            Piece temp = Pieces[position.Row, position.Column];
            Pieces[position.Row, position.Column] = null;
            return temp;
        }

        public bool[,] GetAvailableMovements(Position position)
        {
            return Pieces[position.Row, position.Column].AvailableMovements();
        }

        public bool ExistsAvailableMovements(Position position)
        {
            return Pieces[position.Row, position.Column].ExistsAvailableMovements();
        }

        public Color GetPieceColor(Position position)
        {
            if (IsEmpty(position))
            {
                throw new ChessboardException("There is no chess piece in this position!");
            }
            return Pieces[position.Row, position.Column].Color;
        }

        public bool CanMoveTo(Position origin, Position destiny)
        {
            return Pieces[origin.Row, origin.Column].CanMoveTo(destiny);
        }

    }
}
