using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CritterBrainBase;
using System.Drawing;

namespace Critters
{
    class Runner : CritterBrainCore
    {
        Random rand = new Random();
        int X, Y;
        int goal = 0;
        bool block = false;

        //the name and creator of the critter.
        public Runner() : base("Runner", "LFS (100215286)")
        {

        }

        public override void Birth()
        {
            //on birth move in this direction at this speed.
            Critter.Direction = 110;
            Critter.Move(10);
        }

        public override void NotifyBlockedByTerrain()
        {
            //when blocked by terrain the critter will move in one of 4 direction two of the being random
            int dir = rand.Next(10, 40);
            
            if (dir >= 10 && dir < 20)
            {
                Critter.Direction = rand.Next(0, 360);
            }
            else if (dir >= 20 && dir < 30)
            {
                Critter.Direction -= 50;
            }
            else if (dir >= 30 && dir < 40)
            {
                Critter.Direction += 50;
            }
            else 
            {
                Critter.Direction = rand.Next(0, 360);
            }
            //move critter
            Critter.Move(10);
        }

        public override void NotifyCloseToFood(int x, int y)
        {
            //go towards food when near at this speed.
            Critter.Direction = Critter.GetDirectionTo(x, y);
            Critter.Move(10);
        }

        public override void Think()
        {
            //if the critter isn't moving, make it move.
            if (Critter.Speed == 0)
            {
                Critter.Move(10);
            }
            //when goal is equal or more than 300 get the destination of the goal and move to it
            if (goal > 400)
            {
                X = Critter.GetDestination().X;
                Y = Critter.GetDestination().Y;
                block = Critter.IsTerrainBlockingRouteTo(X,Y);

				//if terrain isn't blocking the critter move to goal.
                if (!block)
                {
                    Critter.Direction = Critter.GetDirectionTo(X, Y);
                    //reset goal
                    goal = 0;
                }
                else
                {
                    Critter.Direction -= 45;
                    //reset goal
                    goal = 0;
                }
            }
            else
            {
                //increment ever 100 millisecs
                goal++;
            }
        }
    }
}
