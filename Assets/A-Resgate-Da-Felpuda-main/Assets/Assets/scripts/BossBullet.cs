using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 6f;
    public float lifetime = 5f;
    [Range(1, 25)] public int dano = 25; // facilita testar no Inspector
    private Vector2 direction;

    void Start() {
        Destroy(gameObject, lifetime);
    }

    void Update() {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 dir) {
        direction = dir.normalized;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            VidaPlayer vida = collision.GetComponent<VidaPlayer>();
            if (vida != null) {
                Debug.Log($"💥 Tiro atingiu o Player! Causando {dano} de dano.");
                vida.ReceberDano(dano);
            }

            Destroy(gameObject);
        }
    }
}
