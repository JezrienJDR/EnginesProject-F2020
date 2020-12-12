using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BattleController : MonoBehaviour
{
    public Move m0;
    public Move m1;
    public Move m2;
    public Move m3;
    public Move m4;

    public Move em1;
    public Move em2;

    public RuntimeAnimatorController enemy1;
    public RuntimeAnimatorController enemy2;

    public AttackButton[] attackButtons;
    enum GameState
    {
        PLAYERTURN,
        ENEMYTURN
    }

    enum InputState
    {
        FREE,
        READTEXT,
        WAITFORANIMATION
    }

    InputState inputState;
    GameState gameState;

    public ICharacter player;
    public ICharacter enemy;
    public GameObject msgBox;
    public TMP_Text msg;

    public GameObject atkBox;

    public ParticleSystem PlayerDeathPops;
    public ParticleSystem PlayerDeathBoom;
    public ParticleSystem EnemyDeathBoom;

    AudioSource audio;

    public AudioClip PlayerBoom;
    public AudioClip PlayerPop;
    public AudioClip EnemyBoom;



    bool battleOver = false;


    public void CoinFlip()
    {
        battleOver = true;

        int flip = Random.Range(0, 2);

        if (flip == 0)
        {
            KillPlayer();
        }
        else if (flip == 1)
        {
            KillEnemy();
        }
    }

    void CheckForDeath()
    {
        if (player.hp <= 0)
        {
            Debug.Log("Player defeated!");
            battleOver = true;
            KillPlayer();
        }
        if (enemy.hp <= 0)
        {
            battleOver = true;
            KillEnemy();
            Debug.Log("Enemy defeated!");
        }
    }

    IEnumerator PlayerDeath()
    {
        LockInput();

        yield return new WaitForSeconds(0.8f);
        PlayerDeathPops.Play();

        audio.PlayOneShot(PlayerPop);
        yield return new WaitForSeconds(0.2f);
        audio.PlayOneShot(PlayerPop);
        yield return new WaitForSeconds(0.2f);
        audio.PlayOneShot(PlayerPop);
        yield return new WaitForSeconds(0.2f);
        audio.PlayOneShot(PlayerPop);
        yield return new WaitForSeconds(0.2f);
        audio.PlayOneShot(PlayerPop);
        yield return new WaitForSeconds(0.2f);

        PlayerDeathPops.Stop();
        yield return new WaitForSeconds(0.4f);
        PlayerDeathBoom.Play();
        player.gameObject.SetActive(false);

        audio.PlayOneShot(PlayerBoom);

        yield return new WaitForSeconds(1.0f);
        ShowText("You are defeated!");
        yield return new WaitForSeconds(0.8f);
        //SceneManager.LoadScene("SampleScene");
        PlayerPrefs.SetInt("LastOrSaved", 1);
        SceneTransitions.Instance.LoseBattle();
    }

    IEnumerator EnemyDeath()
    {
        LockInput();
        enemy.gameObject.SetActive(false);
        EnemyDeathBoom.Play();
        audio.PlayOneShot(EnemyBoom);
        yield return new WaitForSeconds(1.5f);
        ShowText("You are victorious!");

        yield return new WaitForSeconds(0.8f);

        LevelUp();
        PlayerPrefs.SetInt("LastOrSaved", 0);
        SceneTransitions.Instance.WinBattle();
        //UnlockInput();
    }

    public void LockInput()
    {
        inputState = InputState.WAITFORANIMATION;
        atkBox.SetActive(false);
    }

    public void UnlockInput()
    {
        inputState = InputState.FREE;
        atkBox.SetActive(true);
    }

    public void EndTurn()
    {
        CheckForDeath();

        if (battleOver)
        {
            return;
        }

        gameState = GameState.ENEMYTURN;



        int moveChoice = Random.Range(0, 2);


        switch (moveChoice)
        {
            case 0:

                ShowText("Enemy used " + em1.moveName);
                em1.ApplyEffects(enemy, player);
                break;

            case 1:

                em2.ApplyEffects(enemy, player);
                ShowText("Enemy used " + em2.moveName);
                break;
        }
    }

    public void StartTurn()
    {
        CheckForDeath();
        if (battleOver)
        {
            return;
        }
        gameState = GameState.PLAYERTURN;
        UnlockInput();
        HideText();
    }

    public void Flee()
    {
        StartCoroutine("Fleeing");
    }

    IEnumerator Fleeing()
    {
        ShowText("Running awaaaaaaaaay!");
        yield return new WaitForSeconds(1.0f);
        //SceneManager.LoadScene("SampleScene");
        PlayerPrefs.SetInt("LastOrSaved", 1);
        SceneTransitions.Instance.EndBattle();
    }

    void Start()
    {
        ICharacter[] opponents = FindObjectsOfType<ICharacter>();
        player = opponents[1];
        enemy = opponents[0];

        audio = GetComponent<AudioSource>();

        int enemyType = Random.Range(0, 2);

        if (enemyType == 0)
        {
            enemy.GetComponent<Animator>().runtimeAnimatorController = enemy1;
        }
        else
        {
            enemy.GetComponent<Animator>().runtimeAnimatorController = enemy2;
            enemy.gameObject.transform.Translate(new Vector3(0, -1, 0));
        }

        msg = msgBox.GetComponentInChildren<TMP_Text>();

        inputState = InputState.READTEXT;
        gameState = GameState.PLAYERTURN;

        //PlayerPrefs.SetInt("Move1", 4);
        //PlayerPrefs.SetInt("Move2", 1);
        //PlayerPrefs.SetInt("Move3", 2);
        //PlayerPrefs.SetInt("Move4", 0);

        Debug.Log(m0.moveName + m1.moveName + m2.moveName + m3.moveName);

        AssignButtons();

        ShowText("An enemy has appeared!");

    }

    void KillPlayer()
    {
        StartCoroutine("PlayerDeath");
    }

    void KillEnemy()
    {
        StartCoroutine("EnemyDeath");
    }

    void AssignButtons()
    {
        //attackButtons = new AttackButton[4];
        attackButtons = FindObjectsOfType<AttackButton>();

        attackButtons[0].moveID = PlayerPrefs.GetInt("Move1");
        attackButtons[1].moveID = PlayerPrefs.GetInt("Move2");
        attackButtons[2].moveID = PlayerPrefs.GetInt("Move3");
        attackButtons[3].moveID = PlayerPrefs.GetInt("Move4");

        foreach (AttackButton b in attackButtons)
        {
            switch (b.moveID)
            {
                case 0:
                    b.SetMove(m0);
                    break;
                case 1:
                    b.SetMove(m1);
                    break;
                case 2:
                    b.SetMove(m2);
                    break;
                case 3:
                    b.SetMove(m3);
                    break;
                case 4:
                    b.SetMove(m4);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inputState != InputState.WAITFORANIMATION)
        {
            if (inputState == InputState.READTEXT)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
                {
                    HideText();
                }
            }
        }

    }

    public void ShowText(string text)
    {
        msg.SetText(text);
        msgBox.SetActive(true);

        inputState = InputState.READTEXT;
    }

    void HideText()
    {
        msgBox.SetActive(false);
        inputState = InputState.READTEXT;
    }


    // New Game

    public void LevelUp()
    {
        int playerLevel = PlayerPrefs.GetInt("PlayerLevel");
        playerLevel++;
        PlayerPrefs.SetInt("PlayerLevel", playerLevel);

        if(playerLevel == 1)
        {
            PlayerPrefs.SetInt("Move3", 3);
        }
        else if(playerLevel == 2)
        {
            PlayerPrefs.SetInt("Move4", 4);
        }
    }

    public void LoadLocation()
    {
        int lastOrSaved = PlayerPrefs.GetInt("LastOrSaved");

        if(lastOrSaved == 0)
        {
            float x = PlayerPrefs.GetFloat("LastX");
            float y = PlayerPrefs.GetFloat("LastY");
        }
        else
        {
            float x = PlayerPrefs.GetFloat("SavedX");
            float y = PlayerPrefs.GetFloat("SavedY");
        }
    }


}

