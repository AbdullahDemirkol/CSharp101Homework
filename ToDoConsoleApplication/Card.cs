using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoConsoleApplication
{
    internal class Card
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string AssignedPerson { get; set; }
        public CardSizeEnum CardSize { get; set; }
        public CardLineEnum? Line { get; set; }

        public Card(string title, string content, string assignedPerson, CardSizeEnum cardSize, CardLineEnum? line)
        {
            Title = title;
            Content = content;
            AssignedPerson = assignedPerson;
            CardSize = cardSize;
            Line = line;
        }



    }
}
