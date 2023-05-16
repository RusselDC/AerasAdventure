using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    [SerializeField] float force;
    [SerializeField] float damage;

    [SerializeField] AudioSource sound;
    void Start()
    {   
        sound.Play();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 dir = player.transform.position - transform.position;
        rb.velocity = new Vector2(dir.x, dir.y).normalized * force;
        gravity();
    }
    void gravity()
    {
        rb.gravityScale = 0.0f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            SimplePlayerController player = col.gameObject.GetComponent<SimplePlayerController>();
            player.Hurt(damage);
        }
        Destroy(gameObject);
    }
}
