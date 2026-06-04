using UnityEngine;

public class Sorter : MonoBehaviour
{
    public float power = 300f;
    public string detectTag;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == detectTag)
        {
            other.attachedRigidbody.AddForce(transform.forward * power , ForceMode.VelocityChange);
            //other.attachedRigidbody.AddRelativeForce(Vector3.forward * power , ForceMode.VelocityChange);
        }
    }
}
