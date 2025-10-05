using System.Collections.Generic;
using Core.WindowManager;
using UnityEngine;

namespace Core.ChooseCardWindow.Scripts
{
    public class ChooseCardWindow : WindowBase<IChooseCardWindowPresenter>
    {
        [SerializeField] private RectTransform cardsHolder;
        [SerializeField] private CardView cardPrefab;
        
        private List<CardView> cardViews;
        
        public override void Init()
        {
            cardViews ??= new List<CardView>();

            var cardsViewData = _windowPresenter.GetCardsViewData();

            while (cardsViewData.Count > cardViews.Count)
            {
                var newElement = Instantiate(cardPrefab, cardsHolder);
                cardViews.Add(newElement);
            }

            for (int i = 0; i < Mathf.Max(cardsViewData.Count, cardViews.Count); i++)
            {
                if (cardsViewData.Count > i)
                {
                    cardViews[i].Initialize(cardsViewData[i]);
                }
                else
                {
                    cardViews[i].Disable();
                }
            }
        }
    }
}