using System;
using ImageSharp;

namespace MiniArtLibrary.Elements
{
    public class Canvas
    {
        // Settings applying equally to all pieces of artwork

        public int Height { get; private set; } = 2560;
        public int Width { get; private set; } = 2560;
        public int FrameWidth { get; private set; } = 256;
        public float Dpi { get; private set; } = 256;


        // Settings that can be overwritten by filters

        public int SmallSize { get; set; } = 64;
        public int MediumSize { get; set; } = 320;
        public int LargeSize { get; set; } = 640;

        public Rgba32 BackgroundColor { get; set; } = Rgba32.White;
        public Rgba32 ShapeColor { get; set; } = Rgba32.Black;
        public Rgba32 LineColor { get; set; } = Rgba32.Black;
        public int LineWidth { get; set; } = 4;

        internal int GetSize(ElementSize size)
        {
            switch (size)
            {
                case ElementSize.Small:
                    return SmallSize;
                case ElementSize.Medium:
                    return MediumSize;
                case ElementSize.Large:
                    return LargeSize;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}