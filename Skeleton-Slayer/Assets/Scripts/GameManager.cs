using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int currentPotion;
    public TMP_Text potionText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPotion(int potionToAdd)
    {
        currentPotion += potionToAdd;
        potionText.text = "POTIONS OF HEALINGS: " + currentPotion + "!";
    }
}
