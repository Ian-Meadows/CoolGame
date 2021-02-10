using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Needs an image and text as children
 * 
 */

public class ElementAmount : MonoBehaviour
{

    private Text amountText;
    private Image image;

    private ElementController ec;
    private Player player;

    public ElementType elementType;

    // Start is called before the first frame update
    void Start()
    {
        amountText = GetComponentInChildren<Text>();
        image = GetComponentInChildren<Image>();

        ec = FindObjectOfType<ElementController>();
        player = FindObjectOfType<Player>();

        image.color = ec.GetColor(elementType);
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            SetText();
        }
    }

    private void SetText()
    {
        int amount = player.GetElementAmount(elementType);
        amountText.text = amount.ToString();
        if (amount >= 0)
        {
            amountText.color = Color.black;
        }
        else
        {
            amountText.color = Color.red;
        }
    }
}
