using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] GameObject key;
    [SerializeField] bool isBoss;
    SimplePlayerController player;

    void Update()
    {
        if(health <= 0f)
        {
            Die();
        }
    }

    public void hurt(float damage)
    {   
        health -= damage;
        Debug.Log(health);   
    }

    void Die()
    {   
        if(health <= 0f)
        {
            if(isBoss)
            {
                Instantiate(key,transform.position, transform.rotation);
                player.GetComponent<SimplePlayerController>();
                player.appleEaten = true;
            }
            Destroy(gameObject);
        }
    }
}
