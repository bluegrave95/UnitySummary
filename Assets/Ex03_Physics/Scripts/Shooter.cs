using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    public GameObject prefab;
    [Range(0.1f, 5f)]
    public float delay = 0.5f;
    public float power = 500f;

    private bool isPressed = false;
    private float nextShootTime;
    public void OnPick(InputValue value)
    {
        isPressed = value.isPressed;
    }

    private void Update()
    {
        if (isPressed && nextShootTime < Time.time)
        {
            nextShootTime = Time.time + delay;
            GameObject bullet = Instantiate<GameObject>(prefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * power);
        }
    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
