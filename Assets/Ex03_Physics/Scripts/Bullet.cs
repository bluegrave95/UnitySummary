using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject effect;
    public float lifetime = 10f;
    private float deadTime;

    void Start()
    {
        deadTime = Time.time + lifetime;
    }

    void Update()
    {
        if (deadTime < Time.time)
            Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate<GameObject>(effect, collision.contacts[0].point,
            Quaternion.LookRotation(collision.contacts[0].normal));
    }
}
