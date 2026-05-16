using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerSystem ps = other.GetComponent<playerSystem>();

            if(ps != null)
            {
                ps.Damage();
            }
        }
    }
}