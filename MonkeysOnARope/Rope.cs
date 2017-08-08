using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MonkeysOnARope.World;

namespace MonkeysOnARope
{
    public class Rope
    {
        int _maxCap = 3;

        public Rope() { }
        /// <summary>
        /// Initializes a Rope with the ability to hold maxCapacity travelers
        /// </summary>
        /// <param name="maxCapacity"></param>
        public Rope(int maxCapacity)
        {
            _maxCap = maxCapacity;
        }

        /// <summary>
        /// The max travelers that can be on the rope. Also represents how many steps it takes to cross the rope.
        /// </summary>
        public int MaxCapacity
        {
            get
            {
                return _maxCap;
            }
        }


        /// <summary>
        /// What is the destination of travelers that are on the rope
        /// </summary>
        public Side CurrentDirection
        {
            get
            {
                if (Travelers.Count > 0)
                {
                    return Travelers.First().Destination;
                }
                return Side.None;
            }
        }

        /// <summary>
        /// List of Travelers that are on the rope
        /// </summary>
        public List<IRopeCrosser> Travelers = new List<IRopeCrosser>(3);

    }
}
