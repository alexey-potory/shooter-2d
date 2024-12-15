using Codebase.Logic.Factories;
using Codebase.Logic.Gameplay.Shooting;
using Zenject;

namespace Codebase.Logic.Gameplay.Installers
{
    public class ShootingInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ShootingSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<AmmoSystem>().FromInstance(new AmmoSystem(50)).AsSingle();
            Container.Bind<ProjectileFactory>().AsTransient();
        }
    }
}