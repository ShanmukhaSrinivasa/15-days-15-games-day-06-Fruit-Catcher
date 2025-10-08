using UnityEngine;

public class Bomb : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -5.5f)
        {
            Destroy(gameObject);
        }
    }
}
