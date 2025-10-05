using System;
using System.Collections.Generic;

namespace Core.WindowManager
{
    public class WindowManager : IWindowManager
    {
        private readonly WindowsLoader _windowsLoader;
        private readonly Dictionary<Type, IWindow> _windows = new();

        public WindowManager()
        {
            _windowsLoader = new();
            LoadWindow();
        }

        public T ShowWindow<T, TWindowPresenter>(TWindowPresenter windowPresenter) where T : WindowBase<TWindowPresenter>
        {
            T window = EnableWindow<T, TWindowPresenter>(windowPresenter);
            window.transform.SetAsLastSibling();
            return window;
        }
        
        public void CloseWindow<T>() where T : IWindow
        {
            Type windowType = typeof(T);

            if (_windows.TryGetValue(windowType, out IWindow window))
            {
                window.CloseWindow();
            }
        }
        
        private T EnableWindow<T, TWindowPresenter>(TWindowPresenter windowPresenter) where T : WindowBase<TWindowPresenter>
        {
            if (!TryGetWindow(out T window))
            {
                throw new Exception($"Window not found: {typeof(TWindowPresenter)}");
            }

            window.SetPresenter(windowPresenter);
            window.Init();
            window.OpenWindow();
			
            return window;
        }
        
        private bool TryGetWindow<T>(out T window) where T : class, IWindow
        {
            if (_windows.ContainsKey(typeof(T)))
            {
                window = _windows[typeof(T)] as T;

                return true;
            }

            window = null;
            return false;
        }
        
        private void LoadWindow()
        {
            Dispose();
            _windowsLoader.LoadWindows(_windows);
        }
        
        public void Dispose()
        {
            foreach (IWindow windowsValue in _windows.Values)
            {
                windowsValue.Unload();
            }

            _windows.Clear();
        }
    }
}