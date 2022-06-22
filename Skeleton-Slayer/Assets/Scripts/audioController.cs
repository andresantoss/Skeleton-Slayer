using UnityEngine;

public class audioController : MonoBehaviour
{
    public AudioSource audioSourceMusicaFundo;
    public AudioClip[] musicaFundo;
    public int IndexMusic;
    public AudioClip musicaAtual;

    void Start()
    {
        musicaAtual = musicaFundo[IndexMusic];
        audioSourceMusicaFundo.clip = musicaAtual;
        audioSourceMusicaFundo.loop = true;
        audioSourceMusicaFundo.Play();
    }

    public void changeIndex(int newIndex)
    {
        IndexMusic = newIndex;
        musicaAtual = musicaFundo[IndexMusic];
        audioSourceMusicaFundo.clip = musicaAtual;
        audioSourceMusicaFundo.loop = true;
        audioSourceMusicaFundo.Play();
    }
}
