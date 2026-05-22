using UnityEngine;

public class NpcTrigger : MonoBehaviour
{
    public CrowdManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            manager.AddFollower(other.transform);
        }
    }
}
