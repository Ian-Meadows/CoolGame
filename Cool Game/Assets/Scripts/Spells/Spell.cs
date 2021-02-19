using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{


    private Rigidbody2D rb;

    protected int damage = 1;

    protected Vector3 direction;
    protected float lifeTime;
    protected float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(rb == null)
        {
            Debug.LogError("ERROR: spell does not have rigidbody");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void FinishBuilding(ElementType[] elements, Vector3 direction)
    {
        this.direction = direction;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Being being = collision.gameObject.GetComponent<Being>();
        if(being == null)
        {
            //maybe want to check for spell
            Destroy(gameObject);
            return;
        }

        being.Damage(damage);

        Destroy(gameObject);


    }
}
