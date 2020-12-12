using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShot : MonoBehaviour
{
    public ParticleSystem SparkleShine;
    public ParticleSystem ChargeRings;
    public ParticleSystem ChargeParticles;
    public ParticleSystem SmokeExplosion;
    public ParticleSystem Cruciburst;
    public ParticleSystem SingleRing;
    public GameObject shot;
    public GameObject beam;

    public AudioClip fire;
    public AudioClip charge;
    public AudioClip impact;
    public AudioClip zap;
    public AudioClip twinkle;
    AudioSource audio;

    public float shotSpeed;

    Vector3 shotPosition;

    Test2 move = null;
    MultiAttack multiMove = null;
    Beam b = null;

    // Start is called before the first frame update
    void Start()
    {
        shot.SetActive(false);
        shotPosition = shot.transform.position;
        audio = GetComponent<AudioSource>();
    }

    public void BeginAttack(Test2 m)
    {
        move = m;
        StartCoroutine("AttackSequence");
    }

    public void BeginMultiAttack(MultiAttack m)
    {
        multiMove = m;
        StartCoroutine("MultiAttackSequence");
    }

    public void BeginBeamAttack(Beam _b)
    {
        b = _b;
        StartCoroutine("BeamAttackSequence");
    }

    IEnumerator AttackSequence()
    {
        FindObjectOfType<BattleController>().LockInput();
        
        audio.PlayOneShot(twinkle);
        SparkleShine.Play();
        yield return new WaitForSeconds(1.0f);
        ChargeParticles.Play();

        audio.PlayOneShot(charge);

        ChargeRings.Play();
        SingleRing.Play();
        yield return new WaitForSeconds(1.8f);
        ChargeRings.Stop();
        ChargeParticles.Stop();
        Cruciburst.Play();

        audio.PlayOneShot(impact);

        yield return new WaitForSeconds(0.3f);
        shot.SetActive(true);

        while (shot.transform.position.x < SmokeExplosion.transform.position.x)
        {
            shot.transform.Translate(new Vector3(shotSpeed, 0, 0));
            yield return new WaitForSeconds(0.01f);
        }
        shot.SetActive(false);
        SmokeExplosion.Play();

        audio.PlayOneShot(fire);

        shot.transform.position = shotPosition;

        yield return new WaitForSeconds(0.3f);

        move.Damage();

        yield return new WaitForSeconds(1.2f);

        FindObjectOfType<BattleController>().EndTurn();
    }

    IEnumerator MultiAttackSequence()
    {
        FindObjectOfType<BattleController>().LockInput();

        audio.PlayOneShot(twinkle);
        SparkleShine.Play();
        yield return new WaitForSeconds(1.0f);
        ChargeParticles.Play();
        audio.PlayOneShot(charge);
        ChargeRings.Play();
        SingleRing.Play();
        yield return new WaitForSeconds(1.8f);
        ChargeRings.Stop();
        ChargeParticles.Stop();

        for (int i = 0; i < 4; i++)
        {

            audio.PlayOneShot(impact);

            Cruciburst.Play();
            yield return new WaitForSeconds(0.3f);
            shot.SetActive(true);

            while (shot.transform.position.x < SmokeExplosion.transform.position.x)
            {
                shot.transform.Translate(new Vector3(shotSpeed, 0, 0));
                yield return new WaitForSeconds(0.01f);
            }
            shot.SetActive(false);
            SmokeExplosion.Play();

            audio.PlayOneShot(fire);
            shot.transform.position = shotPosition;

            yield return new WaitForSeconds(0.3f);
            multiMove.Damage();

        }


        yield return new WaitForSeconds(1.2f);

        FindObjectOfType<BattleController>().EndTurn();
    }

    IEnumerator BeamAttackSequence()
    {
        FindObjectOfType<BattleController>().LockInput();

        audio.PlayOneShot(twinkle);
        SparkleShine.Play();
        yield return new WaitForSeconds(1.0f);
        ChargeParticles.Play();

        audio.PlayOneShot(charge);

        ChargeRings.Play();
        SingleRing.Play();
        yield return new WaitForSeconds(1.8f);
        ChargeRings.Stop();
        ChargeParticles.Stop();
        Cruciburst.Play();
        yield return new WaitForSeconds(0.3f);
        beam.SetActive(true);

        audio.PlayOneShot(zap);
        beam.GetComponent<Animator>().Play(0);
        
        yield return new WaitForSeconds(0.3f);
        SmokeExplosion.Play();

        audio.PlayOneShot(impact);

        yield return new WaitForSeconds(0.8f);
        beam.SetActive(false);


        yield return new WaitForSeconds(0.3f);

        b.Damage();


        yield return new WaitForSeconds(3.0f);


        FindObjectOfType<BattleController>().EndTurn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
