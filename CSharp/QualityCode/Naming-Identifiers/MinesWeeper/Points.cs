namespace Minesweeper
{
    using System;

    /// <summary>
    /// This class holds information about the score of the players.
    /// It has information about players name and points.
    /// </summary>
    public class Score
    {
        // Fields
        private string name = string.Empty;
        private int points = 0;

        // Constructors
        public Score()
        {
        }

        public Score(string name, int points)
        {
            // setting to properites for controlled validation
            this.Name = name;
            this.Points = points;
        }

        // Properties
        public string Name
        {
            get 
            { 
                return this.name; 
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(
                        "Name cannot be null.");
                }

                this.name = value;
            }
        }

        public int Points
        {
            get 
            { 
                return this.points;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Points cannot be less than 0.");
                }

                this.points = value;
            }
        }
    }
}
