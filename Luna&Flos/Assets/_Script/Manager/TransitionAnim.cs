using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using Guagua.UI;



public class TransitionAnim : MonoBehaviour
{
    private const string Ussfade = "fade";
    private const string transition = "Transition";

    private VisualElement transitionImage;


    private void Start()
    {
        transitionImage = GetComponent<UIDocument>().rootVisualElement.Q(transition);

        //MenuScreen.OnGameStart += FadeOut;

        GameManager.LoadingStarted += FadeOut;
        GameManager.LoadingCompleted += FadeIn;
    }

    private void FadeOut()
    {
        transitionImage.AddToClassList(Ussfade);
        transitionImage.RegisterCallback<TransitionEndEvent>(FadeOutEnd);
    }

    private void FadeOutEnd(TransitionEndEvent evt)
    {
        transitionImage.UnregisterCallback<TransitionEndEvent>(FadeOutEnd);

        StartCoroutine(ActivateLoadingScene());

        //TODO: 玩家控制啟用
    }

    private void FadeIn()
    {
        transitionImage.RemoveFromClassList(Ussfade);
    }

    private IEnumerator ActivateLoadingScene()
    {
        yield return new WaitForSecondsRealtime(2f);

        GameManager.ActivateLoadScene();
    }
}
