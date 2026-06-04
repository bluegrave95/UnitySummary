using UnityEngine;
using UnityEngine.InputSystem;

public class TransformMove : MonoBehaviour
{
    public Vector2 input;
    public float moveSpeed = 1f;    //이동속도
    public float rotateSpeed = 360f;//회전속도

    public bool canRotate = false;  //회전유무

    public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }

    private void Update()
    {
        if (canRotate)
        {
            transform.Rotate(Vector3.up * input.x * rotateSpeed * Time.deltaTime);
            transform.Translate(new Vector3(0f, 0f, input.y) * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector3(input.x, 0f, input.y) * moveSpeed * Time.deltaTime);
        }
    }
}
