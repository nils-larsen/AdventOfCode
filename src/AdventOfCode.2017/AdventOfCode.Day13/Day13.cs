using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day13
{
    public class PackerScanner
    {
        readonly List<Layer> Firewall = new List<Layer>();

        public PackerScanner(IEnumerable<string> input)
        {
            Firewall = input.Select(x => new Layer(x)).ToList();
        }

        public int HitchHike()
        {
            var sum = 0;

            foreach (var layer in Firewall)
            {
                if (layer.IsCaught())
                {
                    sum += layer.Depth * layer.Range;
                }
            }
            return sum;
        }

        public int FindDelay()
        {
            var delay = 0;
            var caught = false;

            while (!caught)
            {
                foreach (var layer in Firewall)
                {
                    if (layer.IsCaught(delay))
                    {
                        caught = false;
                        delay++;
                        break;
                    }
                    caught = true;
                }
            }
            return delay;
        }
    }

    public class Layer
    {
        public int Depth { get; set; }
        public int Range { get; set; }

        public Layer(string setup)
        {
            Depth = int.Parse(setup.Split(':')[0]);
            Range = int.Parse(setup.Split(':')[1]);
        }

        public bool IsCaught(int delay = 0)
        {
            return (Depth + delay) % (2 * Range - 2) == 0;
        }
    }
}
