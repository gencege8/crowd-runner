using UnityEngine;

public class TrackGen : MonoBehaviour
{
    public GameObject chunkPrefab;
    public Transform player;
    float spawnAheadDistance;
    float lastChunkEndZ;
    public Transform chunkEnd;
    public float calib;
    GameObject spawnedChunk;
    Vector3 spawnedChunkPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastChunkEndZ = chunkEnd.position.z;
        Vector3 spawnPos = new Vector3(6.2407f, 0.12f, lastChunkEndZ);
        spawnedChunk = Instantiate(chunkPrefab, spawnPos, Quaternion.identity);
        spawnedChunkPos = spawnedChunk.transform.Find("ChunkEnd").position;
    }

    // Update is called once per frame
    void Update()
    {
        
        spawnAheadDistance = Vector3.Distance(player.position, spawnedChunkPos);
        if (spawnAheadDistance < calib)
        {
            Vector3 spawnPos =new Vector3 (6.2407f, 0.12f, spawnedChunkPos.z);
            spawnedChunk = Instantiate(chunkPrefab, spawnPos, Quaternion.identity);
            spawnedChunkPos = spawnedChunk.transform.Find("ChunkEnd").position;
        }

    }
}
