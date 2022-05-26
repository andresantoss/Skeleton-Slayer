using UnityEngine;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
    }
    void Update()
    {
    }

    public GameManager gameManager;
    private float t = 2f;
    public void Play()
    {
        Debug.Log("butão ligado");
        gameManager.Enable();
        Destroy(gameObject, t);
    }

}
