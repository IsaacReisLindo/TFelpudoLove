using UnityEngine;
using System.Collections;

public class BossVida : MonoBehaviour
{
    public int vidaMaxima = 20;
    public int vidaAtual;
    public GameObject efeitoMorte; // opcional (explosão, etc.)
    private SpriteRenderer sr;

    public float tempoPiscar = 0.1f; // tempo de cada piscada
    public Color corDano = Color.red; // cor quando leva dano

    void Start() {
        vidaAtual = vidaMaxima;
        sr = GetComponent<SpriteRenderer>(); // pega o SpriteRenderer do boss
    }

    void OnTriggerEnter2D(Collider2D col) {
        // Se for uma bala
        if (col.CompareTag("bala")) {
            TomarDano(5);          // boss leva dano
            Destroy(col.gameObject); // destrói a bala (igual no armaPlayer)
        }
    }

    public void TomarDano(int dano) {
        vidaAtual -= dano;
        StartCoroutine(Piscar()); // faz o boss piscar

        if (vidaAtual <= 0) {
            Morrer();
        }
    }

    IEnumerator Piscar() {
        Color original = sr.color;
        sr.color = corDano; // muda a cor
        yield return new WaitForSeconds(tempoPiscar); // espera um tempo curto
        sr.color = original; // volta à cor original
    }

    void Morrer() {
        Debug.Log("👑 Boss derrotado!");

        if (efeitoMorte != null)
            Instantiate(efeitoMorte, transform.position, Quaternion.identity);

        Destroy(gameObject);

        UIManager.instance.MostrarVitoria();
    }

}
