using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    /// <summary>
    /// this angel class gives you 10 moves when you interact with it
    /// </summary>
    class Angel : GameCharacter, IActor 
    {
        public ConsoleColor foreColor { get; set; }
        public ConsoleColor backColor { get; set; }
        public string history;
        public string symbol { get; set; }
        public int row { get; set; }
        public int col { get; set; }


        public Angel()
        {
            symbol = "%";
            foreColor = ConsoleColor.White;
            level = DiceRoller.Roll(3, 7);
            name = GenName();
            history = GenHistory();
            moves = 25;
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

        public virtual void Move(GenBoard board, Player player) { }
        public virtual void Interact(GenBoard board, IActor a)
        {
            
            

        }
        public virtual void Death(GenBoard board)


            
        {
            board.Gameboard[row, col].occupied = null;
            SetCursorPosition(col, row);
            board.Gameboard[row, col].DrawTile();


        }


    }
}
