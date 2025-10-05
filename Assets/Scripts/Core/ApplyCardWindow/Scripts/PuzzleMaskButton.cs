using System;
using UnityEngine;
using UnityEngine.UI;
using Utils.Extensions;

namespace Core.ApplyCardWindow.Scripts
{
    public class PuzzleMaskButton : MonoBehaviour
    {
        [SerializeField] private EPuzzleType type;
        [SerializeField] private Sprite maskSprite;
        [SerializeField] private Button button;
        [SerializeField] private GameObject chosenObject;

        private Image _puzzleImage;
        private Action<EPuzzleType> _callback;
        
        public void Initialize(Image puzzleImage, Action<EPuzzleType> callback)
        {
            _puzzleImage = puzzleImage;
            _callback = callback;
            
            button.SetOnClickAction(OnPuzzleButtonClick);
        }

        public void OnPuzzleButtonClick()
        {
            _puzzleImage.gameObject.SetActive(true);
            _puzzleImage.sprite = maskSprite;
            
            _callback?.Invoke(type);
        }

        public void ChooseNewPuzzleType(EPuzzleType puzzleType)
        {
            chosenObject.SetActive(puzzleType == type);
        }
    }
}