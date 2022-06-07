using UnityEngine;
using TMPro;

public class DamageIndicator : MonoBehaviour
{
    public TMP_Text text;
    public float lifetime = 0.6f;
    public float minDist = 2f;
    public float maxDist = 3f;

    private Vector3 iniPos;
    private Vector3 targetPos;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
