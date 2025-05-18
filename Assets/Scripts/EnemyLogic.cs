using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyLogic : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public AudioSource audioSource;
    void Start()
    {
        audioSource = GameObject.Find("explosion").GetComponent<AudioSource>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    
    void Update()
    {
        agent.SetDestination(player.position);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            audioSource.Play();
        }
    }

}
