using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform groundDetect;
    private bool movingRight;
    void Update()
    {   
        transform.Translate(Vector2.right * 5f * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.right, 2f);
        if(groundInfo.collider == true)
        {
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
    }
}
