using Core.ApplyCardWindow.Scripts;
using Core.CardsProvider;
using Core.WindowManager;
using UnityEngine;

namespace Core.ApplyCardWindow
{
    public class ApplyCardWindowPresenter : IApplyCardWindowModule, IApplyCardWindowPresenter
    {
        private readonly IWindowManager _windowManager;
        private readonly ICardsProvider _cardsProvider;

        private string _currentCardName;
        private Sprite _currentCardSprite;
        private EPuzzleType _currentPuzzleType;
        
        ApplyCardWindowPresenter(IWindowManager windowManager,
            ICardsProvider cardsProvider)
        {
            _windowManager = windowManager;
            _cardsProvider = cardsProvider;
        }
        
        public void ShowWindow(string cardName)
        {
            _currentCardName = cardName;
            
            _windowManager.ShowWindow<Scripts.ApplyCardWindow, IApplyCardWindowPresenter>(this);
        }

        public Sprite GetCardSprite()
        {
            if (_currentCardSprite == null || _currentCardSprite.name != _currentCardName)
            {
                _currentCardSprite = _cardsProvider.GetCardByName(_currentCardName);
            }
            
            return _currentCardSprite;
        }

        public void SetPuzzleType(EPuzzleType puzzleType)
        {
            _currentPuzzleType = puzzleType;
        }

        public void StartPuzzle(EPriceType priceType)
        {
            Debug.Log($"Starting puzzle with card name {_currentCardName}. " +
                      $"Puzzle type is {_currentPuzzleType} and price is {priceType}");
            
            CloseWindow();
        }

        public void CloseWindow()
        {
            _windowManager.CloseWindow<Scripts.ApplyCardWindow>();
        }
    }
}