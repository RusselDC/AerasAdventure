using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] float shootingTime;
    [SerializeField] GameObject arrow;
    private float count;
    void Update()
    {   
        count += Time.deltaTime;
        if(count > shootingTime)
        {
            shoot();
        }
    }
    void shoot()
    {
        count = 0;
        Instantiate(arrow, transform.position, Quaternion.identity);
    }
}   
