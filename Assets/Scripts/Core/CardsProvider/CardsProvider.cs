using UnityEngine;

namespace Core.CardsProvider
{
    public class CardsProvider : ICardsProvider
    {
        private const string CARDS_PATH = "Cards/";
        
        public Sprite[] GetAllCards()
        {
            return Resources.LoadAll<Sprite>(CARDS_PATH);
        }

        public Sprite GetCardByName(string cardName)
        {
            return Resources.Load<Sprite>(CARDS_PATH + cardName);
        }
    }
}