using UnityEngine;
using UnityEngine.Audio;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public float fireRate = 0.5f;
    private float Timer = 0f;
    public AudioSource audioSource;
    public Animator animator;
    public ParticleSystem particleSystem;

    public void Start()
    {
        audioSource = GameObject.Find("gunshot").GetComponent<AudioSource>();
    }

    public void FireBullet ()
    {
        if (Time.timeScale != 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * fireForce, ForceMode.Impulse);
            audioSource.Play();
            animator.SetTrigger("Shoot");
            ParticleSystem particleInstance = Instantiate(particleSystem, firePoint.position, firePoint.rotation);
            Destroy(particleInstance.gameObject, 0.5f);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= Timer)
        {
            FireBullet();
            Timer = Time.time + fireRate;
        }
    }

}
