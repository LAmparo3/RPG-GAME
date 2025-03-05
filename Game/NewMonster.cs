
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Dungeon
{
    /// <summary>
    /// this monster moves like a knight in chess but also has to be hit multiple times
    /// </summary>
    class NewMonster: Monster
    {
      
        public NewMonster()
        {
            foreColor = ConsoleColor.DarkBlue;
            name = GenName();
            history = GenHistory();
            moves = DiceRoller.Roll(1, 7);
        }

        /// <summary>
        /// This movement is like a knight in chess. Try to catch him it'll be some what tricky but not hard. 
        /// </summary>
        /// <param name="board"></param>
        /// <param name="player"></param>
        public override void Move(GenBoard board, Player player)

        {
            int button = DiceRoller.Roll(1, 5);
            if (button == 1)
            {
                {
                    if ((row - 3) <= 0 && (col - 1) <= 0
                        || (row - 3) <= 0
                        || (col - 1) <= 0
                        || board.Gameboard[row - 3, col - 1].symbol == "#")
                    {
                        
                    }
                    else if (board.Gameboard[row - 3, col - 1].occupied != null)
                    {
                        Interact(board, board.Gameboard[row - 3, col - 1].occupied);

                    }
                    else
                    {
                        board.Gameboard[row, col].occupied = null;
                        board.Gameboard[row - 3, col - 1].occupied = this;
                        SetCursorPosition(col, row);
                        board.Gameboard[row, col].DrawTile();
                        SetCursorPosition(col -1 , row - 3);
                        board.Gameboard[row - 3, col - 1].DrawTile();
                        row-=3;
                        col--;
                    }

                }
            }
            else if (button == 2)
            {
                {
                    if ((row + 3) >= board.row && (col + 1) >= board.col
                        || (row + 3) >= board.row
                        || (col + 1) >= board.col
                        || board.Gameboard[row + 3, col + 1].symbol == "#")
                    {

                    }
                    else if (board.Gameboard[row + 3, col + 1].occupied != null)
                    {
                        Interact(board, board.Gameboard[row + 3, col + 1].occupied);

                    }
                    else
                    {
                        board.Gameboard[row, col].occupied = null;
                        board.Gameboard[row + 3, col + 1].occupied = this;
                        SetCursorPosition(col, row);
                        board.Gameboard[row, col].DrawTile();
                        SetCursorPosition(col + 1, row + 3);
                        board.Gameboard[row + 3, col + 1].DrawTile();
                        row+=3;
                        col++;
                    }

                }
            }
            else if (button == 3)
            {
                {
                    if ((col - 3) <= 0 && (row - 1) <= 0
                        || (col - 3) <= 0
                        || (row - 1) <= 0
                        || board.Gameboard[row -1, col - 3].symbol == "#")
                    {

                    }
                    else if (board.Gameboard[row - 1, col - 3].occupied != null)
                    {
                        Interact(board, board.Gameboard[row - 1, col - 3].occupied);


                    }
                    else
                    {
                        board.Gameboard[row, col].occupied = null;
                        board.Gameboard[row - 1, col - 3].occupied = this;
                        SetCursorPosition(col, row);
                        board.Gameboard[row, col].DrawTile();
                        SetCursorPosition(col - 3, row - 1);
                        board.Gameboard[row - 1, col - 3].DrawTile();
                        col-=3;
                        row--;
                    }

                }
            }
            else if (button == 4)
            {
                {
                    if ((col + 3) >= board.col && (row + 1) >= board.row
                        || (col + 3) >= board.col
                        || (row + 1) >= board.row
                        || board.Gameboard[row + 1, col + 3].symbol == "#")
                    {

                    }
                    else if (board.Gameboard[row + 1, col + 3].occupied != null)
                    {
                        Interact(board, board.Gameboard[row + 1, col + 3].occupied);

                    }
                    else
                    {
                        board.Gameboard[row, col].occupied = null;
                        board.Gameboard[row + 1, col + 3].occupied = this;
                        SetCursorPosition(col, row);
                        board.Gameboard[row, col].DrawTile();
                        SetCursorPosition(col + 3, row + 1);
                        board.Gameboard[row + 1, col + 3].DrawTile();
                        col+=3;
                        row++;
                    }
                }
            }
        }


        public override void Interact(GenBoard board, IActor a)
        {
        }
        public override void Death(GenBoard board)
        {
            board.Gameboard[row, col].occupied = null;
            SetCursorPosition(col, row);
            board.Gameboard[row, col].DrawTile();


        }


    }
}

