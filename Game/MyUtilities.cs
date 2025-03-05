using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

class DiceRoller
{
    public static int Roll()
    {
        return StaticRandom.Instance.Next(1, 7);
    }
    public static int Roll(int times)
    {
        int total = 0;
        for (int i = 0; i < times; i++)
        {
            int diceroll = StaticRandom.Instance.Next(1, 7);
            total = diceroll + total;
        }
        return total;

    }
    public static int Roll(int times, int sides)
    {
        int total = 0;
        for (int i = 0; i < times; i++)
        {
            int diceroll = StaticRandom.Instance.Next(1, sides+1);
            total = diceroll + total;

        }
        return total;
    }
    public static int Roll(int times, int sides, int target)
    {
        int targetNum = 0;
        for (int i = 0; i < times; i++)
        {
            int diceroll = StaticRandom.Instance.Next(1, sides + 1);
            if (diceroll >= target)
            {
                targetNum = targetNum + 1;
            }
        
        }
        return targetNum;

    }

}




