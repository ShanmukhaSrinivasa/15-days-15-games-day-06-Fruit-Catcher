using UnityEngine;

public class Watermelon : MonoBehaviour
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
