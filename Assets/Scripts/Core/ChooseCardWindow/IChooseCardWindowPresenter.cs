using System.Collections.Generic;
using Core.ChooseCardWindow.Scripts;

namespace Core.ChooseCardWindow
{
    public interface IChooseCardWindowPresenter
    {
        List<CardViewData> GetCardsViewData();
    }
}