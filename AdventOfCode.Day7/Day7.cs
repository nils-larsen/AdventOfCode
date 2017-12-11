using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day7
{
    public class Node
    {
        public string Name { get; private set; }
        public int Weight { get; private set; }
        public List<string> NameOfChildren { get; private set; }
        public List<Node> Children { get; set; }

        public Node(string[] components)
        {
            Name = components[0];
            Weight = int.Parse(components[1].Split('(', ')')[1]);
            NameOfChildren = components
                .Select(x => x.Trim(','))
                .Skip(3)
                .ToList();
        }
    }

    public class Tree
    {
        public List<Node> Nodes { get; private set; }

        public Tree(IEnumerable<string> input)
        {
            Nodes = input.Select(x => new Node(x.Split())).ToList();

            Nodes.ForEach(node =>
                          node.Children = Nodes
                          .Where(x => node.NameOfChildren.Any(y => y.Contains(x.Name)))
                          .ToList());
        }

        public Node GetRoot()
        {
            return Nodes.First(node => !Nodes.Any(x => x.NameOfChildren.Contains(node.Name)));
        }
    }
}