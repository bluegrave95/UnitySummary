using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform spawnPosition;
    public float startSpawnTime = 3f;
    public float spawnInterval = 2.5f;
    private float nextSpawnTime;
    private void Start()
    {
        nextSpawnTime = Time.time + startSpawnTime;
    }
    private void Update()
    {
        if(nextSpawnTime < Time.time)
        {
            nextSpawnTime = Time.time + spawnInterval;
            GameObject nextCube = 
                Instantiate<GameObject>(
                    prefabs[Random.Range(0, prefabs.Length)], spawnPosition.position, spawnPosition.rotation, spawnPosition);
        }
    }
}
