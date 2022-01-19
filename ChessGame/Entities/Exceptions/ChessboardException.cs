using System;

namespace ChessGame.Entities.Exceptions
{
    class ChessboardException : Exception
    {
        public ChessboardException(string message) : base(message)
        {
        }
    }
}
