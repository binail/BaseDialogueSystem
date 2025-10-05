using System;

namespace Core.WindowManager
{
    public interface IWindowManager : IDisposable
    {
        T ShowWindow<T, TWindowPresenter>(TWindowPresenter windowPresenter) where T : WindowBase<TWindowPresenter>;
        void CloseWindow<T>() where T : IWindow;
    }
}