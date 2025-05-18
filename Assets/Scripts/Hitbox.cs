using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Hitbox : MonoBehaviour
{
    public AudioSource audiosource;
    private void Start()
    {
        audiosource = GameObject.Find("explosion").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        audiosource.Play();
    }

}
