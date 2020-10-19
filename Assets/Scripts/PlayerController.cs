using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    char direction = 'L';

    SpriteRenderer sr;

    [SerializeField]
    float speed = 1;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up") | Input.GetKey("w"))
        {
            direction = 'U';
        }

        else if (Input.GetKey("down") | Input.GetKey("s"))
        {
            direction = 'D';
        }

        else if (Input.GetKey("left") | Input.GetKey("a"))
        {
            direction = 'L';

            sr.flipX = false;
        }

        else if (Input.GetKey("right") | Input.GetKey("d"))
        {
            direction = 'R';
            sr.flipX = true;
        }

        else
        {
            direction = 'N';
        }

        float moveSpeed = speed * Time.deltaTime;

        switch (direction)
        {
            case 'U':
                {
                    transform.Translate(new Vector3(0, moveSpeed, 0));
                    break;
                }
            case 'D':
                {
                    transform.Translate(new Vector3(0, -moveSpeed, 0));
                    break;
                }
            case 'L':
                {
                    transform.Translate(new Vector3(-moveSpeed, 0, 0));
                    break;
                }
            case 'R':
                {
                    transform.Translate(new Vector3(moveSpeed, 0, 0));
                    break;
                }
            default:
                {
                    break;
                }

        }

    }
}
