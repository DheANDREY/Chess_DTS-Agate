using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource sfx;
    public static SoundController instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    public AudioClip BishopSound;
    public void sfxBishop()
    {
        sfx.PlayOneShot(BishopSound);
    }
    public AudioClip DragonSound;
    public void sfxDragon()
    {
        sfx.PlayOneShot(DragonSound);
    }
    public AudioClip KnightSound;
    public void sfxKnight()
    {
        sfx.PlayOneShot(KnightSound);
    }
    public AudioClip RockSound;
    public void sfxRock()
    {
        sfx.PlayOneShot(RockSound);
    }
}
