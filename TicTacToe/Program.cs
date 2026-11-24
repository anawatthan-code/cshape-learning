using System.Security.Cryptography.X509Certificates;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] board = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            int turn = 0;
            bool isPlayerTurn = true;

            while (!checkVictory() && turn != 9)
            {
                Console.WriteLine();
                PrintBoard();
                if (isPlayerTurn)
                {
                    Console.WriteLine("Player 1 turn!!");
                }
                else
                {
                    Console.WriteLine("Player 2 turn!!");
                }
                Console.Write("Choses ypur choice : ");
                string choice = Console.ReadLine();
                int.TryParse(choice, out int numChoice);
                if (board.Contains(choice) && choice != "X" && choice != "O" && numChoice < 10 && numChoice > 0)
                {
                    int boardIndex = Convert.ToInt32(choice) - 1;
                    if (isPlayerTurn)
                    {
                        board[boardIndex] = "X";
                    }
                    else
                    {
                        board[boardIndex] = "O";
                    }
                    isPlayerTurn = !isPlayerTurn;
                    turn++;
                }
                else
                {
                    Console.WriteLine("TRY AGAIN!!");
                }
                
            }

            if (checkVictory())
            {
                Console.WriteLine("You win!!!");
            }
            else
            {
                Console.WriteLine("Tie");

            }

            void PrintBoard()
            {
                for(int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(board[i * 3 + j] + "|");
                    }
                    Console.WriteLine();
                    Console.WriteLine("------");
                }

            }
            bool checkVictory()
            {
                bool row1 = board[0] == board[1] && board[1] == board[2];
                bool row2 = board[3] == board[4] && board[4] == board[5];
                bool row3 = board[6] == board[7] && board[7] == board[8];
                bool col1 = board[0] == board[3] && board[3] == board[6];
                bool col2 = board[1] == board[4] && board[4] == board[7];
                bool col3 = board[2] == board[5] && board[5] == board[8];
                bool digup = board[7] == board[4] && board[4] == board[2];
                bool digdown = board[0] == board[4] && board[4] == board[8];

                return row1||row2 || row3 || col1 || col2 || col3 || digdown || digup;
            }
        }
    }
}
