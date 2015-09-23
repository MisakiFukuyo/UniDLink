using System;

namespace UniDLink
{
    public class UniDDualLinker<T>
    {
        private bool dualLinking = false;
        private Action<T> aAct;
        private Action<T> bAct;
        private IUniDDualLinkable<T> a;
        private IUniDDualLinkable<T> b;

        private UniDDualLinker(IUniDDualLinkable<T> a,IUniDDualLinkable<T> b)
        {
            aAct = a.AddOnSignaled((t) => { if (!dualLinking) { dualLinking = true; b.LinkedValue = t; } else { dualLinking = false; } });
            bAct = b.AddOnSignaled((t) => { if (!dualLinking) { dualLinking = true; a.LinkedValue = t; } else { dualLinking = false; } });
            this.a = a;
            this.b = b;
        }

        public void RemoveDualLink()
        {
            a.RemoveOnSignaled(aAct);
            b.RemoveOnSignaled(bAct);
            aAct = null;
            bAct = null;
            a = null;
            b = null;
        }

        public static UniDDualLinker<T> DualLink(IUniDDualLinkable<T> a, IUniDDualLinkable<T> b)
        {
            return new UniDDualLinker<T>(a, b);
        }
    }
}