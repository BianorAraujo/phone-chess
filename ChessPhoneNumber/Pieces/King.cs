
namespace ChessPhoneNumber.Pieces
{
    public class King : IPiece
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int[,] PossibleMovements { get; set; }

        public King(int startPositionX, int startPositionY)
        {
            PositionX = startPositionX;
            PositionY = startPositionY;

            PossibleMovements = new int[,]
                {
                    { -1, -1},
                    { -1, 0 },
                    { -1, 1 },
                    { 0, -1 },
                    { 0, 1 },
                    { 1, -1},
                    { 1, 0},
                    { 1, 1}
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

