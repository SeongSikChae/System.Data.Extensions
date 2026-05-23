using System.Data;

namespace System.Collections.Generic
{
    internal sealed class ColumnComparer : IComparer<IColumn>
    {
        public int Compare(IColumn? x, IColumn? y)
        {
            if (ReferenceEquals(x, y))
                return 0;

            if (x is null)
                return -1;

            if (y is null)
                return 1;

            return x.CompareTo(y);
        }
    }
}
