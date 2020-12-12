using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public char direction = 'L';

    SpriteRenderer sr;

    [SerializeField]
    float speed = 1;

    public Animator animr;

    public void SavePosition()
    {
        PlayerPrefs.SetFloat("SavedX", transform.position.x);
        PlayerPrefs.SetFloat("SavedY", transform.position.y);
        PlayerPrefs.SetFloat("SavedZ", transform.position.z);
    }


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        animr = GetComponent<Animator>();

        int lastOrSaved = PlayerPrefs.GetInt("LastOrSaved");

        if (lastOrSaved == 0)
        {
            float x = PlayerPrefs.GetFloat("LastX");
            float y = PlayerPrefs.GetFloat("LastY");
            float z = PlayerPrefs.GetFloat("LastZ");

            Vector3 loadedPosition = new Vector3(x, y, z);

            transform.position = loadedPosition;
        }
        else if(lastOrSaved == 1)
        {
            float x = PlayerPrefs.GetFloat("SavedX");
            float y = PlayerPrefs.GetFloat("SavedY");
            float z = PlayerPrefs.GetFloat("SavedZ");

            Vector3 loadedPosition = new Vector3(x, y, z);

            transform.position = loadedPosition;
        }

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
