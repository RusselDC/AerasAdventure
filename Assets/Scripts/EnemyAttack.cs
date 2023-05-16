using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletPos;

    public float Timer;
    [SerializeField] float limit;


    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
    }

    public void shoot()
    {
        if(Timer>limit)
        {
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
            Timer = 0;
        }
    }

 
}
