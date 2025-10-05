using System.Collections.Generic;
using System.Linq;
using Core.WindowManager;
using UnityEngine;
using UnityEngine.UI;
using Utils.Extensions;

namespace Core.ApplyCardWindow.Scripts
{
    public class ApplyCardWindow : WindowBase<IApplyCardWindowPresenter>
    {
        [SerializeField] private Image cardImage;
        [SerializeField] private Image puzzleMaskImage;
        [SerializeField] private List<Button> closeButtons;
        [SerializeField] private List<PuzzleMaskButton> puzzleButtons;
        [SerializeField] private List<StartPuzzleButton> startButtons;
        
        public override void Init()
        {
            puzzleMaskImage.gameObject.SetActive(false);
            cardImage.sprite = _windowPresenter.GetCardSprite();

            closeButtons.ForEach(closeButton => closeButton.SetOnClickAction(_windowPresenter.CloseWindow));
            startButtons.ForEach(startButton => startButton.Initialize(_windowPresenter.StartPuzzle));
            puzzleButtons.ForEach(puzzleButton => puzzleButton.Initialize(puzzleMaskImage, OnPuzzleButtonClick));
            puzzleButtons.First().OnPuzzleButtonClick();
        }

        private void OnPuzzleButtonClick(EPuzzleType puzzleType)
        {
            _windowPresenter.SetPuzzleType(puzzleType);
            puzzleButtons.ForEach(puzzleButton => puzzleButton.ChooseNewPuzzleType(puzzleType));
        }
    }
}