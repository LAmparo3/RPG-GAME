using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
	abstract class GameCharacter
	{
		public string _ID { get; } = Guid.NewGuid().ToString("N");
		public int moves{ get; set; }
		public int attack { get; set; }
		public int defense { get; set; }
		public string name { get; set; }
		public int level { get; set; }
		


		public override string ToString()
		{
			string returnString = "";
			returnString += "Name: " + name + Environment.NewLine;
			returnString += "Health: " + moves + Environment.NewLine;
			returnString += "Level: " + level + Environment.NewLine;

			return returnString;
		}

	}
}
