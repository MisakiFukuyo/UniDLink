using System;

namespace UniDLink
{
    public interface IUniDSignalModdable<T>
    {
        void AddOnSignaled(Action<T> act);
        void RemoveOnSignaled(Action<T> act);
    }
}