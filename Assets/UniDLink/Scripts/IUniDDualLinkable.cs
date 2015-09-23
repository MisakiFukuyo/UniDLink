using System.Collections;

namespace UniDLink
{
    public interface IUniDDualLinkable<T> : IUniDSignalizable, IUniDSignalModdable<T>, IUniDLinkable<T> { }
}