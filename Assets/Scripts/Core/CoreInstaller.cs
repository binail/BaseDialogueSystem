using Core.ApplyCardWindow;
using Core.CardsProvider;
using Core.ChooseCardWindow;
using Core.WindowManager;
using Zenject;

namespace Core
{
    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IWindowManager>().To<WindowManager.WindowManager>().AsSingle();
            Container.Bind<IChooseCardWindowModule>().To<ChooseCardWindowPresenter>().AsSingle();
            Container.Bind<IApplyCardWindowModule>().To<ApplyCardWindowPresenter>().AsSingle();
            Container.Bind<ICardsProvider>().To<CardsProvider.CardsProvider>().AsSingle();
            
            Container.Resolve<IWindowManager>();
            var cardWindowModule = Container.Resolve<IChooseCardWindowModule>();
            cardWindowModule.ShowWindow();
        }
    }
}