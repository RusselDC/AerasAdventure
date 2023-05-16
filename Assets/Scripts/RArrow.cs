using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RArrow : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    ArrowSpawner As;
    [SerializeField] AudioSource sound;
    void Start()
    {
        sound.Play();

        transform.rotation = Quaternion.Euler(new Vector3(0,0,-90));
        

        
        Invoke("Kill",8f);
    }
    void Update()
    {



            transform.Translate(-transform.right * speed * Time.deltaTime);
        

        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {  
        if(col.gameObject.tag == "Player")
        {
            SimplePlayerController player = col.gameObject.GetComponent<SimplePlayerController>();
            if(player != null)
            {
                player.Hurt(damage);
            }
        }
        if(col.gameObject.tag == "Skywall")
        {
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
    void Kill()
    {
        Destroy(gameObject);
    }

}
