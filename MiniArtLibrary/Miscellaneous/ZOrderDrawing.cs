using MiniArtLibrary.Elements;
using System;

namespace MiniArtLibrary.Miscellaneous
{
    internal abstract class ZOrderDrawing
    {
        public abstract int Z { get; }
        public abstract void Execute();

        public static ZOrderDrawing<T> Create<T>(T element, Action<T> drawAction)
            where T: Element
        {
            return new ZOrderDrawing<T>(element, drawAction);
        }
    }

    internal class ZOrderDrawing<T>: ZOrderDrawing
        where T : Element
    {
        public ZOrderDrawing(T element, Action<T> drawAction)
        {
            _element = element;
            _drawAction = drawAction;
        }

        private T _element;
        private Action<T> _drawAction;

        public override int Z { get { return _element?.Z ?? 0; } }
        
        public override void Execute()
        {
            if (_element != null)
            {
                _drawAction(_element);
            }
        }
    }
}
