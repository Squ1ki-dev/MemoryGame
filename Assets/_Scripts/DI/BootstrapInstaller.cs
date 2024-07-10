using System;
using SettingsService = Code.Runtime.Infrastructure.Settings.SettingsService;
using Code.Runtime.Infrastructure.Services.SaveLoad;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    public Card _card;
    public CardSpawner _cardSpawner;
    public CardController _cardController;
    public MenuUI _menu;
    public AudioPlayer _audioPlayer;

    public override void InstallBindings()
    {
        BindCard();
        BindUI();
        BindInput();
        BindAudio();
        BindInfrastructureServices();
    }

    private void BindCard()
    {
        Container
            .Bind<Card>()
            .FromInstance(_card)
            .AsSingle();

        Container
            .Bind<CardSpawner>()
            .FromInstance(_cardSpawner)
            .AsSingle();
    }

    private void BindUI()
    {
        Container
            .Bind<MenuUI>()
            .FromInstance(_menu)
            .AsSingle();
    }

    private void BindInput()
    {
        Container
            .Bind<CardController>()
            .FromInstance(_cardController)
            .AsSingle();
    }

    private void BindAudio()
    {
        Container
            .Bind<AudioPlayer>()
            .FromInstance(_audioPlayer)
            .AsSingle();
    }

    private void BindInfrastructureServices()
    {
        Container
            .BindInterfacesAndSelfTo<SettingsService>()
            .AsSingle();
        Container
            .Bind<ISaveLoadService>()
            .To<SaveLoadService>()
            .AsSingle();
    }
}
