using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace SADAssessment.Library
{
    public class VirtualLibrary : ILibrary
    {

        // Singleton pattern
        public static VirtualLibrary Get()
        {
            if (_library == null)
                _library = new VirtualLibrary();
            return _library;
        }


        private static VirtualLibrary  _library;

        // Book storage
        private BlockingCollection<Book> _bookshelf = new BlockingCollection<Book>();

        public List<Book> List()
        {
            return _bookshelf.ToList();
        }

        public void Add(Book book)
        {
            _bookshelf.Add(book);
        }

    }
}
