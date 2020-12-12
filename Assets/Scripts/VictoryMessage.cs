using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryMessage : MonoBehaviour
{
    public TMP_Text message1;
    public TMP_Text message2;

 

    // Start is called before the first frame update
    void Start()
    {
        int playerLevel = PlayerPrefs.GetInt("PlayerLevel");

        if (playerLevel == 1)
        {
            message1.SetText("You have learned a new spell:");
            message2.SetText("Multi-Shot");
        }
        else if (playerLevel == 2)
        {
            message1.SetText("You have learned a new spell:");
            message2.SetText("Magic BEAM!");
        }
        else
        {
            message1.SetText("No spells left to learn!");
            message2.SetText("Your victory is meaningless!");
        }
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
