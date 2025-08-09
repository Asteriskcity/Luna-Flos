using UnityEngine;


[CreateAssetMenu(fileName = "newEnemiesData", menuName = "Data/Enemy Data/Base Data")]

public class EnemiesData : ScriptableObject
{
    [Header("Idle")]
    public float minIdletime;
    public float maxIdletime;

    [Header("Move")]
    public float movespeed;
    public float Movetime;

    [Header("DetecedPlayer")]
    public float MaxTracingRange;

    [Header("Attack")]
    public float Amount;
    public float Force = 12f;
    public Vector2 Angle = new(2, 2);
    public float CollideDamage;
    public float AtkCooldownTime;

    [Header("Shoot")]
    public GameObject Bullet;
    public float BulletDamage;
    public float BulletSpeed;

    [Header("GetHit")]
    public float stunTime = 0.15f;
}

