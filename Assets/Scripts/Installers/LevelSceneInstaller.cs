using Zenject;

public class LevelSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameInput>().AsSingle();
        Container.Bind<PlayerBindings>().AsSingle();
        Container.Bind<AudioManager>().AsSingle();
        Container.Bind<Game>().AsSingle();
    }
}
