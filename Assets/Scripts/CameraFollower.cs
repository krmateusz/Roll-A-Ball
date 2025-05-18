using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform cameraPosition;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
