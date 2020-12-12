using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBattle : MonoBehaviour
{
    public void BackToOverWorld
        ()
    {
        SceneTransitions.Instance.EndBattle();
    }
}
