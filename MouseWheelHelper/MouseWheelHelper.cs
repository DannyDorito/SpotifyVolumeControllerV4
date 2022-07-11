using Gma.System.MouseKeyHook;

namespace MouseWheelHelperLib
{
    public class MouseWheelHelper
    {
        private IKeyboardMouseEvents? _hook;
        private bool _disposed = false;

        public MouseWheelHelper()
        {
            Subscribe();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                Unsubscribe();
            }
            _disposed = true;
        }

        private void Subscribe()
        {
            if (_hook is not null)
            {
                _hook = Hook.GlobalEvents();
                _hook.MouseWheelExt += Scroll;
            }
        }

        private void Scroll(object sender, MouseEventExtArgs e)
        {
            // do something
        }

        private void Unsubscribe()
        {
            if (_hook is not null)
            {
                _hook.MouseWheelExt -= Scroll;
                _hook.Dispose();
            }
        }
    }
}