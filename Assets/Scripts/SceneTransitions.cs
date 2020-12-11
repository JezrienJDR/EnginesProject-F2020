using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    private static SceneTransitions instance;
    [Header("Theme Music")]
    public AudioSource music;
    public AudioClip battle_theme;
    public AudioClip overworld_theme;
    public AudioClip title_music;
    public AudioClip game_over_theme;
    public AudioClip battle_win_theme;
    [Header("Scene Transitions")]
    public Animator anim;
    float t_time = 0.9f;
    
    public static SceneTransitions Instance { get { return instance; } }
    
    IEnumerator SwitchScene(int scene_index)
    {
        anim.SetTrigger("start");
        yield return new WaitForSeconds(t_time);
        SceneManager.LoadScene(scene_index);
    }

    public void PlayGame()
    {
        StartCoroutine(SwitchScene(1));
        music.clip = overworld_theme;
        music.Play();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartBattle()
    {
        StartCoroutine(SwitchScene(2));
        music.clip = battle_theme;
        music.Play();
    }

    public void WinBattle()
    {
        StartCoroutine(SwitchScene(3));
        music.clip = battle_win_theme;
        music.Play();
    }

    public void EndBattle()
    {
        StartCoroutine(SwitchScene(1));
        music.clip = overworld_theme;
        music.Play();
    }

    public void LoseBattle()
    {
        StartCoroutine(SwitchScene(4));
        music.clip = game_over_theme;
        music.Play();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    
}
