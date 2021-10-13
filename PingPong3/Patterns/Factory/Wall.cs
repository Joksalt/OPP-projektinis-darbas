using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PingPong3.Patterns.Factory
{
    public abstract class Wall
    {
        private string name;
        private int width;
        private int height;
        private Color color;
        private bool moving;

        public string GetName()
        {
            return name;
        }
        public void SetName(string NewName)
        {
            this.name = NewName;
        }
        public int GetWidth()
        {
            return width;
        }
        public void SetWidth(int NewWidth)
        {
            this.width = NewWidth;
        }
        public int GetHeight()
        {
            return height;
        }
        public void SetHeight(int NewHeight)
        {
            this.height = NewHeight;
        }
        public Color GetColor()
        {
            return color;
        }
        public void SetColor(Color NewColor)
        {
            this.color = NewColor;
        }
        public bool GetMoving()
        {
            return moving;
        }
        public void SetMoving(bool Moving)
        {
            this.moving = Moving;
        }
    }
}
