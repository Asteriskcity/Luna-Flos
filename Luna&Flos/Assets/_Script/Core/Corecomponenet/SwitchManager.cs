using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Guagua.CoreSystem
{
    public class SwitchManager : CoreComponent
    {
        public event Action<int> OnWeaponSwitch;
        public event Action OnSwitchInput;

        [SerializeField] private List<Texture2D> WeaponSprite = new();

        private const string m_weaponsprite = "weaponform-sprite";
        private const string m_leftbutton = "left-button";
        private const string m_rightbutton = "right-button";

        private VisualElement switchUI;
        private VisualElement weaponIcon;

        public Button Leftbutton;
        public Button RightButton;

        public int WeaponSprite_index;
        private int currentIndex;

        protected override void Awake()
        {
            base.Awake();

            SetVisualElement();
            //RegisterCallBackEvent();
        }


        private void Start()
        {
            switchUI.style.display = DisplayStyle.None;

            weaponIcon.style.backgroundImage = WeaponSprite[0];
        }


        private void SetVisualElement()
        {
            switchUI = GetComponent<UIDocument>().rootVisualElement;

            weaponIcon = switchUI.Q(m_weaponsprite);

            Leftbutton = switchUI.Q<Button>(m_leftbutton);
            RightButton = switchUI.Q<Button>(m_rightbutton);
        }

        /*private void RegisterCallBackEvent()
        {
            Leftbutton.RegisterCallback<ClickEvent>(GoLastPIC);
            RightButton.RegisterCallback<ClickEvent>(GoNextPIC);
        }*/


        public void GoNextPIC()
        {
            if (WeaponSprite_index == WeaponSprite.Count - 1)
                return;

            WeaponSprite_index++;
            weaponIcon.style.backgroundImage = WeaponSprite[WeaponSprite_index];
        }

        public void GoLastPIC()
        {
            if (WeaponSprite_index == 0)
                return;

            WeaponSprite_index--;
            weaponIcon.style.backgroundImage = WeaponSprite[WeaponSprite_index];
        }


        public void HandleSwitchOn()
        {
            if (switchUI.style.display == DisplayStyle.Flex)
            {
                switchUI.style.display = DisplayStyle.None;

                if (currentIndex != WeaponSprite_index)
                {
                    OnWeaponSwitch?.Invoke(WeaponSprite_index);
                    OnSwitchInput?.Invoke();
                }

                currentIndex = WeaponSprite_index;
            }
            else
            {
                switchUI.style.display = DisplayStyle.Flex;
            }


        }
    }
}
