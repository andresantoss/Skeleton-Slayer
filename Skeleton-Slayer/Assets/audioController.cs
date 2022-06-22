using UnityEngine;

public class audioController : MonoBehaviour
{
    public AudioSource audioSourceMusicaFundo;
    public AudioClip[] musicaFundo;
    public int IndexMusic;

    void Start()
    {
        AudioClip musicaFundoDessaFase = musicaFundo[IndexMusic];
        audioSourceMusicaFundo.clip = musicaFundoDessaFase;
        audioSourceMusicaFundo.loop = true;
        audioSourceMusicaFundo.Play();
    }

}
