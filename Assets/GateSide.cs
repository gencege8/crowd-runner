using UnityEngine;

public class GateSide : MonoBehaviour
{
    public int amount;
    public CrowdManager crwdManager;
    public GateType type;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            crwdManager.ApplyGateEffect(type, amount);
        }
    }
}
