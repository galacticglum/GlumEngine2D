using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;

namespace GlumEngine2D
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (Toolkit.Init())
            {
                TestGame testGame = new TestGame(1200, 900, "2D Game Engine");
            }       
        }
    }
}
