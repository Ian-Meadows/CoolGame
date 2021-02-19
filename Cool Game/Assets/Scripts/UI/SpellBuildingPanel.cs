using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBuildingPanel : MonoBehaviour
{

    ElementSlot[] slots;


    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        slots = GetComponentsInChildren<ElementSlot>();
        if(slots.Length > 6)
        {
            Debug.LogError("ERROR: more then 6 slots");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //True if can add. False if can't add
    public bool AddElement(ElementType element)
    {
        if (currentIndex == slots.Length)
            return false;

        slots[currentIndex].SetElement(element);
        currentIndex++;
        return true;
    }


    public SpellInfo GetInfo(bool clearSlots)
    {
        SpellInfo spellInfo = new SpellInfo();

        foreach(ElementSlot slot in slots)
        {
            spellInfo.AddElement(slot.element);
            if(clearSlots)
            {
                slot.SetElement(ElementType.NONE);
            }
        }
        if(clearSlots)
        {
            currentIndex = 0;
        }
        return spellInfo;
    }
}
