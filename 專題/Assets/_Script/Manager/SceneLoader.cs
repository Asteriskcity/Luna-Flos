using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;



public class SceneLoader : MonoBehaviour
{
    [SerializeField] AssetReference newGameScene;
    [SerializeField] Vector2 RespawnPosition;
    [SerializeField] bool ActivateOnload;

    public static Action<AssetReference, Vector2, bool> OnSceneTranslate;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnSceneTranslate?.Invoke(newGameScene, RespawnPosition, ActivateOnload);
        }
    }
}

