using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prologue : MonoBehaviour
{

 private void Update()
 {
  if (Input.GetKeyDown(KeyCode.Space))

  {
   Destroy(gameObject);
   UnityEngine.SceneManagement.SceneManager.LoadScene("Mapa1");
  }
 }
 public void LoadNewScene()
 {
  Destroy(gameObject);
  UnityEngine.SceneManagement.SceneManager.LoadScene("Mapa1");

 }
}