using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace PingPong3.Patterns.Adapter
{
    public class SoundLibrary
    {
        private SoundPlayer soundPlayer;
        private string path;
        public SoundLibrary()
        {
            path = System.IO.Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf("bin\\Debug"));
            path = path + "Sounds\\";
        }

        public void PlaySound(String s)
        {
            switch(s)
            {
                case "Win":
                    soundPlayer = new SoundPlayer(path + "Win.wav");
                    break;
                case "Hit":
                    soundPlayer = new SoundPlayer(path + "Hit.wav");
                    break;
                case "Score":
                    soundPlayer = new SoundPlayer(path + "Score.wav");
                    break;
                case "Miss":
                    soundPlayer = new SoundPlayer(path + "Miss.wav");
                    break;
            }
            soundPlayer.Play();
        }
    }
}
