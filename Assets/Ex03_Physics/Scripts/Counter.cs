using UnityEngine;

public class Counter : MonoBehaviour
{
    public int count = 0;
    public bool destructible;

    private void OnTriggerEnter(Collider other)
    {
        count++;
    }

    private void OnTriggerExit(Collider other)
    {
        if (destructible)
        {
        Destroy(other.gameObject);

        }
    }
}
