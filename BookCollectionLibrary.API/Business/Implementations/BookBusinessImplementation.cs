using BookCollectionLibrary.API.Data.Converter.Implementations;
using BookCollectionLibrary.API.Data.VO;
using BookCollectionLibrary.API.Model;
using BookCollectionLibrary.API.Repository.Generic;

namespace BookCollectionLibrary.API.Business.Implementations
{
    public class BookBusinessImplementation : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly BookConverter _converter;
        public BookBusinessImplementation(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
            _converter = new BookConverter();
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_bookRepository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_bookRepository.FindById(id));
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _bookRepository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _bookRepository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _bookRepository.Delete(id);
        }
    }
}
