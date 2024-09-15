using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource musicAudioSource; //mpusica

    public AudioSource sfxAS; //sonidos


    public float musicVolume = 0.3f;

    public float sfxVolume = 0.7f;



    public static AudioManager instance;

    public void PlaySFX(AudioClip sound)
    {
        sfxAS.PlayOneShot(sound);
    }


    public void SetMusic(AudioClip audioClip)
    {
        musicAudioSource.Stop();
        musicAudioSource.clip = audioClip;
        musicAudioSource.Play();
    }


    public void StopMusic()
    {
        musicAudioSource.Stop();

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //evita que...
        }
        else
        {
            Destroy(gameObject);
        }
    }



    void Start()
    {
        musicAudioSource.volume = musicVolume;
        musicAudioSource.loop = true;


        sfxAS.volume = sfxVolume;
        sfxAS.loop = false;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
