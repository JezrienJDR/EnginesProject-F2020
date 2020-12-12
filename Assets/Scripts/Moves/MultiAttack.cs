using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MultiAttack", menuName = "ScriptableObjects/MultiAttack", order = 1)]

public class MultiAttack : Move
{
    ICharacter _foe;

    public override void ApplyEffects(ICharacter self, ICharacter foe)
    {
        _foe = foe;
        FindObjectOfType<MagicShot>().BeginMultiAttack(this);

        //foe.AffectHealth(-20);
    }

    public void Damage()
    {
        _foe.AffectHealth(-15);
    }

}
