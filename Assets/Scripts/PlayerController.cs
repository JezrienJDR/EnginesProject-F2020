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

    public Animator animr;

    public void SavePosition()
    {
        PlayerPrefs.SetFloat("xPos", transform.position.x);
        PlayerPrefs.SetFloat("yPos", transform.position.y);
        PlayerPrefs.SetFloat("zPos", transform.position.z);
    }

    public void LoadPosition()
    {
        float x = PlayerPrefs.GetFloat("xPos");
        float y = PlayerPrefs.GetFloat("yPos");
        float z = PlayerPrefs.GetFloat("zPos");

        Vector3 loadedPosition = new Vector3(x, y, z);

        transform.position = loadedPosition;
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        animr = GetComponent<Animator>();

        LoadPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up") | Input.GetKey("w"))
        {
            direction = 'U';

            animr.SetInteger("moveState", 2);

        }

        else if (Input.GetKey("down") | Input.GetKey("s"))
        {
            direction = 'D';


            animr.SetInteger("moveState", 3);
        }

        else if (Input.GetKey("left") | Input.GetKey("a"))
        {
            direction = 'L';

            sr.flipX = false;


            animr.SetInteger("moveState", 1);

        }

        else if (Input.GetKey("right") | Input.GetKey("d"))
        {
            direction = 'R';
            sr.flipX = true;


            animr.SetInteger("moveState", 1);


        }
        else
        {
            direction = 'N';


            animr.SetInteger("moveState", 0);
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
