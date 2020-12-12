using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FlameBreath", menuName = "ScriptableObjects/FlameBreath", order = 1)]
public class FlameBreath : Move
{
    ICharacter _foe;

    public override void ApplyEffects(ICharacter self, ICharacter foe)
    {
        _foe = foe;
        FindObjectOfType<BubbleAttacks>().FireBreathAttack(foe);


        //foe.AffectHealth(-20);
    }

    public void Damage()
    {
        _foe.AffectHealth(-80);
    }
}
