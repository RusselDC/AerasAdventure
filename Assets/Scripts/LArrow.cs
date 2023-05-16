using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LArrow : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    ArrowSpawner As;
    [SerializeField] AudioSource sound;
    void Start()
    {
        sound.Play();
            transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
        
        /*if(As.isright)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0,0,-90));
        }
        if(As.isdown)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
        }*/
        
        Invoke("Kill",8f);
    }
    void Update()
    {

        transform.Translate(transform.right * speed * Time.deltaTime);
        
        /*if(As.isright)
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
        if(As.isdown)
        {
            transform.Translate(-transform.up * speed * Time.deltaTime);
        }*/
        
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
