using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MonkeysOnARope.World;

namespace MonkeysOnARope
{
    public class Monkey : IRopeCrosser
    {
        public Monkey(string id, Side destination)
        {
            _destination = destination;
            _id = id;
        }
        Side _destination = Side.None;
        string _id = "";
        int _currPos = 0;

        public int CurrentPosition
        {
            get
            {
                return _currPos;
            }
        }

        public World.Side Destination
        {
            get
            {
                return _destination;
            }

            set
            {
                _destination = value;
            }
        }

        public string ID
        {
            get
            {
                return _id;
            }
        }

        public int Step()
        {
            _currPos++;
            return _currPos;
        }
    }
}
