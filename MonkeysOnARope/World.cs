using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeysOnARope
{
    public class World
    {
        /// <summary>
        /// Represents a side of a rope or chasm 
        /// </summary>
        public enum Side
        {
            None,
            Left,
            Right
        }

        public event EventHandler<string> RaiseMessageEvent;

        protected virtual void OnRaiseMessageEvent(string message)
        {
            RaiseMessageEvent?.Invoke(this, message);
        }

        /// <summary>
        /// Travelers standing on the Left side wanting to go to the Right Side
        /// </summary>
        public List<IRopeCrosser> LeftQue = new List<IRopeCrosser>();
        /// <summary>
        /// Travelers standing on the Right side wanting to go to the Left Side
        /// </summary>
        public List<IRopeCrosser> RightQue = new List<IRopeCrosser>();
        /// <summary>
        /// Indicates everyone has arrived at thier destination
        /// </summary>
        public bool Done = false;

        /// <summary>
        /// The number of times the Step() function has been called
        /// </summary>
        public int NumStepsTaken
        {
            get
            {
                return _numStepsTaken;
            }
        }

        //Private Members
        Rope rope = new Rope(3);
        Side currentDestination = Side.Right;
        int _numStepsTaken = 0;

        /// <summary>
        /// Moves the world one step.
        /// </summary>
        public void Step()
        {
            
            //Increment number of steps taken
            _numStepsTaken++;

            //Move all the travelers 1
            //If any travelers are more than max steps, remove them
            foreach (IRopeCrosser traveler in rope.Travelers.ToArray())
            {
                traveler.Step();

                if (traveler.CurrentPosition > rope.MaxCapacity)
                {
                    OnRaiseMessageEvent(string.Format("{0} has left the rope on {1} side", traveler.ID, traveler.Destination));
                    rope.Travelers.Remove(traveler);
                }
            }


            //If there is room on the rope and the que direction is the same as the current direction of the rope, then add a traveler
            if (rope.Travelers.Count < rope.MaxCapacity && (rope.CurrentDirection == currentDestination || rope.CurrentDirection == Side.None))
            {

                if (currentDestination == Side.Right && LeftQue.Count > 0)
                {
                    //Destination is to the right side, so add monkeys from the left
                    OnRaiseMessageEvent(string.Format("{0} has entered the rope", LeftQue[0].ID));
                    LeftQue[0].Step();
                    rope.Travelers.Add(LeftQue[0]);
                    LeftQue.RemoveAt(0);
                }
                else if (RightQue.Count > 0)
                {
                    //Destination is to the left side, so add monkeys from the right
                    OnRaiseMessageEvent(string.Format("{0} has entered the rope", RightQue[0].ID));
                    RightQue[0].Step();
                    rope.Travelers.Add(RightQue[0]);
                    RightQue.RemoveAt(0);
                }
            }

            //If the rope is maxed, set the direction to switch
            if (rope.Travelers.Count == rope.MaxCapacity)
            {
                Side lastd = currentDestination;
                currentDestination = rope.CurrentDirection == Side.Right ? Side.Left : Side.Right;
            }

            //Ensure there are travelers who want to cross.
            if (currentDestination == Side.Left && RightQue.Count == 0) currentDestination = Side.Right;
            if (currentDestination == Side.Right && LeftQue.Count == 0) currentDestination = Side.Left;

            //Has everyone crossed?
            if (LeftQue.Count == 0 && RightQue.Count == 0 && rope.Travelers.Count == 0) Done = true;
        }
    }
}
