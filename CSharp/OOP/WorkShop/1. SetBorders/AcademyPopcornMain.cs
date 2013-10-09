using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;
        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;
            for (int i = startCol; i < endCol/2; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }
            for (int i = (endCol/2); i < endCol; i++) // making unpassable blocks
            {
                UnpassableBlock unpBlock = new UnpassableBlock(new MatrixCoords(startRow, i));
                engine.AddObject(unpBlock);
            }
            Ball theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2 + 1 , 0), new MatrixCoords(-1, 1));
            Ball unstBall = new UnstoppableBall(new MatrixCoords(10, WorldCols - 1), new MatrixCoords(-1, -1)); //creating unstoppable ball
            engine.AddObject(unstBall);
            engine.AddObject(theBall);
            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);
            engine.AddObject(theRacket);
        }
        static void SetBorders(Engine engine)
        {
            //left border
            for (int row = 0; row < WorldRows; row++)
            {
                IndestructibleBlock borderLeft = new IndestructibleBlock(new MatrixCoords(row, 0));
                engine.AddObject(borderLeft);
            }
            //right border
            for (int row = 0; row < WorldRows; row++)
            {
                IndestructibleBlock borderRight = new IndestructibleBlock(new MatrixCoords(row, WorldCols - 1));
                engine.AddObject(borderRight);
            }
            //top
            for (int col = 0; col < WorldCols; col++)
            {
                IndestructibleBlock borderTop = new IndestructibleBlock(new MatrixCoords(0, col));
                engine.AddObject(borderTop);
            }
        }
        static void Main()
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard,500); //setting sleep length manually with integer number

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);
            SetBorders(gameEngine); // my implementation for borders
            
            gameEngine.Run();
        }
    }
}
