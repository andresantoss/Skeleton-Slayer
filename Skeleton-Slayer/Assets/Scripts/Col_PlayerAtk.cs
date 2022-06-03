using UnityEngine;
using TMPro;

public class Col_PlayerAtk : MonoBehaviour
{
    public Combo combo;
    public string type_Atk;
    int comboStep;
    public string dmg;
    public TextMeshProUGUI dmgText;

    private void OnEnable()
    {
        comboStep = combo.comboStep;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HitBox_Enemy")
        {
            dmg = string.Format("{O} + {1}", type_Atk, comboStep);
            dmgText.text = dmg;
            dmgText.gameObject.SetActive(true);
        }
    }
}
