using System;
using UnityEngine;
using UnityEngine.UI;
using Utils.Extensions;

namespace Core.ApplyCardWindow.Scripts
{
    public class StartPuzzleButton : MonoBehaviour
    {
        [SerializeField] private EPriceType priceType;
        [SerializeField] private Button button;

        public void Initialize(Action<EPriceType> onClickAction)
        {
            button.SetOnClickAction(() => onClickAction?.Invoke(priceType));
        }
    }
}