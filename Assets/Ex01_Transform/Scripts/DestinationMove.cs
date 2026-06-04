using UnityEngine;
using UnityEngine.InputSystem;

public class DestinationMove : MonoBehaviour
{
    public LayerMask detectLayer;
    public float moveSpeed = 1f;
    public float rotateSpeed = 360f;

    private bool isPressed = false;
    private Vector3 destination;
    private Quaternion toward;

    public void OnPick(InputValue value)
    {
        isPressed = value.isPressed;
        Debug.Log($"마우스 왼쪽 버튼 → {isPressed}");
    }

    private void Update()
    {
        if (isPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hit, 100f, detectLayer))
            {
                Vector3 targetPoint = hit.point;
                targetPoint.y += 1f;

                destination = targetPoint;


                Vector3 direction = destination - transform.position;
                if (Vector3.SqrMagnitude(direction) > 0.001f)
                {
                    toward = Quaternion.LookRotation(direction.normalized, Vector3.up);
                }
            }
        }

        Vector3 position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, toward, rotateSpeed * Time.deltaTime);

        /*transform.position = position;
        transform.rotation = rotation;*/
        transform.SetPositionAndRotation(position, rotation);
    }
}
