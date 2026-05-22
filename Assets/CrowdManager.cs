using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class CrowdManager : MonoBehaviour
{
    List<Transform> followers = new List<Transform>();
    public Transform player;
    public float followSpeed;
    public float spacing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.currentState != GameState.Playing) return;
        /*int i = 0;
        foreach (Transform t in followers)
        {
            if (i == 0)
            {
                Vector3 pos = player.transform.position;
                pos.z -= spacing;
                t.position = Vector3.Lerp(t.position, pos, followSpeed * Time.deltaTime);
            }
            else if (i > 0)
            {
                Vector3 pos = followers[i-1].position;
                pos.z -= spacing;
                t.position = Vector3.Lerp(t.position, pos, followSpeed * Time.deltaTime);
            }
            i++;
        }*/
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
    }
    public void AddFollower(Transform npc)
    {
        followers.Add(npc);
    }
}
