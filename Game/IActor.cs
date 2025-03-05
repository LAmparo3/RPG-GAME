using Dungeon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
	/// <summary>
	/// contract that both player and monster are built around
	/// </summary>
	interface IActor
	{
		int row { get; set; }
		int col { get; set; }
		string symbol { get; }
		string name { get; set; }
		int moves { get; set; }
		
		ConsoleColor foreColor { get; }
		
		ConsoleColor backColor { get; }
		
		void Move(GenBoard b, Player p);
		
		void Interact(GenBoard b, IActor a);
		
		void Death(GenBoard b);
	}
	
}
