using UnityEngine;

public class Arrow : MonoBehaviour
{

    public float lifeTime = 3f; // Arrow exists for 3 seconds

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Destroy arrow after a few seconds
        Destroy(gameObject, lifeTime);
    }

}
