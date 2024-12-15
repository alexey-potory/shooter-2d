using Codebase.Logic.Factories;
using Codebase.Logic.Gameplay.Loot;
using Zenject;

namespace Codebase.Logic.Gameplay.Installers
{
    public class LootInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LootFactory>().AsTransient();
            Container.BindInterfacesAndSelfTo<LootSystem>().AsSingle();
        }
    }
}