using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : Singleton<SFXManager>
{
    public AudioClip switchToArtist;
    public AudioClip switchToCoder;
    public AudioClip switchToComposer;
    public AudioClip jump;
    public AudioClip hack;
    public AudioClip doorSlideUp;
    public AudioClip doorSlideDown;
    public AudioClip cubeAppear;
    public AudioClip composerShoot;
    public AudioClip levelComplete;
    public AudioClip death;
    public AudioClip gravityChange;
    public AudioClip buttonPressed;
    public AudioClip buttonReleased;
    public AudioClip[] enemyShoot;

    AudioSource audioSource;

    public void playSwitchCharacter(int i)
    {
        switch (i) {
            case 0:

                audioSource.PlayOneShot(switchToArtist);
                break;
            case 1:

                audioSource.PlayOneShot(switchToCoder);
                break;
            case 2:

                audioSource.PlayOneShot(switchToComposer);
                break;
            default:
                Debug.LogError("wrong character id");
                break;
        }

    }

    public void playJump()
    {
        audioSource.PlayOneShot(jump);

    }
    public void playHack()
    {
        audioSource.PlayOneShot(hack);

    }
    public void playDoorSlide(bool isUp)
    {
        audioSource.PlayOneShot(isUp?doorSlideUp:doorSlideDown);
    }
    public void playCubeAppear()
    {
        audioSource.PlayOneShot(cubeAppear);

    }
    public void playComposerShoot()
    {
        audioSource.PlayOneShot(composerShoot);

    }
    public void playLevelComplete()
    {
        audioSource.PlayOneShot(levelComplete);
    }
    public void playDeath()
    {
        audioSource.PlayOneShot(levelComplete);
    }
    public void playGravityChange()
    {
        audioSource.PlayOneShot(gravityChange);
    }
    public void playButtonPressed(bool isPressed)
    {
        audioSource.PlayOneShot(isPressed ? buttonPressed : buttonReleased);
    }
    public void playEnemyShoot()
    {
        audioSource.PlayOneShot(enemyShoot[Random.Range(0, enemyShoot.Length)]);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
