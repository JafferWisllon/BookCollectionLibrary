namespace BookCollectionLibrary.API.Hypermedia.Abstract;

public interface ISupportsHyperMedia
{
    List<HyperMediaLink> links { get; set; }
}
