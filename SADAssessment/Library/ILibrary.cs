using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SADAssessment.Library
{
    interface ILibrary
    {
        public List<Book> List();

        public void Add(Book book);

    }
}
