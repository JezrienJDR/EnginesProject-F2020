using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Beam", menuName = "ScriptableObjects/Beam", order = 1)]
public class Beam : Move
{
    // Start is called before the first frame update
    ICharacter _foe;

    public override void ApplyEffects(ICharacter self, ICharacter foe)
    {
        _foe = foe;
        FindObjectOfType<MagicShot>().BeginBeamAttack(this);

        //foe.AffectHealth(-20);
    }

    public void Damage()
    {
        _foe.AffectHealth(-80);
    }
}
