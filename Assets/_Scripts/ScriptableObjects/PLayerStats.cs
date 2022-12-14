using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Player_", menuName = "Players/CreatePlayer")]
public class PLayerStats : ScriptableObject
{
    [Header("Health")]
    [Range(0, 10)]
    public float currentHealth = 10;
    [Range(0, 10)]
    public float maxHealth = 10;
    [Range(0, 10)]
    public float deathtime = 1f;

    [Header("Speed")]
    [Range(0, 1000)]
    public float speed = 20f;
    [Range(0, 1000)]
    public float maxSpeed = 20f;

    [Header("Attack")]
    [Range(0, 10)]
    public float attackRange;
    [Range(0, 10)]
    public float attackCoolTime = 1;
    [Range(0, 10)]
    public float maxAttackCooltime = 1;
    [Range(0, 100)]
    public int damage;
    [Header("Audios")]
    public AudioClip moveClip;
    public AudioClip hurtClip;
    public AudioClip deathClip;
    public AudioClip attackClip;
    public AudioClip dodgeRollClip;
    [Header("Player Info")]
    // public GameObject dashParticle;
    public Vector3 position = new Vector3(4.5f, 0.4f, 0);
    public bool isAlive = true;
    public bool isDash = false;
    public GameObject playerObj;
    public LayerMask attackMask;
    public int FinalScore { get; set; }
    public void TakeDamage(float amount)
    {
        if (currentHealth > amount)
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
                MakeDead();
        }
        else MakeDead();
    }
    public void AddHealth(float ammount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += ammount;
            if (currentHealth >= maxHealth)
                currentHealth = maxHealth;
        }
    }
    public void MakeDead()
    {
        currentHealth = 0;
        isAlive = false;
    }
    public void ResetPlayerHealth()
    {
        currentHealth = 10;
        maxHealth = 10;
        isAlive = true;
    }
}
