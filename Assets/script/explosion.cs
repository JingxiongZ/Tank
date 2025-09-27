using UnityEngine;

public class explosion : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.167f); // Destroy the explosion after 1 second
    }

    void Update()
    {

    }
}
