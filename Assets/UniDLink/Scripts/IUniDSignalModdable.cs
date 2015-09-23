using System;

namespace UniDLink
{
    public interface IUniDSignalModdable<T>
    {
        Action<T> AddOnSignaled(Action<T> act);
        void RemoveOnSignaled(Action<T> act);
    }
}