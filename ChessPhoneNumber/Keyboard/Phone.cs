using System;
namespace ChessPhoneNumber.Keyboard
{
	public class Phone : IKeyboard
	{
		public string[,] keyboard { get; set; } 

        public string[] invalidStartNumbers { get; set; }

        public string[] invalidPositions { get; set; }
        
        public Phone()
        {
            keyboard = new string[,] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" }, { "*", "0", "#" } };
            invalidStartNumbers = new string[] { "0", "1", "*", "#"};
            invalidPositions = new string[] { "*", "#" };
        }

        public string[,] GetKeyboard()
        {
            return keyboard;
        }

        public bool IsValidStartNumber(string startNumber)
        {
            bool isValid = false;

            for (int i = 0; i < keyboard.GetLength(0); i++)
            {
                for (int j = 0; j < keyboard.GetLength(1); j++)
                {
                    if (keyboard[i, j].Equals(startNumber))
                    {
                        isValid = true;
                        continue;
                    }
                }
            }

            foreach (string item in invalidStartNumbers)
            {
                if (item.Equals(startNumber))
                {
                    isValid = false;
                    continue;
                }
            }

            return isValid;
        }

        public bool IsValidPosition(int row, int col)
        {
            bool isVal = row >= 0 &&
                    row < keyboard.GetLength(0) &&
                    col >= 0 &&
                    col < keyboard.GetLength(1);

            bool hasPosition = false;

            if (isVal)
            {
                foreach (var item in invalidPositions)
                {
                    if (keyboard[row, col].Equals(item))
                    {
                        hasPosition = true;
                        continue;
                    }
                }
            }

            return isVal && !hasPosition;
            
        }
    }
}

