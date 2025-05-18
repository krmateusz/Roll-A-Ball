using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float sensivityX;
    public float sensivityY;
    private float rotationX;
    private float rotationY;
    public Transform orientation;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensivityX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensivityY;
        rotationY += mouseX;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        orientation.rotation = Quaternion.Euler(0, rotationY, 0);

    }
}
