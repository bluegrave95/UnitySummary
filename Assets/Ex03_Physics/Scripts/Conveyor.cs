using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public List<Rigidbody> rigidList = new List<Rigidbody>();
    public float moveSpeed = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (rigidList.Contains(other.attachedRigidbody))
            return;

        rigidList.Add(other.attachedRigidbody);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!rigidList.Contains(other.attachedRigidbody))
            return;

        rigidList.Remove(other.attachedRigidbody);
    }

    private void FixedUpdate()
    {
        foreach(Rigidbody r in rigidList)
        {
            r.MovePosition(r.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
