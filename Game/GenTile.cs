using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dungeon
{
    class GenTile
    {
        public string _ID { get; } = Guid.NewGuid().ToString("N");
        public ConsoleColor foreColor { get; set; }
        public ConsoleColor backColor { get; set; }
        public bool stairsHere { get; set; }
        public IActor occupied { get; set; }
        public string symbol { get; set; }

        public GenTile(string tileSymbol, ConsoleColor back, ConsoleColor fore, bool stairs = false, IActor playerHere = null )
        {
            foreColor = fore;
            backColor = back;
            stairsHere = stairs;
            occupied = playerHere;
            symbol = tileSymbol;


        }
      
        public void DrawTile()
        {
            if (occupied != null)
            {

                ForegroundColor = occupied.foreColor;
                Write("@");
            }
            else if (stairsHere)
            {
                ForegroundColor = ConsoleColor.Cyan;
                Write(">");
            }
            else
            {
                ForegroundColor = foreColor;
                BackgroundColor = backColor;
                Write(symbol);
            }
            ForegroundColor = ConsoleColor.White;
            BackgroundColor = ConsoleColor.Black;
        }

    }
}


