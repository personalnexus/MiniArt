using MiniArtLibrary.Elements;
using ImageSharp.Drawing.Pens;
using ImageSharp;
using SixLabors.Primitives;
using SixLabors.Shapes;
using SixLabors.Fonts;

namespace MiniArtLibrary.Filters
{
    /// <summary>
    /// The default filter does not apply any transformations but relies on the canvas defaults and uses a circle as the shape for solids and outlines.
    /// </summary>
    public class DefaultArtworkFilter : IArtworkFilter
    {
        public DefaultArtworkFilter()
        {
            _canvas = new Canvas();
            _image = new Image<Rgba32>(_canvas.Width, _canvas.Height);
            _image.Fill(_canvas.BackgroundColor);
        }

        private Canvas _canvas;
        private Image<Rgba32> _image;

        public virtual void DrawLine(LineElement line)
        {
            var pen = new Pen<Rgba32>(_canvas.LineColor, _canvas.LineWidth);
            var point1 = new PointF(line.X, line.Y);
            var point2 = line.Orientation == LineOrientation.Horizontal ?
                    new PointF(line.X + line.Length, line.Y) :
                    new PointF(line.X, line.Y + line.Length);
            _image.DrawLines(pen, new PointF[] { point1, point2 });
        }

        public virtual void DrawOutline(OutlineElement outline, ElementSize size)
        {
            IPath shape = CreateShape(outline, size);
            _image.Fill(_canvas.BackgroundColor, shape);
            _image.Draw(_canvas.LineColor, _canvas.LineWidth, shape);
        }

        public virtual void DrawSolid(SolidElement solid, ElementSize size)
        {
            IPath shape = CreateShape(solid, size);
            _image.Fill(_canvas.ShapeColor, shape);
        }

        protected virtual IPath CreateShape(ShapeElement element, ElementSize size)
        {
            int radius = _canvas.GetSize(size) / 2;
            var circle = new EllipsePolygon(element.X + radius, element.Y + radius, radius);
            return circle;
        }

        public virtual Image<Rgba32> FinishImage(string title)
        {
            var result = new Image<Rgba32>(_image.Width + 2 * _canvas.FrameWidth, _image.Height + 2 * _canvas.FrameWidth);
            result.Fill(_canvas.BackgroundColor);
            result.DrawImage(_image, 1, new Size(_image.Width, _image.Height), new Point(_canvas.FrameWidth, _canvas.FrameWidth));

            var frame = new RectangularePolygon(_canvas.FrameWidth, _canvas.FrameWidth, _image.Width, _image.Height);
            result.Draw(_canvas.LineColor, _canvas.LineWidth, frame);

            // TODO: pick title font and add title at bottom right
            // var titleFont = new Font()
            // SizeF titleSize = TextMeasurer.Measure(title, null, _canvas.Dpi);
            // var titleLocation = new PointF(_image.Width + _canvas.FrameWidth - titleSize.Width,
            //                                _image.Height + _canvas.FrameWidth + ((_canvas.FrameWidth - titleSize.Height) / 2));
            // result.DrawText(title, null, _canvas.LineColor, titleLocation);

            return result;
        }
    }
}