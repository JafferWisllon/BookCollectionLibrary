using BookCollectionLibrary.API.Hypermedia;
using BookCollectionLibrary.API.Hypermedia.Abstract;

namespace BookCollectionLibrary.API.Data.VO;

public class BookVO : ISupportsHyperMedia
{
    public long Id { get; set; }
    public string Author { get; set; }
    public DateTime LaunchDate { get; set; }
    public decimal Price { get; set; }
    public string Title { get; set; }
    public List<HyperMediaLink> links { get; set; } = new List<HyperMediaLink>();
}
