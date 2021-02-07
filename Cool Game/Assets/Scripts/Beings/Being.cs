using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Being : MonoBehaviour
{

    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Init();
    }

    protected abstract void Init();

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    //Run in fixed update for MoveTo and RotateTo to function properly
    protected abstract void Move();


    //Call this within Move
    protected void MoveTo(Vector2 point)
    {
        rb.MovePosition(point);
    }

    //Call this within Move
    protected void RotateTo(float angle)
    {
        rb.MoveRotation(angle);
    }
}
