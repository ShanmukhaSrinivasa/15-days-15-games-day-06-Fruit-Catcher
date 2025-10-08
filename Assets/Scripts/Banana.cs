using UnityEngine;

public class Banana : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -5.5f)
        {
            GameManager.instance.score -= 1;
            Destroy(gameObject);
        }
    }
}
