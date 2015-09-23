using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CritterBrainBase;

namespace Critters
{
    public class Survivor : CritterBrainCore
    {
        Random rand = new Random();
        int move = 0;
        //the name and creator of the critter.
        public Survivor() : base("Survivor", "LFS (100215286)")
        {
            
        }

        public override void Birth()
        {
            //on birth move in this direction at this speed.
            Critter.Direction = 135;
            Critter.Move(10);
        }

        public override void NotifyBumpedCritter(OtherCritter other)
        {
            //when the critter bumps into a critter which is weak of veryweak, go in this 
            //direction (towards the critter), at this speed and attack.
            if (other.Strength == Strength.Weaker || other.Strength == Strength.MuchWeaker)
            {
                Critter.Direction = other.DirectionTo;
                Critter.Move(10);
                other.Attack();
            }
        }

        public override void NotifyBlockedByTerrain()
        {
            //when blocked by terrain go in a random direction at this speed.
            Critter.Direction = rand.Next(0, 360);
            Critter.Move(10);
        }

        public override void NotifyCloseToFood(int x, int y)
        {
            //go towards food when near at this speed.
            Critter.Direction = Critter.GetDirectionTo(x, y);
            Critter.Move(10);
        }

        public override void NotifyEaten()
        {
            //when eaten go in another random direction.
            Critter.Direction = rand.Next(0, 360);
            Critter.Move(10);
        }

        public override void Think()
        {
            //if the critter isn't moving, make it move.
            if (Critter.Speed == 0)
            {
                Critter.Move(10);
            }

            //this will make my critter move in a different direction around every 60000 milliseconds (1 min)
            if (move > 600)
            {
                Critter.Direction = rand.Next(0, 360);
                //reset goal
                move = 0;
            }
            else
            {
                //increment ever 100 millisecs
                move++;
            }
        }
    }
}
