using Core.ApplyCardWindow.Scripts;
using UnityEngine;

namespace Core.ApplyCardWindow
{
    public interface IApplyCardWindowPresenter
    {
        Sprite GetCardSprite();
        void SetPuzzleType(EPuzzleType puzzleType);
        void StartPuzzle(EPriceType priceType);
        void CloseWindow();
    }
}