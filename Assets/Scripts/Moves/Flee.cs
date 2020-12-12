using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Flee", menuName = "ScriptableObjects/Flee", order = 1)]
public class Flee : Move
{
    public override void ApplyEffects(ICharacter self, ICharacter foe)
    {
        Debug.Log("Fleeing!");


        FindObjectOfType<BattleController>().Flee();
    }
    
}
