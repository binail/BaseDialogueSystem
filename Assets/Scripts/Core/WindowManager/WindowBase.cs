using UnityEngine;

namespace Core.WindowManager
{
    public abstract class WindowBase<TWindowPresenter> : MonoBehaviour, IWindow
    {
        protected TWindowPresenter _windowPresenter;
        
        public bool IsOpened { get; private set; }
        
        public abstract void Init();
        
        public void SetPresenter(TWindowPresenter windowPresenter)
        {
            _windowPresenter = windowPresenter;
        }
        
        public void CloseWindow()
        {
            IsOpened = false;
            gameObject.SetActive(false);
        }

        public void OpenWindow()
        {
            IsOpened = true;
            gameObject.SetActive(true);
        }

        public void Unload()
        {
            Destroy(gameObject);
        }
    }

    public interface IWindow
    {
        bool IsOpened { get; }
        void CloseWindow();
        void OpenWindow();
        void Unload();
    }
}