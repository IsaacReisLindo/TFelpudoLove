using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    public int dano = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerJump>()?.TomarDano(dano);
        }
    }
}
