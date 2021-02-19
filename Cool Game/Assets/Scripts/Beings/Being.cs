using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Being : MonoBehaviour
{

    private Rigidbody2D rb;

    public int health { get; protected set; }
    public int maxHealth { get; protected set; }

    public float size { get; protected set; }

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
        if(health <= 0)
        {
            Dying();
            Destroy(gameObject);
        }
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

    protected virtual void Dying()
    {

    }

    protected virtual void DamageTaken()
    {

    }

    protected virtual void Healed()
    {

    }

    public void Heal(int amount)
    {
        health += amount;
        if(health > maxHealth)
        {
            health = maxHealth;
        }

        //TODO: maybe check for over redundancies
        Healed();
    }
    public void Damage(int amount)
    {
        health -= amount;

        DamageTaken();
    }
}
