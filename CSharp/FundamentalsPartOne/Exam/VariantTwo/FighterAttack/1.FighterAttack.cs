using System;

class FighterAttack
{
    static void Main()
    {
        int ax1 = int.Parse(Console.ReadLine());
        int ay1 = int.Parse(Console.ReadLine());
        int ax2 = int.Parse(Console.ReadLine());
        int ay2 = int.Parse(Console.ReadLine());
        int nx = int.Parse(Console.ReadLine());
        int my = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int shoot1x = nx + d;
        int shoot1y = my;
        int shoot2x = shoot1x + 1;
        int shoot2y = my;
        int shoot3x = shoot1x;
        int shoot3y = shoot1y + 1;
        int shoot4x = shoot1x;
        int shoot4y = shoot1y - 1;
        int recleft = 0;
        int rectright = 0;
        int recttop = 0;
        int rectbot = 0;
        int dmg = 0;
        if (ax1 > ax2)
        {
            rectright = ax1;
            recleft = ax2;
        }
        else
        {
            rectright = ax2;
            recleft = ax1;
        }
        if (ay1 > ay2)
        {
            recttop = ay1;
            rectbot = ay2;
        }
        else
        {
            recttop = ay2;
            rectbot = ay1;
        }
        if (shoot1x <= rectright && shoot1x >= recleft && shoot1y <= recttop && shoot1y >= rectbot)
        {
            dmg += 100;
        }
        if (shoot2x <= rectright && shoot2x >= recleft && shoot2y <= recttop && shoot2y >= rectbot)
        {
            dmg += 75;
        }
        if (shoot4x <= rectright && shoot4x >= recleft && shoot4y <= recttop && shoot4y >= rectbot)
        {
            dmg += 50;
        }
        if (shoot3x <= rectright && shoot3x >= recleft && shoot3y <= recttop && shoot3y >= rectbot)
        {
            dmg += 50;
        }
        Console.WriteLine("{0}%", dmg);
    }
}

