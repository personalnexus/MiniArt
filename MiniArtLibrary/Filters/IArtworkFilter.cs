using ImageSharp;
using MiniArtLibrary.Elements;

namespace MiniArtLibrary.Filters
{
    public interface IArtworkFilter
    {
        void DrawLine(LineElement line);
        void DrawOutline(OutlineElement outline, ElementSize size);
        void DrawSolid(SolidElement solid, ElementSize size);

        Image<Rgba32> FinishImage(string title);
    }
}
