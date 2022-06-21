using UnityEngine;

public class Prologue : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))

        {
            //Destroy(gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Mapa");
        }
    }
    public void LoadNewScene()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("Mapa");
        //Destroy(gameObject);
    }
}