using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System.Globalization;


namespace Dungeon 
{
    class Program
    {
        static void Main(string[] args)
        {
            SetWindowSize(100, 40);
            SetBufferSize(100, 100);
            SetCursorPosition(40,5);
            WriteLine(".  ..  ..  ..__ ");
            SetCursorPosition(40, 6);
            WriteLine("|  ||\\/||  ||  \\");
            SetCursorPosition(40, 7);
            WriteLine("|__||  ||__||__/");
            SetCursorPosition(41, 8);
            WriteLine("U MOVE U DIE!");
            SetCursorPosition(35, 9);
            WriteLine("Created By: Aurelio Amparo III");
            ReadKey();
            
            Player player = new Player();
            player.CreatePlayer(player);
            Clear();
            int row = 30;
            int col = 50;
            int amtRoom = 20;
            int monsterNum = 5;
            int angelNum = 5;
            player.StatBox();
            player.PrintStatusScreen();
            SetCursorPosition(0, 0);
            GenBoard board = new GenBoard(row, col);
            board.CreateRooms(amtRoom);
            board.CreateCorridors();
            board.GenStairs();
            board.CreateMonsters(monsterNum);
            board.CreateAngels(angelNum);
            board.PlaceActor(player);
            board.DrawBoard();
            BackgroundColor = ConsoleColor.Black;

            while (true)
            { 
                player.Move(board, player);
                if (board.Gameboard[board.playerpoint[0], board.playerpoint[1]].stairsHere == true)
                {
                   if(board.monsterlist.Count == 0) 
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
    }
}

