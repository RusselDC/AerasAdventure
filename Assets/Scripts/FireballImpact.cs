using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballImpact : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Kill",1.5f);
    }
    void Kill()
    {
        Destroy(gameObject);
    }

    
}
