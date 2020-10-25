using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SADAssessment.Library
{
    public class Book
    {
       
        public string Author { get; private set; }
        public string Title { get; private set; }

        // For serialization purposes
        public Book() { }

        public Book(string author, string title)
        {
            Author = author;
            Title = title;
        }
    }
}
