using BookCollectionLibrary.API.Model;

namespace BookCollectionLibrary.API.Repository;

public interface IBookRepository
{
    Book Create(Book book);
    Book FindById(long id);
    Book Update(Book person);
    void Delete(long id);
    List<Book> FindAll();
    bool Exists(long id);
}
