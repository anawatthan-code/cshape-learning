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
            string playerTurn = "Player";

            int[] available = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Random rnd = new Random();

            


            //เลือกโหมดเล่น PvP or PvBot
            while (true)
            {
                Console.Write("Chose your gamemode 1 is Player VS Player | 2 is Player VS Bot : ");
                int.TryParse(Console.ReadLine(),out int gamemode);
                if (gamemode == 1 ) //Player VS Player
                {
                    Console.WriteLine("Player VS Player");
                    //เช็คว่ามีคนชนะแล้วยัง หรือ ครบ9เทรินยัง
                    while (!checkVictory() && turn != 9)
                    {
                        Console.WriteLine();
                        PrintBoard();
                        if (isPlayerTurn)
                        {
                            Console.WriteLine("Player 1 turn!!");
                            playerTurn = "Player 1";
                        }
                        else
                        {
                            Console.WriteLine("Player 2 turn!!");
                            playerTurn = "Player 2";
                        }
                        Console.Write("Choses your choice : ");
                        string choice = Console.ReadLine();
                        int.TryParse(choice, out int numChoice);
                        //เช็คว่ามีเลขที่ board ไหม แล้วไม่ใช่ X O แล้ว้ลขอยุ่ใน1-9
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
                            Console.WriteLine();
                            Console.WriteLine("TRY AGAIN!!");
                        }

                    }

                    //เมื่อมีคนชนะ หรือไม่มีตอนจบเงื่อนไข
                    if (checkVictory())
                    {
                        PrintBoard();
                        Console.WriteLine("Winner is : {0}", playerTurn);
                        Console.WriteLine();
                        while (true)
                        {
                            Console.Write("Want play again 1 is yes | 2 is no : ");
                            int.TryParse(Console.ReadLine(), out int playAgain);
                            if (playAgain == 1)
                            {
                                resetBoard();
                                break;
                            }
                            else if (playAgain == 2)
                            {
                                Console.WriteLine("Thank for playing");
                                return;
                            }
                            else
                            {
                                Console.WriteLine("TRY AGAIN!!");
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Tie");
                    }
                }
                else if (gamemode == 2) //Player VS Bot
                {
                    Console.WriteLine("Player VS Bot");
                    //เช็คว่ามีคนชนะแล้วยัง หรือ ครบ9เทรินยัง
                    while (!checkVictory() && turn != 9)
                    {
                        Console.WriteLine();
                        PrintBoard();
                        if (isPlayerTurn)
                        {
                            Console.WriteLine("Player 1 turn!!");
                            playerTurn = "Player 1";

                            while (true)
                            {
                                Console.Write("Choses your choice : ");
                                string choice = Console.ReadLine();
                                int.TryParse(choice, out int numChoice);
                                if (board.Contains(choice) && choice != "X" && choice != "O" && numChoice < 10 && numChoice > 0)
                                {
                                    int boardIndex = Convert.ToInt32(choice) - 1;
                                    board[boardIndex] = "X";
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("TRY AGAIN!!");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bot turn!!");
                            playerTurn = "BOT";

                            while (true)
                            {
                                int botRan = botRandom();
                                string botRanString = botRan.ToString();
                                int.TryParse(botRanString, out int numChoice);
                                if (board.Contains(botRanString) && botRanString != "X" && botRanString != "O" && numChoice < 10 && numChoice > 0)
                                {
                                    int boardIndex = Convert.ToInt32(botRanString) - 1;
                                    board[boardIndex] = "O";
                                    Console.WriteLine("randommmmmm");
                                    Console.WriteLine("Bot random is : {0}", botRanString);
                                    break;
                                }
                            }
                        }
                        isPlayerTurn = !isPlayerTurn;
                        turn++;
                        Console.WriteLine(turn);
                    }

                    //เมื่อมีคนชนะ หรือไม่มีตอนจบเงื่อนไข
                    if (checkVictory())
                    {
                        PrintBoard();
                        Console.WriteLine("Winner is : {0}", playerTurn);
                        Console.WriteLine();
                        while (true)
                        {
                            Console.Write("Want play again 1 is yes | 2 is no : ");
                            int.TryParse(Console.ReadLine(), out int playAgain);
                            if (playAgain == 1)
                            {
                                reserBotIndex();
                                resetBoard();
                                break;
                            }
                            else if (playAgain == 2)
                            {
                                Console.WriteLine("Thank for playing");
                                return;
                            }
                            else
                            {
                                Console.WriteLine("TRY AGAIN!!");
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Tie");

                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("TRY AGAIN!!");
                }
            }
            

            

            //resetกระดาษสำหรับเกมต่อไป
            void resetBoard()
            {
                turn = 0;
                for (int i = 0; i < board.Length; i++)
                {
                    int num = i + 1;
                    string boardIndexs = num.ToString();
                    board[i] = boardIndexs;
                }
                
            }

            //ทำตาราง3x3
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
                bool digup = board[6] == board[4] && board[4] == board[2];
                bool digdown = board[0] == board[4] && board[4] == board[8];

                return row1||row2 || row3 || col1 || col2 || col3 || digdown || digup;
            }

            //ระบบบอทสุ่มเลขลงช่อง
            int botRandom()     
            {
                int index = rnd.Next(available.Length);
                int pick = available[index];
                available = RemoveAt(available, index);
                return pick;// ส่งเลขที่สุ่มได้ออกไป
            }

            static int[] RemoveAt(int[] arr, int index)
            {
                int[] result = new int[arr.Length - 1];
                int j = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i != index)
                    {
                        result[j] = arr[i];
                        j++;
                    }
                }
                return result;
            }

            void reserBotIndex()
            {
                available = new int[9];

                
                for (int i = 0; i < available.Length; i++)
                {
                    int num = i + 1;
                    string boardIndexs = num.ToString();
                    board[i] = boardIndexs;
                    available[i] = num;
                }
            }


        }
    }
}
