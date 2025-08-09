using System;
using Guagua.Nia;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;



public class GameManager : MonoBehaviour
{

    private static GameState currentGameState = GameState.Gameplay;

    private static SceneInstance loadedscene;

    private const string GameManagerKey = "Gamemanager";


    public static event Action<GameState> OnGameStateChanged;
    public static event Action LoadingStarted;
    public static event Action LoadingCompleted;



    private void Awake()
    {
        SceneLoader.OnSceneTranslate += HandleSceneTranslate;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InstantiateGameManager()
    {
        Addressables.InstantiateAsync(GameManagerKey).Completed += Handle =>
        {
            DontDestroyOnLoad(Handle.Result);
        };
    }

    private void HandleSceneTranslate(AssetReference NewScene, Vector2 position, bool isActivate)
    {
        StartCoroutine(LoadScene(NewScene, position, isActivate));
    }

    public IEnumerator LoadScene
        (AssetReference newScene, Vector2 position, bool activateOnload)
    {
        //TODO: 玩家控制禁用

        LoadingStarted?.Invoke();

        yield return new WaitForSecondsRealtime(1f);

        var OperationHandle = Addressables.LoadSceneAsync(newScene, LoadSceneMode.Single, activateOnload);

        while (OperationHandle.Status != AsyncOperationStatus.Succeeded)
        {
            yield return null;
        }

        loadedscene = OperationHandle.Result;
        Player.playerposition.position = position;
    }

    public static void ActivateLoadScene()
    {
        loadedscene.ActivateAsync().completed += _ =>
        {
            loadedscene = default;
            LoadingCompleted?.Invoke();
        };
    }


    public static void ChangeState(GameState state)
    {
        if (state == currentGameState)
            return;

        switch (state)
        {
            case GameState.UI:
                Time.timeScale = 0f;
                break;
            case GameState.Gameplay:
                Time.timeScale = 1f;
                break;
            case GameState.SwitchUI:
                Time.timeScale = 0.1f;
                break;
        }

        currentGameState = state;
        OnGameStateChanged?.Invoke(currentGameState);
    }
}

public enum GameState
{
    Gameplay,
    UI,
    SwitchUI
}

