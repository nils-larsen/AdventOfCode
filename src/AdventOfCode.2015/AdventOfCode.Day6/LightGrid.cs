using System.Collections.Generic;

namespace AdventOfCode.Day6
{
    public class LightGrid
    {
        public List<Light> Lights;

        public LightGrid(int xDim, int yDim)
        {
            Lights = new List<Light>();
            for (var x = 0; x < xDim; x++)
            {
                for (var y = 0; y < yDim; y++)
                {
                    var light = new Light(x, y);
                    Lights.Add(light);
                }
            }
        }
    }
}
