using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong3.Patterns.Adapter;

namespace PingPong3.Patterns.Proxy
{
    public class SoundProxy : ISound
    {
        //private List<CertainSound> certainSounds;
        //private List<Tuple<string, CertainSound>> certainSounds;
        private Dictionary<string, CertainSound> certainSounds = new Dictionary<string, CertainSound>();

        public void RequestSound(string s)
        {
            if(!certainSounds.ContainsKey(s))
            {
                certainSounds.Add(s, new CertainSound(s));
            }

            certainSounds[s].RequestSound();
        }
    }
}
