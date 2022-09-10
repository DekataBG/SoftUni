namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using _01._BrowserHistory.Interfaces;

    public class BrowserHistory : IHistory
    {
        LinkedList<ILink> links;

        public BrowserHistory()
        {
            links = new LinkedList<ILink>();
        }

        public int Size => links.Count;

        public void Clear()
        {
            links.Clear();
        }

        public bool Contains(ILink link)
        {
            return links.Contains(link);
        }

        public ILink DeleteFirst()
        {
            EnsureNotEmpty();

            ILink link = links.Last.Value;

            links.RemoveLast();

            return link;
        }

        public ILink DeleteLast()
        {
            EnsureNotEmpty();

            var last = links.First.Value;

            links.RemoveFirst();

            return last;
        }

        public ILink GetByUrl(string url)
        {
            var link = links.FirstOrDefault(l => l.Url == url);

            return link;
        }

        public ILink LastVisited()
        {
            EnsureNotEmpty();

            var link = links.First.Value;

            return link;
        }

        public void Open(ILink link)
        {
            links.AddFirst(link);
        }

        public int RemoveLinks(string url)
        {
            EnsureNotEmpty();

            url = url.ToLower();

            int count = 0;

            var currentNode = links.First;

            while (currentNode != null)
            {
                var nextNode = currentNode.Next;

                if (currentNode.Value.Url.ToLower().Contains(url))
                {
                    links.Remove(currentNode.Value);
                    count++;
                }

                currentNode = nextNode;
            }

            if (count == 0)
            {
                throw new InvalidOperationException();
            }

            return count;
            

            //var linksWithUrl = links
            //    .Where(l => l.Url.ToLower().Contains(url.ToLower()));

            //if (linksWithUrl.Count() ==  0)
            //{
            //    throw new InvalidOperationException();
            //}

            //var linksToRemove = new List<ILink>();

            //foreach (var link in linksWithUrl)
            //{
            //    linksToRemove.Add(link);
            //}


            //foreach (var link in linksToRemove)
            //{
            //    links.Remove(link);
            //}

            //return linksToRemove.Count;
        }

        public ILink[] ToArray()
        {
            return links.ToArray();
        }

        public List<ILink> ToList()
        {
            return links.ToList();
        }

        public string ViewHistory()
        {
            if (Size == 0)
            {
                return "Browser history is empty!";
            }

            var stringBuilder = new StringBuilder();

            ToList().ForEach(l => stringBuilder.AppendLine(l.ToString()));

            return stringBuilder.ToString();
        }

        private void EnsureNotEmpty()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
