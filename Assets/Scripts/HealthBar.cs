using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class HealthBar : MonoBehaviour
{

    public Image bar;
    int hp = 100;
    int targetHP;

    float barWidth;
    public RectTransform.Edge edge;

    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Image>();
        if (bar != null)
        {
            Debug.Log("IT'S WORKIIIIIING");

            barWidth = bar.rectTransform.sizeDelta.x;

        }

    }

    public void ChangeHealth(int delta)
    {
        Debug.Log("Applying Damage");
        hp += delta;
        //bar.rectTransform.localScale = new Vector2(hp / 100.0f * barSize.x, barSize.y);
        bar.rectTransform.SetInsetAndSizeFromParentEdge(edge, 0, hp / 100.0f * barWidth);

        //bar.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            //ChangeHealth(-5);
            StartChange(-30);
        }
    }

    IEnumerator SlowChange()
    {
        while (hp != targetHP)
        {
            if (hp > targetHP)
            {
                ChangeHealth(-1);
            }
            else if (hp < targetHP)
            {
                ChangeHealth(1);
            }
            else
            {
                StopCoroutine("SlowChange");
            }
            yield return new WaitForSeconds(0.03f);
        }
    }

    public void StartChange(int delta)
    {
        targetHP = hp + delta;
        StartCoroutine("SlowChange");
    }

}
