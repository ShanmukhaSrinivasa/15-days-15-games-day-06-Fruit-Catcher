using UnityEngine;

public class Apple : MonoBehaviour
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
