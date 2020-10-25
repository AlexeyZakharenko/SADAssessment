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
        private ConcurrentDictionary<string, Book> _bookshelf = new ConcurrentDictionary<string, Book>();

        public List<Book> List()
        {
            return _bookshelf.Values.ToList();
        }

        public void Add(Book book)
        {
            _bookshelf.GetOrAdd($"{book.Author}:{book.Title}", book);
        }

        public void Remove(Book book)
        {
            _bookshelf.TryRemove($"{book.Author}:{book.Title}", out Book _);
        }

    }
}
