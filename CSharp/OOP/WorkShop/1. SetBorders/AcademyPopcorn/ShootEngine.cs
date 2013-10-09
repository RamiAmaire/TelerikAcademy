using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class ShootEngine : Engine
    {
        public ShootEngine(IRenderer renderer, IUserInterface ui, int refreshTime)
            : base(renderer, ui, refreshTime)
        {
        }
        public void ShootPlayerRacket()
        {
        }
    }
}
