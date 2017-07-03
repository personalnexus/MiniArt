using ImageSharp;
using MiniArtLibrary.Elements;
using MiniArtLibrary.Filters;
using MiniArtLibrary.Miscellaneous;
using System.IO;
using System.Linq;

namespace MiniArtLibrary
{
    public class ArtworkUtility
    {
        public static void CreatePng(Artwork artwork, Stream output, IArtworkFilter filter)
        {
            using (var image = CreateImage(artwork, filter))
            {
                image.SaveAsPng(output);
            }
        }

        public static Image<Rgba32> CreateImage(Artwork artwork, IArtworkFilter filter)
        {
            var drawings = new ZOrderDrawing[]
            {
                ZOrderDrawing.Create(artwork.Line1, x => filter.DrawLine(x)),
                ZOrderDrawing.Create(artwork.Line2, x => filter.DrawLine(x)),

                ZOrderDrawing.Create(artwork.SmallSolid1, x => filter.DrawSolid(x, ElementSize.Small)),
                ZOrderDrawing.Create(artwork.MediumSolid1, x => filter.DrawSolid(x, ElementSize.Medium)),

                ZOrderDrawing.Create(artwork.SmallOutline1, x => filter.DrawOutline(x, ElementSize.Small)),
                ZOrderDrawing.Create(artwork.SmallOutline2, x => filter.DrawOutline(x, ElementSize.Small)),
                ZOrderDrawing.Create(artwork.LargeOutline1, x => filter.DrawOutline(x, ElementSize.Large)),
                ZOrderDrawing.Create(artwork.LargeOutline2, x => filter.DrawOutline(x, ElementSize.Large)),
            };

            foreach (ZOrderDrawing drawing in drawings.OrderBy(x => x.Z))
            {
                drawing.Execute();
            }

            return filter.FinishImage(artwork.Title);
        }
    }
}
