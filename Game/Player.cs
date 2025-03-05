
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;

namespace Dungeon
{
    class Player: GameCharacter, IActor

    {
        public ConsoleColor foreColor { get; set; }
        public ConsoleColor backColor { get; set; }

        public string history;
        public string symbol { get; set; }
        public int row { get; set; }
        public int col { get; set; }



        public Player()
        {
            symbol = "@";
            foreColor = ConsoleColor.Green;
            name = GenName();
            history = GenHistory();
            moves = 100;
  
        }

        public static string GenName()

        {

            string firstSyllable = "Andrew Jack Leo Lele Jorge Dwight Jim John Hyde Lemon";
            Array firstSyllablelist = firstSyllable.Split(' ');
            string firstName = (string)firstSyllablelist.GetValue(StaticRandom.Instance.Next(0, firstSyllablelist.Length - 1));  /* get value = substring[]  GetValue returns an Object so (string) converts it into a string */

            string secondSyllable = "Titanborn Frost Amparo Malone Shrute Halpert Micheal Casto Lime";
            Array secondSyllablelist = secondSyllable.Split(' ');
            string lastName = (string)secondSyllablelist.GetValue(StaticRandom.Instance.Next(0, secondSyllablelist.Length - 1));

            string final = firstName + " " + lastName;

            return final;

        }

        public static string GenHistory()
        {
            string backGround = "Both of my parents died in an accident when i was 12 years old.,I was left in front of an orphanage by my dying mother after a fatal drug deal.,I saw my own mom take her life and I was mentally abused by my strict drunk father.,After losing my whole family i have devoted my life to find out who killed them...,After suffering a life changing accident i dont feel any pain.";
            Array backGroundlist = backGround.Split(',');
            string history = (string)backGroundlist.GetValue(StaticRandom.Instance.Next(0, backGroundlist.Length - 1));


            string Job = "Janitor,Drug Dealer,Undercover Cop,Assassin,Unknown";
            Array Joblist = Job.Split(',');
            string occupation = (string)Joblist.GetValue(StaticRandom.Instance.Next(0, Joblist.Length - 1));

            string final = history + "\nJob:" + occupation;

            return final;



        }
        public void CreatePlayer(Player player1)
        {

            while (true)
            {
                player1 = new Player();
                Clear();
                WriteLine("Name: " + player1.name);
                WriteLine("History: " + player1.history);
                WriteLine("Do you like this character? (Y) for Yes Or any key to create new player!");
                ConsoleKeyInfo key = ReadKey(true);
                if (key.KeyChar == 'y')
                {
                    break;

                }
                else if (key.KeyChar == ' ')
                {
                    continue;

                }
            }


        }
        /// <summary>
        /// command our player to move anywhere in our Dungeon. Having issues with movement
        /// </summary>
        /// <param name="board"></param>
        /// <param name="player"></param>
        public void Move(GenBoard board, Player player)

        {
            ConsoleKey button = Console.ReadKey(true).Key;

            if (button == ConsoleKey.W)
            {
                {
                    if (moves <= 0)
                    {
                        Death(board);
                    }
                    else if (board.playerpoint[0] - 1 < 0 || board.Gameboard[board.playerpoint[0] - 1, board.playerpoint[1]].symbol == "#")
                    {
                        moves -= 1;
                    }
                    else if (board.Gameboard[board.playerpoint[0] - 1, board.playerpoint[1]].occupied != null) 

                    {
                        Interact(board, board.Gameboard[board.playerpoint[0] - 1, board.playerpoint[1]].occupied);

                    }
                 


                    else
                    {
                       
                        board.Gameboard[board.playerpoint[0], board.playerpoint[1]].occupied = null;
                        board.Gameboard[board.playerpoint[0] - 1, board.playerpoint[1]].occupied = this;
                        SetCursorPosition(board.playerpoint[1], board.playerpoint[0]);
                        board.Gameboard[board.playerpoint[0], board.playerpoint[1]].DrawTile();
                        SetCursorPosition(board.playerpoint[1], board.playerpoint[0]-1);
                        board.Gameboard[board.playerpoint[0]-1, board.playerpoint[1]].DrawTile();
                        moves -= 1;
                        PrintStatusScreen();
                        board.playerpoint[0]--;

                    }

                }
            }
            else if (button == ConsoleKey.S)
            {
                {
                    if (moves <= 0)
                    {
                        Death(board);
                    }
                    else if (board.playerpoint[0] + 1  > board.row || board.Gameboard[board.playerpoint[0] + 1, board.playerpoint[1]].symbol == "#" )
                    {
                        moves --;
                    }
                    else if (board.Gameboard[board.playerpoint[0] + 1, board.playerpoint[1]].occupied != null)
                    {
                        Interact(board, board.Gameboard[board.playerpoint[0] + 1, board.playerpoint[1]].occupied);

                    }
                  

                    else
                    {
                       
                        board.Gameboard[board.playerpoint[0], board.playerpoint[1]].occupied = null;
                        board.Gameboard[board.playerpoint[0] + 1, board.playerpoint[1]].occupied = this;
                        SetCursorPosition(board.playerpoint[1], board.playerpoint[0]);
                        board.Gameboard[board.playerpoint[0], board.playerpoint[1]].DrawTile();
                        SetCursorPosition(board.playerpoint[1], board.playerpoint[0]+1);
                        board.Gameboard[board.playerpoint[0]+1, board.playerpoint[1]].DrawTile();
                        moves -= 1;
                        PrintStatusScreen();
                        board.playerpoint[0]++;
                    }

                }
            }
            else if (button == ConsoleKey.A)
            {
                {
                    if(moves <= 0)
                    {
                        Death(board);
                    }
                    else if (board.playerpoint[1] - 1 < 0 || board.Gameboard[board.playerpoint[0], board.playerpoint[1] - 1].symbol == "#" )
                    {
                        moves --;
                    }
                    else if (board.Gameboard[board.playerpoint[0], board.playerpoint[1] - 1].occupied != null)
                    {
                        Interact(board, board.Gameboard[board.playerpoint[0], board.playerpoint[1] - 1].occupied);

                    }
                   
                    else
                    {
                        
                        board.Gameboard[board.playerpoint[0], board.playerpoint[1]].occupied = null;
                        board.Gameboard[board.playerpoint[0], board.playerpoint[1] - 1].occupied = this;
                        SetCursorPosition(board.playerpoint[1], board.playerpoint[0]);
                        board.Gameboard[board.playerpoint[0], board.playerpoint[1]].DrawTile();
                        SetCursorPosition(board.playerpoint[1] - 1, board.playerpoint[0]);
                        board.Gameboard[board.playerpoint[0], board.playerpoint[1] - 1].DrawTile();

                        moves -= 1;
                        PrintStatusScreen();
                        board.playerpoint[1]--;
                    }

                }
            }
            else if (button == ConsoleKey.D)
            {
                {
                    if (moves <= 0)
                    {
                        Death(board);
                    }
                    else if (board.playerpoint[1] + 1 > board.col || board.Gameboard[board.playerpoint[0], board.playerpoint[1] + 1].symbol == "#" )
                    {
                        moves--;
                    }
                    else if (board.Gameboard[board.playerpoint[0], board.playerpoint[1] + 1].occupied != null)
                    {
                        Interact(board, board.Gameboard[board.playerpoint[0], board.playerpoint[1] + 1].occupied);

                    }
                  

                    else
                    {
                        
                        board.Gameboard[board.playerpoint[0], board.playerpoint[1]].occupied = null;
                        board.Gameboard[board.playerpoint[0], board.playerpoint[1] + 1].occupied = this;
                        SetCursorPosition(board.playerpoint[1], board.playerpoint[0]);
                        board.Gameboard[board.playerpoint[0], board.playerpoint[1]].DrawTile();
                        SetCursorPosition(board.playerpoint[1] + 1, board.playerpoint[0]);
                        board.Gameboard[board.playerpoint[0], board.playerpoint[1] + 1].DrawTile();
                        moves -= 1;
                        PrintStatusScreen();
                        board.playerpoint[1]++;
                    }
                }
            }
        }
        /// <summary>
        /// interact function deals with angel, monster and specialmonster interactions
        /// </summary>
        /// <param name="board"></param>
        /// <param name="a"></param>
        public void Interact(GenBoard board, IActor a) 
        {
            
            if(a is Monster)
            {
                SetCursorPosition(0, 31);     
                Write("                                                                                                ");
                SetCursorPosition(0, 31);
                Write("You killed " + a.name +"!");
                a.moves -= 1; 


            }

            if (a is NewMonster)
            {
                SetCursorPosition(0, 31);
                Write("                                                                                                ");
                SetCursorPosition(0, 31);
                Write("You hit " + a.name + "!" + "He's still standing!!! ");
                a.moves -= 1;


            }
            else if(a is Angel)
            {
                SetCursorPosition(0, 31);
                Write("                                                                                                  ");
                SetCursorPosition(0, 31);
                Write("You were blessed by " + a.name + "!");
                if (moves < 100)
                {
                    moves += 25;
                    a.moves -= 25;

                }
                else if (moves == 100)
                {
                    SetCursorPosition(0, 31);
                    Write("                                                                                               ");
                    SetCursorPosition(0, 31);
                    Write(" YOU HAVE MAX HEALTH!");
                    
                }
                PrintStatusScreen();
            }

            
            
        }
        public void Death(GenBoard board) 
        {
            if(moves <= 0)
            {
                Clear();
                Write("You ran out of moves! Time to start over noob!");
                ReadKey();
                board.EndGame();


            }
        }
        /// <summary>
        /// creates the gray box for the stats
        /// </summary>
    public void StatBox()
    {
        for (int i = 0; i < 30; i++)
        {
            for (int j = 50; j < 100; j++)
            {
                Console.SetCursorPosition(j, i);
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
        for (int i = 50; i < 49; i++)
        {
            for (int j = 0; j < 49; j++)
            {
                Console.SetCursorPosition(j, i);
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
        /// <summary>
        /// Prints the stats of the player to the status screen.
        /// </summary>
    public void PrintStatusScreen()
    {
            BackgroundColor = ConsoleColor.DarkGray;
            ForegroundColor = ConsoleColor.Black;
            SetCursorPosition(65, 5);
            Write("Name: " + name);
            SetCursorPosition(65, 8);
            Write("                       ");
            SetCursorPosition(65, 8);
            Write("Moves:" + moves + "/100");
            SetCursorPosition(65, 12);
            Write("Level: " + level);
            SetCursorPosition(60, 15);
            Write("Obj: Kill all the red enemies");
            SetCursorPosition(60, 16);
            Write("to advance to the next level.");
            SetCursorPosition(65, 17);
            Write("HOW FAR CAN YOU GET!" );
            SetCursorPosition(60, 19);
            Write("Tip: Gain 10 moves from the angels!");

            BackgroundColor = ConsoleColor.Black;
            SetCursorPosition(0, 31);
        }


    }

}

