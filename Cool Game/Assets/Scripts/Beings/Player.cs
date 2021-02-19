using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Being
{

    float speed = 10;

    private Dictionary<ElementType, int> elements;


    protected override void Init()
    {
        InitElements();

        health = 10;
        size = 1;
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

        Rotate();

    }

    private void Rotate()
    {
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookPos = transform.position - lookPos;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;

        //add 90 to fix angling problem
        RotateTo(angle + 90);
    }

    public void AddElement(ElementType type)
    {
        elements[type]++;
    }
    public void AddElements(List<ElementType> types)
    {
        foreach(ElementType element in types)
        {
            elements[element]++;
        }
    }
    public void RemoveElement(ElementType type)
    {
        if(elements[type] > 0)
        {
            elements[type]--;
        }
    }

    public int GetElementAmount(ElementType type)
    {
        return elements[type];
    }


    private void InitElements()
    {
        elements = new Dictionary<ElementType, int>();

        //TODO: Give player a set amount of each element
        elements[ElementType.Air] = 2;
        elements[ElementType.Water] = 2;
        elements[ElementType.Fire] = 2;
        elements[ElementType.Earth] = 2;
        elements[ElementType.Light] = 2;
        elements[ElementType.Dark] = 2;
    }

}
