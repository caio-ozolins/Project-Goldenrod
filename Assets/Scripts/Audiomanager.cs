using UnityEngine;

// ReSharper disable once IdentifierTypo
public class Audiomanager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource caveSource;
    [SerializeField] private AudioSource drillSource;
    // ReSharper disable once InconsistentNaming
    [SerializeField] private AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip background;
    public AudioClip jump;
    public AudioClip dig;
    public AudioClip cave;
    public AudioClip drillOn;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();

        caveSource.clip = cave;
        caveSource.Play();
    }

    // ReSharper disable once InconsistentNaming
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
