using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBuilder : MonoBehaviour
{

    //TODO: add all spell prefabs(36)
    public Spell defaultSpellPrefab;

    private Player player;

    private SpellBuildingPanel sbp;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        sbp = FindObjectOfType<SpellBuildingPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleSpellInputs();
    }

    //may want to move elseware
    private void HandleSpellInputs()
    {
        ElementType e = GetElementToAdd();
        if(e != ElementType.NONE)
        {
            //if player has element and there is room in SpellBuildingPanel
            if(player.GetElementAmount(e) > 0 && sbp.AddElement(e))
            {
                player.RemoveElement(e);
            }
        }

        //clear and reclaim spell(may want to remove)
        if(Input.GetMouseButtonDown(1))
        {
            SpellInfo si = sbp.GetInfo(true);
            //reclaim elements
            player.AddElements(si.ReclaimElements());
        }

        //launch spell
        if(Input.GetMouseButtonDown(0))
        {
            SpellInfo si = sbp.GetInfo(true);
            if(si.GetFirst() != ElementType.NONE)
            {
                BuildSpell(si, player, player.transform.up);
            }
        }
    }

    private ElementType GetElementToAdd()
    {
        //air
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            return ElementType.Air;
        }
        //water
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            return ElementType.Water;
        }
        //earth
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            return ElementType.Earth;
        }
        //fire
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            return ElementType.Fire;
        }
        //light
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            return ElementType.Light;
        }
        //dark
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            return ElementType.Dark;
        }
        return ElementType.NONE;
    }

    private Spell SpawnSpell(Spell prefab, ElementType[] leftovers, Being being, Vector3 direction)
    {
        Spell spell = Instantiate(prefab, being.transform.position + (direction * being.size), Quaternion.identity);
        spell.FinishBuilding(leftovers, direction);
        return spell;
    }


    public Spell BuildSpell(SpellInfo info, Being being, Vector3 direction)
    {
        if (player == null)
            return null;

        ElementType second = info.GetSecond();
        ElementType[] leftovers = info.GetLeftovers();
        switch(info.GetFirst())
        {
            case ElementType.Air:
                return BuildAirSpells(second, leftovers, being, direction);
            case ElementType.Water:
                return BuildWaterSpells(second, leftovers, being, direction);
            case ElementType.Earth:
                return BuildEarthSpells(second, leftovers, being, direction);
            case ElementType.Fire:
                return BuildFireSpells(second, leftovers, being, direction);
            case ElementType.Light:
                return BuildLightSpells(second, leftovers, being, direction);
            case ElementType.Dark:
                return BuildDarkSpells(second, leftovers, being, direction);
            default:
                return BuildDefaultSpell(second, leftovers, being, direction);
        }
    }

    private Spell BuildDefaultSpell(ElementType second, ElementType[] leftovers, Being being, Vector3 direction)
    {
        return SpawnSpell(defaultSpellPrefab, leftovers, being, direction);
    }

    //air
    private Spell BuildAirSpells(ElementType second, ElementType[] leftovers, Being being, Vector3 direction)
    {
        return BuildDefaultSpell(second, leftovers, being, direction);
    }

    //water
    private Spell BuildWaterSpells(ElementType second, ElementType[] leftovers, Being being, Vector3 direction)
    {
        return BuildDefaultSpell(second, leftovers, being, direction);
    }

    //fire
    private Spell BuildFireSpells(ElementType second, ElementType[] leftovers, Being being, Vector3 direction)
    {
        return BuildDefaultSpell(second, leftovers, being, direction);
    }

    //earth
    private Spell BuildEarthSpells(ElementType second, ElementType[] leftovers, Being being, Vector3 direction)
    {
        return BuildDefaultSpell(second, leftovers, being, direction);
    }

    //light
    private Spell BuildLightSpells(ElementType second, ElementType[] leftovers, Being being, Vector3 direction)
    {
        return BuildDefaultSpell(second, leftovers, being, direction);
    }

    //dark
    private Spell BuildDarkSpells(ElementType second, ElementType[] leftovers, Being being, Vector3 direction)
    {
        return BuildDefaultSpell(second, leftovers, being, direction);
    }
}
