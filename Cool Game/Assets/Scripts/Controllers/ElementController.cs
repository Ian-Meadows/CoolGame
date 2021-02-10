using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementController : MonoBehaviour
{

    public Color airColor;
    public Color waterColor;
    public Color earthColor;
    public Color fireColor;
    public Color lightColor;
    public Color darkColor;
    public Color NONEColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Element CreateRandomElement(Vector3 position)
    {
        return null;
    }


    public Color GetColor(ElementType type)
    {
        switch (type)
        {
            case ElementType.Air:
                return airColor;
            case ElementType.Water:
                return waterColor;
            case ElementType.Earth:
                return earthColor;
            case ElementType.Fire:
                return fireColor;
            case ElementType.Light:
                return lightColor;
            case ElementType.Dark:
                return darkColor;
            case ElementType.NONE:
                return NONEColor;
            default:
                return NONEColor;
        }
    }


}
