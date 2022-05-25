using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameManager gameManager;
    public void PlayAndre()
    {
        Debug.Log("butão ligado");
        gameManager.Enable();
        Destroy(gameObject);
    }

}
