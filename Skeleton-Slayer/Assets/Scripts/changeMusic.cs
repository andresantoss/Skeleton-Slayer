using UnityEngine;

public class changeMusic : MonoBehaviour
{
    public int newIndex;
    public GameObject door;
    public GameObject door2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            door.SetActive(true);
            door2.SetActive(true);
            FindObjectOfType<audioController>().changeIndex(newIndex);
        }
    }
}
