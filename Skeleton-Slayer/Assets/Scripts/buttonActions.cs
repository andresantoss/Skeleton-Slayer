using UnityEngine;

public class buttonActions : MonoBehaviour
{
    public void ButtonPlayGameOnClick()
    {
        //Debug.Log("Button PlayGame was pressed!");
    }

    [System.Obsolete]
    public void RecarregarLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Prologue");
        UnityEngine.SceneManagement.SceneManager.UnloadScene("Mapa");
        UnityEngine.SceneManagement.SceneManager.UnloadScene("Creditos");
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}
