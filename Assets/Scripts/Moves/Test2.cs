using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Test2", menuName = "ScriptableObjects/Test2", order = 1)]

public class Test2 : Move
{

    ICharacter _foe;

    public override void ApplyEffects(ICharacter self, ICharacter foe)
    {
        _foe = foe;
        FindObjectOfType<MagicShot>().BeginAttack(this);

        //foe.AffectHealth(-20);
    }

    public void Damage()
    {
        _foe.AffectHealth(-20);
    }
}
