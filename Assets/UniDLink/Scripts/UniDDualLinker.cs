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
            aAct = a.AddOnSignaled((t) => { if (!dualLinking) { b.LinkedValue = t; dualLinking = true; } else { dualLinking = false; } });
            bAct = b.AddOnSignaled((t) => { if (!dualLinking) { a.LinkedValue = t; dualLinking = true; } else { dualLinking = false; } });
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

        public static UniDDualLinker<T> DualLink<T>(IUniDDualLinkable<T> a,IUniDDualLinkable<T> b)
        {
            return new UniDDualLinker<T>(a, b);
        }
    }
}