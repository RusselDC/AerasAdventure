using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aplle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            SimplePlayerController player = col.gameObject.GetComponent<SimplePlayerController>();
            if(player != null)
            {
                player.appleEateed();
            }
            
        }
        Destroy(gameObject);
    }
}
