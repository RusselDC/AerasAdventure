using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAI : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool movingRight = true;
    [SerializeField] Transform groundDetect;
    [SerializeField] Transform Rwall;
    [SerializeField] float distance;

    [SerializeField] Transform player;
    [SerializeField] float agroRange;
    Rigidbody2D rb;

    [SerializeField] float damage;
    [SerializeField]EnemyAttack enemy;

    // Update is called once per frame

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
        float distance = Vector2.Distance(transform.position, player.position);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down, distance);
        RaycastHit2D wallcheckR = Physics2D.Raycast(groundDetect.position, Vector2.left, 1);
        if(distance<agroRange)
        {   
            Chase();
        }
       
        if(groundInfo.collider == false)
        {
            enCheck();
        }
        if(wallcheckR.collider == true)
        {   
            if(wallcheckR.collider.tag == "Enemy" || wallcheckR.collider.tag == "Player"){
                  
            }else{
                wallCheck();
                Debug.Log(wallcheckR.collider.name);
            }
        }
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
    }
    void Chase()
    {
        /*if(transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(speed,player.position.y * Time.deltaTime);
        }else{
            rb.velocity = new Vector2(-speed, player.position.y * Time.deltaTime);
        }*/
        enemy.shoot();
    }
    void wallCheck()
    {   
        Debug.Log("wall found!");
        if(movingRight == true)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            movingRight = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }
    }
    void enCheck()
    {   
        Debug.Log("no found!");
        if(movingRight == true)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            movingRight = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }
    }


    void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, agroRange);
	}
    
    
}
