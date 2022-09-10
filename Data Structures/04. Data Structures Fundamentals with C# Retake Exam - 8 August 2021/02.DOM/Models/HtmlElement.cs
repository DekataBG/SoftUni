namespace _02.DOM.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using _02.DOM.Interfaces;

    public class HtmlElement : IHtmlElement
    {
        public HtmlElement(ElementType type, params IHtmlElement[] children)
        {
            Type = type;
            Attributes = new Dictionary<string, string>();
            Children = new List<IHtmlElement>();

            foreach (var child in children)
            {
                Children.Add(child);
                child.Parent = this;
            }
        }

        public ElementType Type { get; set; }

        public IHtmlElement Parent { get; set; }

        public List<IHtmlElement> Children { get; }

        public Dictionary<string, string> Attributes { get; }
    }
}
