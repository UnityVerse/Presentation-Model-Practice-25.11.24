using System.ComponentModel;
using Game.GameEngine;
using UnityEngine;
using Zenject;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "DialogueInstaller",
        menuName = "Gameplay/New DialogueInstaller"
    )]
    public sealed class DialogueInstaller: ScriptableObjectInstaller
    {
        [SerializeField] private DialogueConfig config;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<Dialogue>()
                .AsSingle()
                .WithArguments(config);

        }
    }
}