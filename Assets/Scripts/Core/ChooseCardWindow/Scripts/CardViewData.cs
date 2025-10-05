using System;
using UnityEngine;

namespace Core.ChooseCardWindow.Scripts
{
    public class CardViewData
    {
        public Sprite Icon { get; }
        public Action OnClickAction { get; }

        public CardViewData(Sprite icon, Action onClickAction)
        {
            Icon = icon;
            OnClickAction = onClickAction;
        }
    }
}