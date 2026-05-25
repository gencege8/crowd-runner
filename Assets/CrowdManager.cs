using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class CrowdManager : MonoBehaviour
{
    List<Transform> followers = new List<Transform>();
    public Transform player;
    public float followSpeed;
    public float spacing;
    Transform npcToDelete;
    public GameObject npcPrefab;
    int crowdCount=0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.currentState != GameState.Playing) return;
        int i = 0;
        int offset = 0;
        int k = 0;
        foreach (Transform t in followers)
        {
            
            if(i%3 == 0)
            {
                Vector3 pos = player.transform.position;
                pos.z -= spacing + offset;
                t.position = Vector3.Lerp(t.position, pos, followSpeed * Time.deltaTime);
                k++;
            }if(i%3 == 1)
            {
                Vector3 pos = followers[i - (i % 3)].position;
                pos.x -= spacing;
                t.position = Vector3.Lerp(t.position, pos, followSpeed * Time.deltaTime);
                k++;
            }
            if(i%3 == 2)
            {
                Vector3 pos = followers[i - (i % 3)].position;
                pos.x += spacing;
                t.position = Vector3.Lerp(t.position, pos, followSpeed * Time.deltaTime);
                k++;
                offset += 2;
            }
            i++;
        }
        //Debug.Log(crowdCount);
    }
    public void AddFollower(Transform npc)
    {
        followers.Add(npc);
        crowdCount++;
    }
    public void RemoveFollower()
    {
        npcToDelete = followers[followers.Count - 1];
        followers.RemoveAt(followers.Count-1);
        Destroy(npcToDelete.gameObject);
        crowdCount--;
    }
    public void ApplyGateEffect(GateType type, int amount)
    {
        switch(type)
        {
            case GateType.Multiply:
                int crowdCountMult = crowdCount * amount;
                if (crowdCountMult-crowdCount > 20) {
                    for (int i = 0; i < 5; i++)
                    {
                        GameObject newNpc =Instantiate(npcPrefab, player.position, Quaternion.identity);
                        //AddFollower(newNpc.transform);
                        
                    }
                }
                crowdCount = crowdCountMult;
                break;
            case GateType.Subtract:
                amount = Mathf.Min(amount, followers.Count);
                for (int i = 0; i<amount; i++)
                {
                    RemoveFollower();
                }
                break;
        }
    }

}
