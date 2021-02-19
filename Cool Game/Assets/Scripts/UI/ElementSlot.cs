using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementSlot : MonoBehaviour
{

    public int SlotNumber;
    private ElementController ec;

    private Image image;

    public ElementType element { get; private set; } = ElementType.NONE;

    // Start is called before the first frame update
    void Start()
    {
        ec = FindObjectOfType<ElementController>();

        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetElement(ElementType e)
    {
        element = e;

        if(e == ElementType.NONE)
        {
            image.color = Color.white;
        }
        else
        {
            image.color = ec.GetColor(e);
        }
    }
}
