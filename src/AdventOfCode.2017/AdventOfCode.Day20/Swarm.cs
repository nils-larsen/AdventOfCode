using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace AdventOfCode.Day20
{
    public class Particle
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int PosZ { get; set; }

        public int VelX { get; set; }
        public int VelY { get; set; }
        public int VelZ { get; set; }

        public int AccX { get; set; }
        public int AccY { get; set; }
        public int AccZ { get; set; }

        public void MoveParticle()
        {
            VelX += AccX;
            VelY += AccY;
            VelZ += AccZ;

            PosX += VelX;
            PosY += VelY;
            PosZ += VelZ;
        }

        public string GetPosition()
        {
            return ($"{PosX}, {PosY}, {PosZ}");
        }
    }

    public static class Swarm
    {
        public static List<Particle> CreateListOfParticles(this List<string> input)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            var listOfParticles = new List<Particle>();

            foreach (var row in input)
            {
                var line = row.FormatLine().Select(int.Parse).ToList();

                listOfParticles.Add(new Particle
                {
                    PosX = line[0],
                    PosY = line[1],
                    PosZ = line[2],

                    VelX = line[3],
                    VelY = line[4],
                    VelZ = line[5],

                    AccX = line[6],
                    AccY = line[7],
                    AccZ = line[8]
                });
            }
            return listOfParticles;
        }

        public static List<Particle> Tick(this List<Particle> listOfParticles, int repeat, bool remove = false)
        {
            for (var i = 0; i < repeat; i++)
            {
                listOfParticles.ForEach(x => x.MoveParticle());

                if (remove)
                    listOfParticles.RemoveWhenColliding();
            }
            return listOfParticles;
        }

        public static void RemoveWhenColliding(this List<Particle> listOfParticles)
        {
            var collisions = listOfParticles.GroupBy(p => p.GetPosition())
                                            .Where(p => p.Skip(1).Any())
                                            .ToList();

            foreach (var c in collisions)
            {
                foreach (var b in c)
                {
                    listOfParticles.Remove(b);
                }
            }
        }

        public static int GetClosestParticleToOrigo(this List<Particle> listOfParticles)
        {
            return listOfParticles
                .Select((p, i) => new { Value = p.GetDistanceOfSpecificParticle(), Index = i })
                .Aggregate((a, b) => a.Value < b.Value ? a : b)
                .Index;
        }

        static double GetDistanceOfSpecificParticle(this Particle particle)
        {
            return Math.Abs(particle.PosX) + Math.Abs(particle.PosY) + Math.Abs(particle.PosZ);
        }
    }

    public static class SwarmExtensions
    {
        public static List<string> FormatLine(this string line)
        {
            return line
                .Replace("p=<", "")
                .Replace("v=<", "")
                .Replace("a=<", "")
                .Replace(">", "")
                .Split(",").ToList();
        }
    }
}
