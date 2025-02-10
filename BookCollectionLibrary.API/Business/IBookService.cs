using BookCollectionLibrary.API.Model;

namespace BookCollectionLibrary.API.Business;

public interface IBookService
{
    Book Create(Book book);
    Book FindById(long id);
    Book Update(Book person);
    void Delete(long id);
    List<Book> FindAll();
}
