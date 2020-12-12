using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ICharacter : MonoBehaviour
{

    public int hp;
    public int hpMax;

    

    Move[] moves;

    public UnityEvent<int> onHealthChange;

    public void AffectHealth(int delta)
    {
        onHealthChange.Invoke(delta);
        hp += delta;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            AffectHealth(-20);
        }
    }
}
