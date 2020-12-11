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
                    SceneTransitions.Instance.StartBattle();
                }
            }
        }
    }
}
