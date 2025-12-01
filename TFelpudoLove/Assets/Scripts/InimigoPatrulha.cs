using UnityEngine;

public class InimigoPatrulha : MonoBehaviour
{
    public float velocidade = 2f;
    public Transform pontoA;
    public Transform pontoB;
    private Transform alvoAtual;

    public int danoAoPlayer = 1;
    public float forcaPuloMorte = 8f;

    private Animator anim;
    private Rigidbody2D rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        alvoAtual = pontoA; // começar indo para A
    }

    void Update()
    {
        Patrulhar();
    }

    void Patrulhar()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            alvoAtual.position,
            velocidade * Time.deltaTime
        );

        // Troca o alvo quando chega
        if (Vector2.Distance(transform.position, alvoAtual.position) < 0.1f)
        {
            alvoAtual = (alvoAtual == pontoA) ? pontoB : pontoA;
            Flip();
        }

        anim.SetBool("Walking", true); // ativa animação
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // Colisão com o PLAYER
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            // Verifica se o player caiu em cima (pisou)
            if (col.contacts[0].normal.y < -0.5f)
            {
                // Player matou o inimigo
                Morrer();

                // Player pula pra cima
                Rigidbody2D playerRb = col.collider.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    playerRb.velocity = new Vector2(playerRb.velocity.x, forcaPuloMorte);
                }
            }
            else
            {
                // Player levou dano
                PlayerVida player = col.collider.GetComponent<PlayerVida>();
                if (player != null)
                {
                    player.TomarDano(danoAoPlayer);
                }
            }
        }
    }

    void Morrer()
    {
        anim.SetTrigger("Die");
        velocidade = 0;
        Destroy(gameObject, 0.4f);
    }
}
