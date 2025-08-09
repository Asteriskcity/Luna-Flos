using System;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UIElements;
using UnityEngine.AddressableAssets;

namespace Guagua.UI
{
    public class MenuScreen : MonoBehaviour
    {

        [SerializeField] AssetReference scene;

        public static event Action OnGameStart;

        private VideoPlayer opening;

        private VisualElement Menuscreen;

        private Button StartgameButton;
        private Button QuitgameButton;

        private const string Startgamekey = "Menu-start-button";
        private const string Quitgamekey = "Menu-quit-button";

        private void Awake()
        {
            opening = GetComponent<VideoPlayer>();

            SetVisualElement();
            RegisterCallBackEvent();

            opening.loopPointReached += WhenTheVideoStop;
        }

        private void Start()
        {
            Menuscreen.style.display = DisplayStyle.None;
        }

        private void WhenTheVideoStop(VideoPlayer source)
        {
            opening.Stop();
            Menuscreen.style.display = DisplayStyle.Flex;
        }

        private void SetVisualElement()
        {
            Menuscreen = GetComponent<UIDocument>().rootVisualElement;

            StartgameButton = Menuscreen.Q<Button>(Startgamekey);
            QuitgameButton = Menuscreen.Q<Button>(Quitgamekey);
        }

        private void RegisterCallBackEvent()
        {
            StartgameButton.RegisterCallback<ClickEvent>(StartGame);
            QuitgameButton.RegisterCallback<ClickEvent>(QuitGame);
        }

        private void QuitGame(ClickEvent handle)
        {
            Application.Quit();
        }

        private void StartGame(ClickEvent handle)
        {
            OnGameStart?.Invoke();
            Addressables.LoadSceneAsync(scene);
        }
    }
}
