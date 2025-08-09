using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Guagua.CoreSystem
{
    public class PlayerUIManager : CoreComponent
    {

        [SerializeField] private List<Texture2D> Iconsprite = new();

        public float HealthbarLength;

        private VisualElement Healthbar;
        private VisualElement HealthbarTracker;
        private VisualElement HealthbarTrackerBord;
        private VisualElement HealthbarIcon;


        private IStyle healthbarstyle;

        private Stats stats;
        private SwitchManager switchManager;

        private float unit;  //一次的單位


        private const string HealthbarIconkey = "Healthbar-icon";
        private const string HealthbarTrackerkey = "Healthbar-tracker";
        private const string HealthbarTrackerBordkey = "Healthbar-tracker-bord";



        protected override void Awake()
        {
            base.Awake();

            stats = core.GetCoreComponent<Stats>();
            switchManager = core.GetCoreComponent<SwitchManager>();

            SetVisualElement();

            stats.OnValueChange += SetHealthbarLength;
            switchManager.OnWeaponSwitch += HandleIconChange;
        }


        private void Start()
        {
            HealthbarIcon.style.backgroundImage = Iconsprite[0];
            healthbarstyle = HealthbarTracker.style;
            unit = HealthbarLength / stats.HealthPoint.MaxValue;
        }

        private void SetVisualElement()
        {
            Healthbar = GetComponent<UIDocument>().rootVisualElement;
            HealthbarIcon = Healthbar.Q<VisualElement>(HealthbarIconkey);
            HealthbarTracker = Healthbar.Q<VisualElement>(HealthbarTrackerkey);
            HealthbarTrackerBord = Healthbar.Q<VisualElement>(HealthbarTrackerBordkey);
        }


        public void SetHealthbarLength()
        {
            HealthbarLength = unit * stats.HealthPoint.CurrentValue;
            healthbarstyle.width = HealthbarLength;
            HealthbarTrackerBord.style.width = healthbarstyle.width;
        }

        private void HandleIconChange(int index)
        {
            HealthbarIcon.style.backgroundImage = Iconsprite[index];
        }

    }
}
