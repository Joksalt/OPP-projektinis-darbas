using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Adapter
{
    public class CertainSound : Sound
    {
        public CertainSound(string s)
        {
            soundID = s;
        }
        public override void RequestSound()
        {
            new SoundLibrary().PlaySound(soundID);
        }
    }
}
