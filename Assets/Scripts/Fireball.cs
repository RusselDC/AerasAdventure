using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject Effect;
    public Rigidbody2D rb;
    [SerializeField] public float damage;
    private bool isleft;
    public float countdown = 10f;

    [SerializeField] AudioSource fire;
    


    // Update is called once per frame

    void Start()
    {
        fire.Play();
        if(SimplePlayerController.isRight)
        {
            isleft = false;
            transform.localScale = new Vector2(-transform.localScale.x,transform.localScale.y);
        }
        else{
            isleft = true;
        }

    }

    void Update()
    {   
        if(isleft)
        {
            rb.velocity = -transform.right * speed;
        }
        else{
            rb.velocity = transform.right * speed;
            
        }
        countdown -= Time.deltaTime;
        if(countdown<=0f)
        {
            Kill();
        }
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {       
            if(col.tag == "Enemy")
            {
                EnemyHealth enemy = col.GetComponent<EnemyHealth>();
                if(enemy != null)
                {
                    enemy.hurt(damage);
                }
            }
        Instantiate(Effect, transform.position,transform.rotation);
        Destroy(gameObject);
    }
    void Kill()
    {
        Destroy(gameObject);
    }
}