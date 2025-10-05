using UnityEngine;

namespace Core.CardsProvider
{
    public interface ICardsProvider
    {
        Sprite[] GetAllCards();
        Sprite GetCardByName(string cardName);
    }
}