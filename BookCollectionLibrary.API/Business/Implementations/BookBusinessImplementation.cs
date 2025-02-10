﻿using BookCollectionLibrary.API.Model;
using BookCollectionLibrary.API.Repository.Generic;

namespace BookCollectionLibrary.API.Business.Implementations
{
    public class BookBusinessImplementation : IBookService
    {
        private readonly IRepository<Book> _bookRepository;

        public BookBusinessImplementation(IRepository<Book> bookRepository)
            => _bookRepository = bookRepository;

        public List<Book> FindAll()
        {
            return _bookRepository.FindAll();
        }

        public Book FindById(long id)
        {
            return _bookRepository.FindById(id);
        }

        public Book Create(Book book)
        {
            return _bookRepository.Create(book);
        }

        public Book Update(Book person)
        {
            return _bookRepository.Update(person);
        }

        public void Delete(long id)
        {
            _bookRepository.Delete(id);
        }
    }
}
