using UnityEngine;

public class Combo : MonoBehaviour
{
    Animator playerAnim;
    public bool comboPossible;
    public int comboStep;
    bool inputSmash;

    public bool m_isAxisInUse = false;
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }
    public void ComboPossible()
    {
        comboPossible = true;
    }
    public void NextAtk()
    {
        if (!inputSmash)
        {
            if (comboStep == 2)
            { playerAnim.Play("NormalAtkB"); }
            if (comboStep == 3)
            { playerAnim.Play("NormalAtkC"); }
        }
        if (inputSmash)
        {
            if (comboStep == 1)
            { playerAnim.Play("SmashAtkC"); }
            if (comboStep == 2)
            { playerAnim.Play("SmashAtkB"); }
            if (comboStep == 3)
            { playerAnim.Play("SmashAtkA"); }
        }
    }
    public void ResetCombo()
    {
        comboPossible = false;
        inputSmash = false;
        comboStep = 0;
    }
    public void NormalAttack()
    {
        if (comboStep == 0)
        {
            playerAnim.Play("NormalAtkA");
            comboStep = 1;
            return;
        }
        else if (comboStep != 0)
        {
            if (comboPossible)
            {
                comboPossible = false;
                comboStep += 1;
            }
        }
    }
    public void SmashAttack()
    {
        if (comboPossible)
        {
            comboPossible = false;
            inputSmash = true;
        }
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { NormalAttack(); }
        if (Input.GetMouseButtonDown(1))
        { SmashAttack(); }
    }
}