using UnityEngine;

public class changeMusic0 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            int newIndex = 0;
            FindObjectOfType<audioController>().changeIndex(newIndex);
        }
    }
}
