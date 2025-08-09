using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]

public class PlayerData : ScriptableObject
{
    [Header("MoveState")]
    public float movespeed = 10f;


    [Header("JumpState")]
    public bool DoubleJump = false;
    public float jumpforce = 10f;
    public float coyoteTime = 0.2f;          //郊狼時間
    public float VariableJumpHeight = 0.3f;  //輕點跳躍的幅度


    [Header("DashState")]
    public float DashPower = 10f;
    public float DashTime = 1f;
    public float DashCD = 0.5f;

    [Header("Combat")]
    public float StunTime = 0.5f;
    public float IFrameTime = 1f;


    [Header("Particles")]
    public GameObject LandDust;
    public GameObject MoveDust;


}
