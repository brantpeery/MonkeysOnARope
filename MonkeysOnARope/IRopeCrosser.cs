using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MonkeysOnARope.World;

namespace MonkeysOnARope
{
    public interface IRopeCrosser
    {
        Side Destination { get; set; }
        string ID { get; }
        int CurrentPosition { get; }
        int Step();
    }
}
