using UnityEngine;
using UnityEngine.UI;
using Utils.Extensions;

namespace Core.ChooseCardWindow.Scripts
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Image image;

        public void Initialize(CardViewData viewData)
        {
            gameObject.SetActive(true);
            button.SetOnClickAction(viewData.OnClickAction);
            image.sprite = viewData.Icon;
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}