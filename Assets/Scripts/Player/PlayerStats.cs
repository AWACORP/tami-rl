using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;

    [SerializeField] private int bonusAttack;
    [SerializeField] private int bonusDefense;
    [SerializeField] private int bonusHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth + bonusHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool CheckDeath()
    {
        return health <= 0; 
    }

    void Die()
    {
        GameManager.Instance().TeleportToSpawn();
        health = maxHealth + bonusHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("MonsterWeapon"))
        {
            
            health -= 10;

            Debug.Log($"Dégat pris : {10}, PV Restant : {health}");
            
            if (CheckDeath())
            {
                Die();
            }
        }
    }
}
