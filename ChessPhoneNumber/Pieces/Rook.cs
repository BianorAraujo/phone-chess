
namespace ChessPhoneNumber.Pieces
{
    public class Rook : IPiece
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }


        public Rook(int startPositionX, int startPositionY)
        {
            PositionX = startPositionX;
            PositionY = startPositionY;
        }


        public void GetNextMovement(string[,] board, out int newRow, out int newCol)
        {
            int boardX = board.GetLength(0);
            int boardY = board.GetLength(1);

            do
            {
                int direction = Random.Shared.Next(1, 4); //1:up  2:down  3:left  4:right

                switch (direction)
                {
                    case 1:
                        var up = 0;

                        if (PositionX != 0)
                            up = Random.Shared.Next(1,(boardX - PositionX)+1);

                        newRow = PositionX - up;
                        newCol = PositionY;
                        break;
                    case 2:
                        var down = 0;

                        if(PositionX < boardX-1)
                            down = Random.Shared.Next(1, (boardX - PositionX));

                        newRow = PositionX + down;
                        newCol = PositionY;
                        break;
                    case 3:
                        var left = Random.Shared.Next(1,boardY - PositionY);
                        newRow = PositionX;
                        newCol = PositionY - left;
                        break;
                    case 4:
                        var right = Random.Shared.Next(1,boardY - PositionY);
                        newRow = PositionX;
                        newCol = PositionY + right;
                        break;
                    default:
                        newRow = 0;
                        newCol = 0;
                        break;
                }
            }
            while (newRow == PositionX && newCol == PositionY);
        }

        public void SetMovement(int row, int col)
        {
            PositionX = row;
            PositionY = col;
        }

    }
}

