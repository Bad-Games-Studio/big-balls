using BallMVP;
using UnityEngine;
using Zenject;

namespace DependencyInjection
{
    public class BallInjection : MonoInstaller
    {
        [SerializeField] private int defaultBallHealth = 10;
        [SerializeField] private BallView ballView;
    
        public override void InstallBindings()
        {
            Container.Bind<BallModel>()
                .FromNew()
                .AsSingle()
                .WithArguments(defaultBallHealth)
                .NonLazy();

            Container.Bind<BallView>()
                .FromInstance(ballView)
                .AsSingle()
                .NonLazy();

            Container.Bind<BallPresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}