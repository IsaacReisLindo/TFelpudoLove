using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigosRaces : MonoBehaviour
{
    public GameObject inimigoPrefab;
    public float intervalo = 3f;
    private bool spawnAtivo = true;
    public float limiteX = 8f;
    public float limiteY = 4f;

    public float velocidade = 3f;

    public float limiteDestruicaoX = -12f;

    void Start()
    {
        InvokeRepeating("GerarInimigo", 0f, intervalo);
    }

    void GerarInimigo()
    {

        // 🔥 ESSENCIAL: só isso foi movido pra cima
        if (!spawnAtivo) return;

        float x = limiteX;
        float y = Random.Range(-limiteY, limiteY);
        Vector2 posicaoAleatoria = new Vector2(x, y);

        GameObject inimigo = Instantiate(inimigoPrefab, posicaoAleatoria, Quaternion.identity);

        StartCoroutine(MoverInimigo(inimigo));
    }

    IEnumerator MoverInimigo(GameObject inimigo)
    {
        while (inimigo != null)
        {
            inimigo.transform.Translate(Vector2.left * velocidade * Time.deltaTime);

            if (inimigo.transform.position.x < limiteDestruicaoX)
            {
                Destroy(inimigo);
                yield break;
            }
            yield return null;
        }
    }

   
    public void PararSpawn()
    {
        spawnAtivo = false;
        CancelInvoke("GerarInimigo");  // <- para totalmente o spawn
    }
}
