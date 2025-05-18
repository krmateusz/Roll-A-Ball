using UnityEngine;
using UnityEngine.Audio;

public class Bullet : MonoBehaviour
{
    public AudioSource audiosource;


    public void Start()
    {
        audiosource = GameObject.Find("enemydeath").GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); 
            Destroy(gameObject);   
            audiosource.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
