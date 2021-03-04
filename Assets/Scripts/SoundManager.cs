using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip PlayerStep, EnemyStep, Attack1, Attack2, DeathSound, Lose, Victory;
    public static AudioSource audioScr;

    private void Start()
    {
        PlayerStep = Resources.Load<AudioClip>("SoundEffects/PlayerStep");
        EnemyStep = Resources.Load<AudioClip>("SoundEffects/EnemyStep");
        Attack1 = Resources.Load<AudioClip>("SoundEffects/Attack1");
        Attack2 = Resources.Load<AudioClip>("SoundEffects/Attack2");
        DeathSound = Resources.Load<AudioClip>("SoundEffects/death1");
        Lose = Resources.Load<AudioClip>("SoundEffects/Lose");
        Victory = Resources.Load<AudioClip>("SoundEffects/Victory");

        audioScr = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "PlayerStep":
                audioScr.PlayOneShot(PlayerStep);
                break;
            case "EnemyStep":
                audioScr.PlayOneShot(EnemyStep);
                break;
            case "EnemyAttack":
                audioScr.PlayOneShot(Attack1);
                break;
            case "PlayerAttack":
                audioScr.PlayOneShot(Attack1);
                break;
            case "Death":
                audioScr.PlayOneShot(DeathSound);
                break;
            case "Lose":
                audioScr.PlayOneShot(Lose);
                break;
            case "Victory":
                audioScr.PlayOneShot(Victory);
                break;
        }
    }

}
