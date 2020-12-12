using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleAttacks : MonoBehaviour
{
    public ParticleSystem FlameBreath;
    public ParticleSystem MagmaBall;

    ICharacter foe;

    AudioSource audio;

    public AudioClip fire;
    public AudioClip boom;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    
    public void FireBreathAttack(ICharacter _foe)
    {
        foe = _foe;
        StartCoroutine("FireBreathSequence");
    }

    public void MagmaBallAttack(ICharacter _foe)
    {
        foe = _foe; 
        StartCoroutine("MagmaBallSequence");
    }

    IEnumerator FireBreathSequence()
    {
        FindObjectOfType<BattleController>().LockInput();

        audio.PlayOneShot(fire);
        FlameBreath.Play();
        yield return new WaitForSeconds(1.5f);
        FlameBreath.Stop();

        yield return new WaitForSeconds(1.5f);
        foe.AffectHealth(-20);
        yield return new WaitForSeconds(2.5f);

        FindObjectOfType<BattleController>().StartTurn();
    }

    IEnumerator MagmaBallSequence()
    {
        FindObjectOfType<BattleController>().LockInput();
     
        MagmaBall.Play();
        yield return new WaitForSeconds(2.3f);
        audio.PlayOneShot(boom);

        yield return new WaitForSeconds(0.7f);
        foe.AffectHealth(-30);
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<BattleController>().StartTurn();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
