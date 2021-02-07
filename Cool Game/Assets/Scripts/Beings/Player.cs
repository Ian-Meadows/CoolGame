using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Being
{

    float speed = 10;

    protected override void Init()
    {
        
    }

    protected override void Move()
    {
        float actualSpeed = speed * Time.deltaTime;

        Vector3 dir = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            dir += Vector3.up * actualSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir += Vector3.down * actualSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            dir += Vector3.left * actualSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir += Vector3.right * actualSpeed;
        }

        //TODO: Add knockback?
        //TODO: fix gliding
        if(dir != Vector3.zero)
        {
            MoveTo(dir + transform.position);
        }

    }

}
