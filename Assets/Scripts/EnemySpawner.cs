using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  
    public Transform player;  
    public EnemyLogic enemyLogic;
    public AudioSource audioSource;
    public float spawnRadius = 10f; 
    public float spawnTimer = 2f; 
    private float Timer = 0f;
    void Start()
    {
        audioSource = GameObject.Find("enemyspawn").GetComponent<AudioSource>();
    }

    
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= spawnTimer)
        {
            SpawnEnemy(); 
            Timer = 0f; 
        }
    }

    void SpawnEnemy()
    {      
        Vector3 randomOffset = Random.onUnitSphere * spawnRadius;
        randomOffset.y = 0; 
        Vector3 spawnPosition = player.position + randomOffset;
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        audioSource.Play();
    }
}
