using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Test1", menuName = "ScriptableObjects/Test1", order = 1)]
public class Test1 : Move
{
    public override void ApplyEffects(ICharacter self, ICharacter foe)
    {
        Debug.Log("Test1, Coinflip");
        FindObjectOfType<BattleController>().CoinFlip();
    }
}
