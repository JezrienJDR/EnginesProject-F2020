using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MagmaBall", menuName = "ScriptableObjects/MagmaBall", order = 1)]
public class MagmaBall : Move
{
    ICharacter _foe;

    public override void ApplyEffects(ICharacter self, ICharacter foe)
    {
        _foe = foe;
        FindObjectOfType<BubbleAttacks>().MagmaBallAttack(foe);
        

        Debug.Log("Test1");
        //foe.AffectHealth(-20);
    }

}
