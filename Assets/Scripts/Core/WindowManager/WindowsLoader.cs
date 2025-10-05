using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.WindowManager
{
    public class WindowsLoader
    {
        private WindowsProvider _windowsRoot;
        
        private const string WINDOW_PATH = "Windows/";
        
        private WindowsProvider WindowsProvider
        {
            get
            {
                if (_windowsRoot == null)
                {
                    var providers = Object.FindObjectsOfType<WindowsProvider>();

                    if (providers.Length <= 0)
                    {
                        Debug.LogError($"Has no {typeof(WindowsProvider)} on Scene");
                    }
                    else if (providers.Length > 1)
                    {
                        Debug.LogError($"More than one  {typeof(WindowsProvider)} on Scene");
                    }

                    _windowsRoot = providers.FirstOrDefault();
                }
                
                return _windowsRoot;
            }
        }
        
        public void LoadWindows(Dictionary<Type, IWindow> windows)
        {
            var windowPrefabs = Resources.LoadAll<GameObject>(WINDOW_PATH);
            
            foreach (var windowsBasePrefab in windowPrefabs)
            {
                var windowInstance = Object.Instantiate(windowsBasePrefab, WindowsProvider.WindowsRoot.transform, false);
                windowInstance.gameObject.SetActive(false);
                
                var windowComponent = windowInstance.GetComponent<IWindow>();
                var windowType = windowComponent.GetType();
               
                windows.Add(windowType, windowComponent);
            }
        }
    }
}