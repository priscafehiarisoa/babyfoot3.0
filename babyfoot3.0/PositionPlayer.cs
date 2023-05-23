using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babyfoot3._0
{
    public class PositionPlayer
    {
        public int x { get; set; }
        public int y { get; set; }

        public PositionPlayer()
        {
            
        }
        public PositionPlayer(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
