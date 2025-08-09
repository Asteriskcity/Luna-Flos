using Cinemachine;
using Guagua.Nia;
using UnityEngine;


public class CameraManager : MonoBehaviour
{

    private CinemachineVirtualCamera PlayerCM;

    private GameObject Player;

    private void Awake()
    {
        PlayerCM = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        Player = FindObjectOfType<Player>().gameObject;

        PlayerCM.Follow = Player.transform;
    }
}

