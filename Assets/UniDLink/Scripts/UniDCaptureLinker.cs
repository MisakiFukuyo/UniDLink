using System;
using System.Collections.Generic;

namespace UniDLink
{
    public class UniDCaptureLinker<T, TCapt> : IUniDCapturelizable, IUniDSignalizable, IUniDSignalModdable<T>, IUniDLinkable<T>, IUniDDualLinkable<T> 
    {
        private Func<TCapt, T> capturing;
        private Action<TCapt, T> insert;
        private List<Action<T>> onSignaledActions = new List<Action<T>>();
        private TCapt captureTarget;

        public T LinkedValue
        {
            get
            {
                return capturing(captureTarget);
            }
            set
            {
                insert(captureTarget, value);
                Signaling();
            }
        }

        public UniDCaptureLinker(TCapt captureTarget, Func<TCapt, T> capturing, Action<TCapt, T> insert)
        {
            this.captureTarget = captureTarget;
            this.capturing = capturing;
            this.insert = insert;
        }

        public void Capturing()
        {
            LinkedValue = capturing(captureTarget);
        }

        public Action<T> AddOnSignaled(Action<T> act)
        {
            onSignaledActions.Add(act);
            return act;
        }
        
        public void RemoveOnSignaled(Action<T> act)
        {
            onSignaledActions.Remove(act);
        }

        public void Signaling()
        {
            T capturedValue = capturing(captureTarget);
            foreach (Action<T> act in onSignaledActions)
            {
                act(capturedValue);
            }
        }
    }
}