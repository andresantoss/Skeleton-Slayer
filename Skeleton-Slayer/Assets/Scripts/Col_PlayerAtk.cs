using UnityEngine;
using TMPro;

public class Col_PlayerAtk : MonoBehaviour
{
    public Combo combo;
    public string type_Atk;
    int comboStep;
    public int Maxdamage;
    public TextMeshProUGUI dmgText;

    private void OnEnable()
    {
        comboStep = combo.comboStep;
    }

    private void OnTriggerEnter(Collider Enemy)
    {
        int damage = Random.Range(1, Maxdamage);
        if (Enemy.gameObject.tag == "HitBox_Enemy")
        {
            dmgText.text = type_Atk + " + " + comboStep;
            dmgText.gameObject.SetActive(true);
            //Enemy.gameObject.SendMessage("OnHurtEnemy", damage);
            Enemy.gameObject.GetComponent<HealthEnemyManager>().HurtEnemy(damage);
        }
    }

}
