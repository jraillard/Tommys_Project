using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    [Flags]
    public enum GameMode
    {
        Training = 0x1,
        Arcade = 0x2
    }
}
