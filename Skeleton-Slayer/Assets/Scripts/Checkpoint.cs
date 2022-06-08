using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public PlayerController thePlayer;


    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    public void CheckpointOn()
    {
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
        foreach (Checkpoint cp in checkpoints)
        {
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            thePlayer.SetSpawnPoint(transform);
            CheckpointOn();
        }
    }


}
