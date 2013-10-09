using System;

class ShipDamage
{
   
    static void Main()
    {
        int Sx1 = int.Parse(Console.ReadLine());
        int Sy1 = int.Parse(Console.ReadLine());
        int Sx2 = int.Parse(Console.ReadLine());
        int Sy2 = int.Parse(Console.ReadLine());
        int hit = int.Parse(Console.ReadLine());
        int Cx1 = int.Parse(Console.ReadLine());
        int Cy1 = int.Parse(Console.ReadLine());
        int Cx2 = int.Parse(Console.ReadLine());
        int Cy2 = int.Parse(Console.ReadLine());
        int Cx3 = int.Parse(Console.ReadLine());
        int Cy3 = int.Parse(Console.ReadLine());
        int rectangleTop = 0, rectangleBottom = 0, rectangleRight = 0, rectangleLeft = 0;
        if (Sy1 > Sy2)
        {
            rectangleTop = Sy1;
            rectangleBottom = Sy2;
        }
        if (Sy2 > Sy1)
        {
            rectangleTop = Sy2;
            rectangleBottom = Sy1;
        }
        if (Sx1 > Sx2)
        {
            rectangleRight = Sx1;
            rectangleLeft = Sx2;
        }
        if (Sx2 > Sx1)
        {
            rectangleRight = Sx2;
            rectangleLeft = Sx1;
        }
        int shoot1, shoot2, shoot3;
        shoot1 = 2 * hit - Cy1;
        shoot2 = 2 * hit - Cy2;
        shoot3 = 2 * hit - Cy3;
        int damage = 0;
        if ((shoot1 == rectangleBottom && Cx1 == rectangleRight) || (shoot1 == rectangleTop && Cx1 == rectangleRight) || (shoot1 == rectangleTop && Cx1 == rectangleLeft) || (shoot1 == rectangleBottom && Cx1 == rectangleLeft))
        {
            damage += 25;
        }
        if ((shoot2 == rectangleBottom && Cx2 == rectangleRight) || (shoot2 == rectangleTop && Cx2 == rectangleRight) || (shoot2 == rectangleTop && Cx2 == rectangleLeft) || (shoot2 == rectangleBottom && Cx2 == rectangleLeft))
        {
            damage += 25;
        }
        if ((shoot3 == rectangleBottom && Cx3 == rectangleRight) || (shoot3 == rectangleTop && Cx3 == rectangleRight) || (shoot3 == rectangleTop && Cx3 == rectangleLeft) || (shoot3 == rectangleBottom && Cx3 == rectangleLeft))
        {
            damage += 25;
        }
        if ((shoot1 == rectangleBottom && Cx1 > rectangleLeft && Cx1 < rectangleRight) || (shoot1 == rectangleTop && Cx1 > rectangleLeft && Cx1 < rectangleRight) || (Cx1 == rectangleLeft && shoot1 > rectangleBottom && shoot1 < rectangleTop) || (Cx1 == rectangleRight && shoot1 > rectangleBottom && shoot1 < rectangleTop))
        {
            damage += 50;
        }
        if ((shoot2 == rectangleBottom && Cx2 > rectangleLeft && Cx2 < rectangleRight) || (shoot2 == rectangleTop && Cx2 > rectangleLeft && Cx2 < rectangleRight) || (Cx2 == rectangleLeft && shoot2 > rectangleBottom && shoot2 < rectangleTop) || (Cx2 == rectangleRight && shoot2 > rectangleBottom && shoot2 < rectangleTop))
        {
            damage += 50;
        }
        if ((shoot3 == rectangleBottom && Cx3 > rectangleLeft && Cx3 < rectangleRight) || (shoot3 == rectangleTop && Cx3 > rectangleLeft && Cx3 < rectangleRight) || (Cx3 == rectangleLeft && shoot3 > rectangleBottom && shoot3 < rectangleTop) || (Cx3 == rectangleRight && shoot3 > rectangleBottom && shoot3 < rectangleTop))
        {
            damage += 50;
        }
        if (shoot1 < rectangleTop && shoot1 > rectangleBottom && Cx1 > rectangleLeft && Cx1 < rectangleRight)
        {
            damage += 100;
        }
        if (shoot2 < rectangleTop && shoot2 > rectangleBottom && Cx2 > rectangleLeft && Cx2 < rectangleRight)
        {
            damage += 100;
        }
        if (shoot3 < rectangleTop && shoot3 > rectangleBottom && Cx3 > rectangleLeft && Cx3 < rectangleRight)
        {
            damage += 100;
        }
        Console.WriteLine(damage + "%");
}
}

