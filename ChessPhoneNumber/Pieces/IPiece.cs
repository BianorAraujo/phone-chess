using System;
namespace ChessPhoneNumber.Pieces
{
	public interface IPiece
	{
        int PositionX { get; set; }
        int PositionY { get; set; }
        

        void GetNextMovement(string[,] board, out int newRow, out int newCol);

        void SetMovement(int row, int col);
    }
}

