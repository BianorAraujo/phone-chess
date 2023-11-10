
using ChessPhoneNumber;

Console.WriteLine($"The board:");
Generate generate = new Generate();
Console.WriteLine(generate.PrintBoard());

Console.WriteLine("Select a piece: ");
Console.WriteLine("1 - King ");
Console.WriteLine("2 - Knight");
Console.WriteLine("3 - Rook");
string selectedPiece = Console.ReadLine();

Console.WriteLine("Select the initial position (2-9): ");
string selectedPosition = Console.ReadLine();

Console.WriteLine(generate.GetPhoneNumber(selectedPiece, selectedPosition));

Console.ReadKey();