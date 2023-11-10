using System;
using ChessPhoneNumber.Keyboard;
using ChessPhoneNumber.Pieces;

namespace ChessPhoneNumber
{
	public class Generate
	{
		private IKeyboard Keyboard;
        string[,] board;


        public Generate()
		{
            Keyboard = new Phone();
            board = Keyboard.GetKeyboard();
		}

		public string PrintBoard()
		{
			string boardToPrint = string.Empty;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    boardToPrint += board[i,j].ToString().PadLeft(3);
                }

				boardToPrint += Environment.NewLine;
            }


            return boardToPrint;
		}


        public string GetPhoneNumber(string selectedPiece, string selectedPosition)
		{
			if (Keyboard.IsValidStartNumber(selectedPosition))
			{
                int row, col;
                string result = string.Empty;

                GetPositionCoordinates(Convert.ToInt32(selectedPosition), out row, out col);

                IPiece Piece = SetPiece(selectedPiece, row, col);

                if (Piece == null)
                    return "Piece invalid!";

                for (int i = 1; i <= 7; i++)
                {
                    if (i == 1)
                    {
                        result += selectedPosition;
                        continue;
                    }

                    //int newRow, newCol;

                    //do
                    //{
                    //    Piece.GetNextMovement(board, out newRow, out newCol);

                    //}
                    //while (!Keyboard.IsValidPosition(newRow, newCol));


                    //Piece.SetMovement(newRow, newCol);

                    result += GetMovement(Piece, Keyboard, board);//GetNewPosition(newRow, newCol);

                    if (result.Length == 3)
                        result += "-";

                }

                return result;
			}
			else
			{
                return "Invalid initial position, need to be between 2 and 9.";
            }
		}

        public string GetMovement(IPiece piece, IKeyboard keyboard, string[,] board)
        {
            int newRow, newCol;

            do
            {
                piece.GetNextMovement(board, out newRow, out newCol);
            }
            while (!Keyboard.IsValidPosition(newRow, newCol));


            piece.SetMovement(newRow, newCol);

            return GetNewPosition(newRow, newCol);
        }

        public void GetPositionCoordinates(int position, out int row, out int col)
        {
            string[,] board = Keyboard.GetKeyboard();
            
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i,j].Equals(position.ToString()))
                    {
                        row = i;
                        col = j;
                        return;
                    }
                }

            }

            row = -1;
            col = -1;
        }

        private string GetNewPosition(int row, int col)
        {
            return board[row, col];
        }

        private IPiece SetPiece(string selectedPiece, int row, int col)
        {
            switch (selectedPiece)
            {
                case "1":
                    return new King(row, col);
                case "2":
                    return new Knight(row, col);
                case "3":
                    return new Rook(row, col);
                default:
                    return null;
            }
        }

    }
}

