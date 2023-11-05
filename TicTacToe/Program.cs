using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в игру 'Крестики-Нолики'!");

            
            Random random = new Random();
            int currentPlayer = random.Next(1, 3);

            Player player1 = new Player("Игрок", 'X');
            Player player2 = new Player("Компьютер", 'O');

            Game game = new Game(player1, player2, currentPlayer);

            game.Play();
        }
    }

    class Player
    {
        public string Name { get; }
        public char Symbol { get; }

        public Player(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }
    }

    class Game
    {
        private char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private Player currentPlayer;
        private Player player1;
        private Player player2;
        private int flag = 0;

        public Game(Player player1, Player player2, int startingPlayer)
        {
            this.player1 = player1;
            this.player2 = player2;
            currentPlayer = (startingPlayer == 1) ? player1 : player2;
        }

        public void Play()
        {
            do
            {
                
                Console.WriteLine($"{player1.Name}: {player1.Symbol}   {player2.Name}: {player2.Symbol}");
                Console.WriteLine("\n");
                Console.WriteLine($"Ходит {currentPlayer.Name}");
                Console.WriteLine("\n");
                Board();

                if (currentPlayer == player1)
                {
                    int choice;
                    Console.WriteLine("Введите номер клетки: ");
                    bool validInput = int.TryParse(Console.ReadLine(), out choice);

                    if (validInput && choice >= 1 && choice <= 9 && board[choice - 1] != 'X' && board[choice - 1] != 'O')
                    {
                        board[choice - 1] = player1.Symbol;
                        currentPlayer = player2;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    ComputerMove();
                }

                flag = CheckWin();
            }
            while (flag != 1 && flag != -1);

            Console.Clear();
            Board();
            if (flag == 1)
            {
                Console.WriteLine($"{(currentPlayer == player1 ? player2.Name : player1.Name)} победил!");
            }
            else
            {
                Console.WriteLine("Ничья");
            }
            Console.ReadLine();
        }


        private void ComputerMove()
        {
            Random random = new Random();
            int choice;

            do
            {
                choice = random.Next(1, 10);
            } while (board[choice - 1] == 'X' || board[choice - 1] == 'O');

            board[choice - 1] = player2.Symbol;
            currentPlayer = player1;
        }

        private void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[0], board[1], board[2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[3], board[4], board[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[6], board[7], board[8]);
            Console.WriteLine("     |     |      ");
        }

        private int CheckWin()
        {
            
            for (int i = 0; i < 3; i++)
            {
                if (board[i] == board[i + 3] && board[i + 3] == board[i + 6])
                {
                    if (board[i] == player1.Symbol)
                    {
                        Console.WriteLine($"{player1.Name} победил!");
                    }
                    else if (board[i] == player2.Symbol)
                    {
                        Console.WriteLine($"{player2.Name} победил!");
                    }
                    return 1;
                }

                if (board[i * 3] == board[i * 3 + 1] && board[i * 3 + 1] == board[i * 3 + 2])
                {
                    if (board[i * 3] == player1.Symbol)
                    {
                        Console.WriteLine($"{player1.Name} победил!");
                    }
                    else if (board[i * 3] == player2.Symbol)
                    {
                        Console.WriteLine($"{player2.Name} победил!");
                    }
                    return 1;
                }
            }

        
            if ((board[0] == board[4] && board[4] == board[8]) || (board[2] == board[4] && board[4] == board[6]))
            {
                if (board[4] == player1.Symbol)
                {
                    Console.WriteLine($"{player1.Name} победил!");
                }
                else if (board[4] == player2.Symbol)
                {
                    Console.WriteLine($"{player2.Name} победил!");
                }
                return 1;
            }

          
            bool isBoardFull = true;
            foreach (char c in board)
            {
                if (c != 'X' && c != 'O')
                {
                    isBoardFull = false;
                    break;
                }
            }

            if (isBoardFull)
            {
                Console.WriteLine("Ничья");
                return -1;
            }

           
            return 0;
        }
    }
}
