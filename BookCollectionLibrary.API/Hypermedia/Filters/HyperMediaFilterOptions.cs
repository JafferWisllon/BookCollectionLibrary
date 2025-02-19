using BookCollectionLibrary.API.Hypermedia.Abstract;

namespace BookCollectionLibrary.API.Hypermedia.Filters;

public class HyperMediaFilterOptions
{
    public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
}
