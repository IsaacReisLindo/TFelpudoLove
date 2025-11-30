using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public Image Barra;
    public float vidaMax = 100f;
    public float vidaAtual;
    public SpriteRenderer spritePlayer;
    public float duracaoPiscar = 0.2f;
    void Start()
    {
        vidaAtual = vidaMax;
        

        if (spritePlayer == null)
            spritePlayer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void ReceberDano(float dano = 10)
    {
        vidaAtual -= dano;
        Barra.fillAmount = vidaAtual / vidaMax;
        StartCoroutine(Piscar());
        if (vidaAtual <= 0)
        {
            UIManager.instance.MostrarGameOver();
            Destroy(this.gameObject);
        }
    }

    System.Collections.IEnumerator Piscar() {
        spritePlayer.color = Color.red;      // muda para vermelho
        yield return new WaitForSeconds(duracaoPiscar);
        spritePlayer.color = Color.white;    // volta para a cor normal
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Limitacao")) {
            ReceberDano();
        }

    }
   
}
