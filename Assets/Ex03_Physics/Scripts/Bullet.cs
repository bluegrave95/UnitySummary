using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 10f;

    private float deadTime;

    void Start()
    {
        deadTime = Time.time + lifetime;
    }

    void Update()
    {
        if (deadTime < Time.time)
        {
            Destroy(gameObject);
        }
    }
}
