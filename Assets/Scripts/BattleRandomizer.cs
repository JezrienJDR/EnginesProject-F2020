using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleRandomizer : MonoBehaviour
{
    private float timeElapsed;

    public float checkTime;

    public float odds;

    public GameObject player;

    BoxCollider2D area;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;

        area = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        

        if (player.GetComponent<PlayerController>().direction != 'N')
        {
            Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);

            if (playerPos == area.ClosestPoint(player.transform.position))
            {
                timeElapsed += Time.deltaTime;

                if (timeElapsed >= checkTime)
                {
                    timeElapsed = 0;

                    float roll = Random.Range(0.0f, 100.0f);

                    if (roll <= odds)
                    {
                        PlayerPrefs.SetFloat("LastX", player.transform.position.x);
                        PlayerPrefs.SetFloat("LastY", player.transform.position.y);
                        PlayerPrefs.SetFloat("LastZ", player.transform.position.z);

                        SceneTransitions.Instance.StartBattle();
                    }
                }
            }
        }
    }
}
