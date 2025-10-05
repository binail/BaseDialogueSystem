using System;
using UnityEngine.UI;

namespace Utils.Extensions
{
    public static class ButtonExtensions
    {
        public static void SetOnClickAction(this Button button, Action onClick, bool playClickSound = true)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => onClick?.Invoke());
        }
    }
}