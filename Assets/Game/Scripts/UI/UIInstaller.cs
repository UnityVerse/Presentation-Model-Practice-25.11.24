using UnityEngine;
using Zenject;

namespace Game.Scripts.UI
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private DialoguePopup dialoguePopup;

        public override void InstallBindings()
        {
            
            Container
                .Bind<DialoguePopup>()
                .FromInstance(dialoguePopup)
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<DialoguePopupShower>()
                .AsSingle();
        }
    }
}