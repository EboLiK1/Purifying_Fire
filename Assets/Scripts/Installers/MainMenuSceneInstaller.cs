using Zenject;

public class MainMenuSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameInput>().AsSingle();
        Container.Bind<PlayerBindings>().AsSingle();
        //Container.Bind<AudioManager>().AsSingle();
    }
}
