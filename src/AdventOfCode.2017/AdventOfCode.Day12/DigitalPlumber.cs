using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day12
{
    public class DigitalPlumber
    {
        public List<Program> Programs { get; set; }
        public DigitalPlumber(IEnumerable<string> input)
        {
            Programs = input.Select(x => new Program(x.Split())).ToList();

            Programs.ForEach(program =>
            program.Connections = Programs
            .Where(x => program.ConnectionString.Any(y => y.Equals(x.ProgramId)))
            .ToList());
        }

        public int NumberOfProgramsThatContainsProgramId0()
        {
            return Programs.First(x => x.ProgramId == 0).GetGroup().Count;
        }

        public int GroupsInTotal()
        {
            var groupCount = 0;

            while (Programs.Any())
            {
                var group = Programs.First().GetGroup();
                Programs.RemoveAll(x => group.Contains(x));
                groupCount++;
            }

            return groupCount;
        }
    }

    public class Program
    {
        public int ProgramId { get; set; }
        public List<Program> Connections { get; set; }
        public List<int> ConnectionString { get; set; }

        public Program(string[] components)
        {
            ProgramId = int.Parse(components[0]);

            ConnectionString = components
                .Select(x => int.Parse(x.Replace(" ", "").Trim(',')))
                .Skip(2)
                .ToList();
        }

        void GetGroup(List<Program> groupPrograms)
        {
            groupPrograms.Add(this);

            foreach (var c in Connections)
            {
                if (!groupPrograms.Contains(c))
                    c.GetGroup(groupPrograms);
            }
        }

        public List<Program> GetGroup()
        {
            var groupPrograms = new List<Program>();
            GetGroup(groupPrograms);
            return groupPrograms;
        }
    }
}
