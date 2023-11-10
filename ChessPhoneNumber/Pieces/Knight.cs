
namespace ChessPhoneNumber.Pieces
{
	public class Knight : IPiece
	{
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int[,] PossibleMovements { get; set; }


        public Knight(int startPositionX, int startPositionY)
		{
            PositionX = startPositionX;
            PositionY = startPositionY;

            PossibleMovements = new int[,]
                {
                    { 2, 1 },
                    { 2, -1 },
                    { -2, 1 },
                    { -2, -1 },
                    { 1, 2 },
                    { 1, -2 },
                    { -1, 2 },
                    { -1, -2 }
                };
        }

        public void GetNextMovement(string[,] board, out int newRow, out int newCol)
        {
            int n = Random.Shared.Next(0, PossibleMovements.GetLength(0) - 1);

            newRow = PositionX + PossibleMovements[n, 0];
            newCol = PositionY + PossibleMovements[n, 1];


        }

        public void SetMovement(int row, int col)
        {
            PositionX = row;
            PositionY = col;
        }
    }
}

