using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Net;
namespace Dungeon 
{
    class GenBoard

    {
        public GenTile[,] Gameboard;
        public List<(int, int)> room = new List<(int, int)>();
        public List<(int, int)> playerroom = new List<(int, int)>();
        public List<(int, int)> midpoint = new List<(int, int)>();
        public List<Monster> monsterlist = new List<Monster>();
        public List<Angel> angellist = new List<Angel>();
        public int[] playerpoint;
        public int row = 30;
        public int col = 50;

        public GenBoard(int row, int col)
        {
            
            Gameboard = SetBoard(row, col);
            playerpoint = new int[2];
        }
        /// <summary>
        /// This sets up our Gameboard made up of tiles
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>our board array</returns>
        public GenTile[,] SetBoard(int row, int col)
        {
            

            GenTile[,] board = new GenTile[row, col];
            for (int i = 0; i < row; i++) 
            {
                
                for (int v = 0; v < col; v++) 
                {
                    GenTile c = new GenTile("#", ConsoleColor.Blue, ConsoleColor.Yellow, false, null);
                    board[i, v] = c; 
                }
            }
            return board;
        }
        /// <summary>
        /// Displays our board in the console
        /// </summary>
        public void DrawBoard() 
        {
            for (int i = 0; i < Gameboard.GetLength(0); i++) 
            {
                for (int v = 0; v < Gameboard.GetLength(1); v++) 
                {
                    Gameboard[i, v].DrawTile();
                }
                WriteLine();

            }
        }
        /// <summary>
        /// takes the hght and width of our board, picks a random coord and creates a random sized room made of ... 
        /// </summary>
        public void MakeRoom()
        {
            int height = 25;
            int width = 50;
            int Coordx = StaticRandom.Instance.Next(1, height - 4); // random (x,y) point
            int Coordy = StaticRandom.Instance.Next(1, width - 4);
            int length = StaticRandom.Instance.Next(2, 7);
            int CoordMidx = (Coordx + length / 2);
            int CoordMidy = (Coordy + length / 2);
            for (int i = Coordx; i <= Coordx + length; i++) // when i is = to Coordx; while i is <= coordx+length; add 1)
            {

                for (int v = Coordy; v <= Coordy + length; v++) // same thing but for the y + length
                {
                    if (i >= Gameboard.GetLength(0) - 1 || v >= Gameboard.GetLength(1) - 1)  // if our coords = to the edge of the board 
                    {                                                                        // we tell it not to make a room 
                        break;
                    }
                    GenTile roomtile = new GenTile(".", ConsoleColor.Blue, ConsoleColor.Yellow); // rooms = "."

                    Gameboard[i, v] = roomtile;


                }
            }
            midpoint.Add((CoordMidx, CoordMidy)); // adds to our midpoint list
        }
        /// <summary>
        /// loops through our Gameboard and adds any tile with a "." symbol to our room list. Then we pick our random coord to place our stairs
        /// </summary>
        public void GenStairs()
        {
            for (int i = 0; i <= Gameboard.GetLength(0) - 1; i++)
            {
                for (int v = 0; v <= Gameboard.GetLength(1) - 1; v++)
                {
                    GenTile tile2 = (GenTile)Gameboard[i, v];
                    if (Gameboard[i, v].symbol == ".")
                    {
                        room.Add((i, v));
                    }
                }
            }
            while (true) 
            {
                (int RndCoord1, int RndCoord2) = room[StaticRandom.Instance.Next(0, room.Count)];
                if (Gameboard[RndCoord1, RndCoord2].symbol == ".") 
                {
                    Gameboard[RndCoord1, RndCoord2].stairsHere = true;
                    break;
                }
                else 
                {
                    continue;
                }

            }
            
        }
        /// <summary>
        /// creates multiple rooms
        /// </summary>
        /// <param name="amtRoom"></param>
        public void CreateRooms(int amtRoom)
        {
            for (int i = 0; i <= amtRoom; i++)
            {
                MakeRoom();
            }
        }
        /// <summary>
        /// Connects our rooms together
        /// </summary>
        public void CreateCorridors()
        {

            for (int j = 0; j <= midpoint.Count; j++)
            {
                if (j == 20)
                {
                    break;
                }
                (int Midx1, int Midy1) = midpoint[j];
                (int CoordMid3, int CoordMid4) = midpoint[j + 1];
                if (Midx1 > CoordMid3)
                {
                    for (; Midx1 > CoordMid3; Midx1--)     // -- goes down the X axis of our board
                    {
                        GenTile tile = new GenTile(".", ConsoleColor.Blue, ConsoleColor.Yellow);

                        Gameboard[Midx1, Midy1] = tile;
                    }
                }
                if (Midx1 < CoordMid3)
                {
                    for (; Midx1 < CoordMid3; Midx1++)   // ++ goes down the X axis of our board
                    {
                        GenTile tile = new GenTile(".", ConsoleColor.Blue, ConsoleColor.Yellow);

                        Gameboard[Midx1, Midy1] = tile;

                    }
                }
                if (Midy1 > CoordMid4)
                {
                    for (; Midy1 > CoordMid4; Midy1--)
                    {
                        GenTile tile = new GenTile(".", ConsoleColor.Blue, ConsoleColor.Yellow);

                        Gameboard[Midx1, Midy1] = tile;


                    }
                }
                if (Midy1 < CoordMid4)
                {
                    for (; Midy1 < CoordMid4; Midy1++)
                    {
                        GenTile tile = new GenTile(".", ConsoleColor.Blue, ConsoleColor.Yellow);

                        Gameboard[Midx1, Midy1] = tile;
                    }
                }
            }
        }
        /// <summary>
        /// places our actors onto the board.
        /// </summary>
        /// <param name="a"></param>
        public void PlaceActor(IActor a)

        {
            (int RndCoord1, int RndCoord2) = room[StaticRandom.Instance.Next(0, room.Count)];
            Gameboard[RndCoord1, RndCoord2].occupied = a;
            if (Gameboard[RndCoord1, RndCoord2].stairsHere == true) { }
            else if (a.GetType() == typeof(Player))
            {

                playerpoint[0] = RndCoord1;
                playerpoint[1] = RndCoord2;

            }
            else
            {
                a.row = RndCoord1;
                a.col = RndCoord2;
            }
            
            Gameboard[RndCoord1, RndCoord2].occupied = a;
            

        }
        /// <summary>
        /// displays our HUD
        /// </summary>
        /// <param name=""></param>
        /// <summary>
        /// creates a set number of monsters
        /// </summary>
        /// <param name="monsterNum"></param>
        public void CreateMonsters(int monsterNum)
        {
            
            NewMonster newmonster = new NewMonster();
            monsterlist.Add(newmonster);
            PlaceActor(newmonster);


            for (int i = 0; i < monsterNum; i++)
            {
                
                Monster monster = new Monster();
                monsterlist.Add(monster);
                PlaceActor(monster);
            }

        }
        /// <summary>
        /// creates a set number of angels
        /// </summary>
        /// <param name="angelNum"></param>
        public void CreateAngels(int angelNum)
        {
            for (int i = 0; i < angelNum; i++)
            {
                Angel angel = new Angel();
                angellist.Add(angel);
                PlaceActor(angel);
            }

        }
        /// <summary>
        /// Moves our monsters randomly
        /// </summary>
        /// <param name="player"></param>
        public void MonsterMove(Player player)
        {
            foreach(Monster monster in monsterlist)
            {
                monster.Move(this, player);
            }
        }

        /// <summary>
        /// when the player kills every monster he is able to go to the next floor
        /// </summary>
        /// <param name="player"></param>
        public void NextLevel(Player player)
        {
            Clear();
            int row = 30;
            int col = 50;
            int amtRoom = 20;
            int monsterNum = 10;
            int angelNum = 5;
            player.StatBox();
            player.PrintStatusScreen();
            SetCursorPosition(0, 0);
            GenBoard board = new GenBoard(row, col);
            board.CreateRooms(amtRoom);
            board.CreateCorridors();
            board.GenStairs();
            board.PlaceActor(player);
            board.CreateMonsters(monsterNum);

            board.CreateAngels(angelNum);
            board.DrawBoard();
            BackgroundColor = ConsoleColor.Black;
            while (true)
            {
                player.Move(board, player);
                
                if (board.Gameboard[board.playerpoint[0], board.playerpoint[1]].stairsHere == true)
                {
                    
                    if (board.monsterlist.Count == 0)
                    {
                        player.moves = 100;
                        player.level += 1;
                        board.NextLevel(player);
                    }
                }




                for (int i = 0; i < board.monsterlist.Count; i++)
                {
                    if (board.monsterlist[i].moves <= 0)
                    {
                        board.monsterlist[i].Death(board);
                        board.monsterlist.RemoveAt(i);

                    }
                }
                for (int i = 0; i < board.angellist.Count; i++)
                {
                    if (board.angellist[i].moves <= 0)
                    {
                        board.angellist[i].Death(board);
                        board.angellist.RemoveAt(i);

                    }
                }
                board.MonsterMove(player);
            }
        }
        /// <summary>
        /// end game after moves are done
        /// </summary>
        public void EndGame() 
        {
            Environment.Exit(1);
        }
    } 
}
       
