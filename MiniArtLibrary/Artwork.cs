using ImageSharp;
using MiniArtLibrary.Elements;
using MiniArtLibrary.Filters;
using MiniArtLibrary.Miscellaneous;
using System.IO;
using System.Linq;

namespace MiniArtLibrary
{
    /// <summary>
    /// Serializable class completely defining a piece of artwork.
    /// </summary>
    public class Artwork
    {
        public string Creator { get; set; }
        public string Title { get; set; }

        public LineElement Line1 { get; set; }
        public LineElement Line2 { get; set; }

        public SolidElement SmallSolid1 { get; set; }
        public SolidElement MediumSolid1 { get; set; }

        public OutlineElement SmallOutline1 { get; set; }
        public OutlineElement SmallOutline2 { get; set; }
        public OutlineElement LargeOutline1 { get; set; }
        public OutlineElement LargeOutline2 { get; set; }
    }
}
