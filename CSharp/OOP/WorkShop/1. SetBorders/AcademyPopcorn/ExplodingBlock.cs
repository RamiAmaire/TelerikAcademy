﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class ExplodingBlock : Block
    {
        public const char Symbol = 'X';
        public new const string CollisionGroupString = "explodingBlock";
        private bool isHit = false;
        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = ExplodingBlock.Symbol;
        }
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return true;
        }
        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (isHit)
            {
                List<GameObject> explodingMissiles = new List<GameObject>();
                explodingMissiles.Add(new ExplodingMissile(topLeft, new MatrixCoords(-1, 0)));
                explodingMissiles.Add(new ExplodingMissile(topLeft, new MatrixCoords(1, 0)));
                explodingMissiles.Add(new ExplodingMissile(topLeft, new MatrixCoords(0, 1)));
                explodingMissiles.Add(new ExplodingMissile(topLeft, new MatrixCoords(0, -1)));
                explodingMissiles.Add(new ExplodingMissile(topLeft, new MatrixCoords(1, -1)));
                explodingMissiles.Add(new ExplodingMissile(topLeft, new MatrixCoords(-1, 1)));
                explodingMissiles.Add(new ExplodingMissile(topLeft, new MatrixCoords(-1, -1)));
                explodingMissiles.Add(new ExplodingMissile(topLeft, new MatrixCoords(1, 1)));
                return explodingMissiles;
            }
            else
            {
                return new List<GameObject>();
            }
        }
        public override void Update()
        {
            base.Update();
        }
        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            this.isHit = true;
            ProduceObjects();
        }
    }
}
