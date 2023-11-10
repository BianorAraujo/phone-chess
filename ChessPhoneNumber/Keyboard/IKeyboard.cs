using System;

namespace ChessPhoneNumber.Keyboard
{
	public interface IKeyboard
	{
        string[,] keyboard { get; set; }

        string[] invalidStartNumbers { get; set; }

        string[] invalidPositions { get; set; }
        


        string[,] GetKeyboard();

        bool IsValidStartNumber(string startNumber);

		bool IsValidPosition(int row, int col);

    }
}

