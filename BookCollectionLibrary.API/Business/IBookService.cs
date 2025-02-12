using BookCollectionLibrary.API.Data.VO;

namespace BookCollectionLibrary.API.Business;

public interface IBookService
{
    BookVO Create(BookVO book);
    BookVO FindById(long id);
    BookVO Update(BookVO book);
    void Delete(long id);
    List<BookVO> FindAll();
}
