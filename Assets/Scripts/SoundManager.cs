using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip hitSound, collectSound, touchSound, jumpSound,jungleSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        hitSound = Resources.Load<AudioClip>("hit");
        collectSound = Resources.Load<AudioClip>("coin");
        touchSound = Resources.Load<AudioClip>("touch");
        jumpSound = Resources.Load<AudioClip>("jump");
        jungleSound = Resources.Load<AudioClip>("jungle");
        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "hit":
                audioSrc.PlayOneShot(hitSound);
                break;
            case "coin":
                audioSrc.PlayOneShot(collectSound);
                break;
            case "touch":
                audioSrc.PlayOneShot(touchSound);
                break;
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
                
        }
        
    }
    public void playsoundtouch()
    {
        audioSrc.PlayOneShot(touchSound);
    }

   
}
