using System.Collections;
using System.Collections.Generic;

public class SpellInfo
{

    private ElementType[] elements = new ElementType[6];

    public bool isFull { get; private set; } = false;

    public SpellInfo()
    {
        for(int i = 0; i < elements.Length; ++i)
        {
            elements[i] = ElementType.NONE;
        }
    }

    public ElementType GetFirst()
    {
        return elements[0];
    }
    public ElementType GetSecond()
    {
        return elements[1];
    }

    public ElementType[] GetLeftovers()
    {
        ElementType[] ets = new ElementType[4];
        ets[0] = elements[2];
        ets[1] = elements[3];
        ets[2] = elements[4];
        ets[3] = elements[5];
        return ets;
    }

    public void AddElement(ElementType element)
    {
        if (isFull || element == ElementType.NONE)
            return;

        for(int i = 0; i < elements.Length; ++i)
        {
            if(elements[i] == ElementType.NONE)
            {
                elements[i] = element;

                //is full now
                if(i == elements.Length - 1)
                {
                    isFull = true;
                }
                return;
            }
        }
        isFull = true;
    }


    public List<ElementType> ReclaimElements()
    {
        List<ElementType> es = new List<ElementType>();
        foreach(ElementType et in elements)
        {
            if(et != ElementType.NONE)
            {
                es.Add(et);
            }
        }
        return es;
    }
}
