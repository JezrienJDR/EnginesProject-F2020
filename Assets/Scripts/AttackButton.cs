using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AttackButton : MonoBehaviour
{
    public Move move;
    public int moveID;
    public TMP_Text text;

    public ICharacter self;
    public ICharacter foe;

    private void Start()
    {
        text = GetComponentInChildren<TMP_Text>();

    }

    public void SetMove(Move m)
    {
        Debug.Log(moveID);
        //Debug.Log(moveID + " " + move.moveName);
        move = m;

        if (move == null)
        {
            Debug.Log("MOVE IS NULL");
        }
        if (text == null)
        {
            text = GetComponentInChildren<TMP_Text>();
            Debug.Log("TEXT IS NULL");
        }
        text.SetText(move.moveName);
    }

    public void Use()
    {
        move.ApplyEffects(self, foe);
    }
}
