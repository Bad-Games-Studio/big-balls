using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
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
            .AsSingle();

        Container.Bind<BallPresenter>().AsSingle().NonLazy();
    }
}