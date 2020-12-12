using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "ScriptableObjects/Move", order = 1)]
public abstract class Move : ScriptableObject
{
    public string moveName;
    public int moveID;
    public abstract void ApplyEffects(ICharacter self, ICharacter foe);
}
