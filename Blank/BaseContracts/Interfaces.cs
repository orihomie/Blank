using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Blank.BaseContracts
{
    public interface IFigure<T>
    {
        T Shape { get; }

        T Perimeter { get; }
    }

    public interface IFigure : IFigure<double>
    { }

    public interface ITriangle
    {
        bool IsRight { get; }
    }
}
