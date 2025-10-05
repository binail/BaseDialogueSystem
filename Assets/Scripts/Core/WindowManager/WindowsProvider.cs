using UnityEngine;

namespace Core.WindowManager
{
    public class WindowsProvider : MonoBehaviour
    {
        [field: SerializeField] public Canvas WindowsRoot { get; private set; }
    }
}