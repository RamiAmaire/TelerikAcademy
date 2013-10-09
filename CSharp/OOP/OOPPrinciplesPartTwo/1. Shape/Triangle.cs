﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Triangle : Shape
{
    public Triangle(int width, int height)
        : base(width, height)
    {
    }
    public override double CalculateSurface()
    {
        double value  = (this.height * this.width)/2;
        return (double)value;
    }
}

