namespace _02.DOM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using _02.DOM.Interfaces;
    using _02.DOM.Models;

    public class DocumentObjectModel : IDocument
    {
        public DocumentObjectModel(IHtmlElement root)
        {
            Root = root;
        }

        public DocumentObjectModel()
        {
            Root = new HtmlElement(ElementType.Document,
                        new HtmlElement(ElementType.Html,
                                new HtmlElement(ElementType.Head),
                                new HtmlElement(ElementType.Body)));
        }

        public IHtmlElement Root { get; private set; }

        public IHtmlElement GetElementByType(ElementType type)
        {
            var queue = new Queue<IHtmlElement>();

            if (Root != null)
            {
                queue.Enqueue(Root);
            }

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode.Type.Equals(type))
                {
                    return currentNode;
                }

                foreach (var child in currentNode.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public List<IHtmlElement> GetElementsByType(ElementType type)
        {
            var elements = new List<IHtmlElement>();

            DfsTraverse(elements, Root, type);

            return elements;
        }

        public bool Contains(IHtmlElement htmlElement)
        {
            var queue = new Queue<IHtmlElement>();

            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode.Equals(htmlElement))
                {
                    return true;
                }

                foreach (var child in currentNode.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return false;
        }

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {
            if (!Contains(parent))
            {
                throw new InvalidOperationException();
            }

            child.Parent = parent;
            parent.Children.Insert(0, child);
        }

        private void ValidateElement(IHtmlElement parent)
        {
            if (!Contains(parent))
            {
                throw new InvalidOperationException();
            }
        }

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {
            if (!Contains(parent))
            {
                throw new InvalidOperationException();
            }

            child.Parent = parent;
            parent.Children.Add(child);
        }

        public void Remove(IHtmlElement htmlElement)
        {
            if (!Contains(htmlElement))
            {
                throw new InvalidOperationException();
            }

            htmlElement.Children.Clear();

            var parent = htmlElement.Parent;
            parent.Children.Remove(htmlElement);
        }

        public void RemoveAll(ElementType elementType)
        {
            var elements = GetElementsByType(elementType);

            foreach (var element in elements)
            {
                Remove(element);
            }
        }

        public bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement)
        {
            if (!Contains(htmlElement))
            {
                throw new InvalidOperationException();
            }

            if (htmlElement.Attributes.ContainsKey(attrKey))
            {
                return false;
            }

            htmlElement.Attributes.Add(attrKey, attrValue);

            return true;
        }

        public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
        {
            if (!Contains(htmlElement))
            {
                throw new InvalidOperationException();
            }

            return htmlElement.Attributes.Remove(attrKey);
        }

        public IHtmlElement GetElementById(string idValue)
        {
            var queue = new Queue<IHtmlElement>();

            if (Root != null)
            {
                queue.Enqueue(Root);
            }

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode.Attributes.ContainsKey("id"))
                {
                    if (currentNode.Attributes["id"] == idValue)
                    {
                        return currentNode;
                    }
                }


                foreach (var child in currentNode.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            ToStringWithIndent(0, Root, stringBuilder);

            return stringBuilder.ToString();
        }

        private void DfsTraverse(List<IHtmlElement> result, IHtmlElement currentElement, ElementType type)
        {
            foreach (var child in currentElement.Children)
            {
                DfsTraverse(result, child, type);
            }

            if (currentElement.Type.Equals(type))
            {
                result.Add(currentElement);
            }

            //return result;
        }

        private void ToStringWithIndent(int indent, IHtmlElement element, StringBuilder stringBuilder)
        {
            stringBuilder.Append(' ', indent).AppendLine(element.Type.ToString());

            foreach (var child in element.Children)
            {
                ToStringWithIndent(indent + 2, child, stringBuilder);
            }
        }
    }

}
