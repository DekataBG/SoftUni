namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTreeFactory
    {
        private Dictionary<int, IntegerTree> nodesByKey;

        public IntegerTreeFactory()
        {
            nodesByKey = new Dictionary<int, IntegerTree>();
        }

        public IntegerTree CreateTreeFromStrings(string[] input)
        {
            foreach (var pair in input)
            {
                var nodes = pair.Split();

                var parent = int.Parse(nodes[0]);
                var child = int.Parse(nodes[1]);

                AddEdge(parent, child);
            }

            return GetRoot();
        }

        public IntegerTree CreateNodeByKey(int key)
        {
            IntegerTree newIntegerTree;

            if (!nodesByKey.ContainsKey(key))
            {
                newIntegerTree = new IntegerTree(key);

                nodesByKey.Add(key, newIntegerTree);
            }
            else
            {
                newIntegerTree = nodesByKey[key];
            }

            return newIntegerTree;
        }

        public void AddEdge(int parent, int child)
        {
            var parentNode = CreateNodeByKey(parent);
            var childNode = CreateNodeByKey(child);

            parentNode.AddChild(childNode);
            childNode.AddParent(parentNode);
        }

        public IntegerTree GetRoot()
        {
            var root = nodesByKey
                .Where(d => d.Value.Parent is null)
                .Select(d => d.Value)
                .FirstOrDefault();

            return root;
        }
    }
}
