using UnityEngine;

public class BossAtirar : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform pontoTiro;
    public float intervaloTiro = 2f;

    private Transform player;
    private float tempoProximoTiro;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
            Debug.LogWarning("⚠️ Nenhum Player encontrado!");
        if (pontoTiro == null)
            Debug.LogWarning("⚠️ Nenhum PontoTiro configurado!");
    }

    void Update() {
        if (player == null || pontoTiro == null)
            return;

        tempoProximoTiro -= Time.deltaTime;

        if (tempoProximoTiro <= 0f) {
            Atirar();
            tempoProximoTiro = intervaloTiro;
        }
    }

    void Atirar() {
        GameObject bala = Instantiate(bulletPrefab, pontoTiro.position, Quaternion.identity);
        Vector2 direcao = (player.position - pontoTiro.position).normalized;
        bala.GetComponent<BossBullet>().SetDirection(direcao);

        Debug.Log("💥 Boss atirou!");
    }

    void OnDrawGizmos() {
        if (pontoTiro != null) {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(pontoTiro.position, 0.2f);
        }
    }
}
