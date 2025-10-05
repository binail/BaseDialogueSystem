using System.Collections.Generic;
using Core.ApplyCardWindow;
using Core.CardsProvider;
using Core.ChooseCardWindow.Scripts;
using Core.WindowManager;
using UnityEngine;

namespace Core.ChooseCardWindow
{
    public class ChooseCardWindowPresenter : IChooseCardWindowModule, IChooseCardWindowPresenter
    {
        private readonly IWindowManager _windowManager;
        private readonly IApplyCardWindowModule _applyCardWindowModule;
        private readonly ICardsProvider _cardsProvider;

        private List<CardViewData> _cardsViewData;
        
        public ChooseCardWindowPresenter(IWindowManager windowManager,
            IApplyCardWindowModule applyCardWindowModule,
            ICardsProvider cardsProvider)
        {
            _windowManager = windowManager;
            _applyCardWindowModule = applyCardWindowModule;
            _cardsProvider = cardsProvider;
        }

        public void ShowWindow()
        {
            _windowManager.ShowWindow<Scripts.ChooseCardWindow, IChooseCardWindowPresenter>(this);
        }

        public List<CardViewData> GetCardsViewData()
        {
            _cardsViewData ??= CreateCardsViewData();
            
            return _cardsViewData;
        }

        private List<CardViewData> CreateCardsViewData()
        {
            var cards = _cardsProvider.GetAllCards();
            var result = new List<CardViewData>(cards.Length);

            foreach (var cardSprite in cards)
            {
                result.Add(new CardViewData(cardSprite, () => OnChooseCard(cardSprite.name)));
            }
            
            return result;
        }

        private void OnChooseCard(string cardName)
        {
            _applyCardWindowModule.ShowWindow(cardName);
        }
    }
}