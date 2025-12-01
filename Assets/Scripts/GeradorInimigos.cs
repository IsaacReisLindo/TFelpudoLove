using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    // Prefabs dos inimigos (arraste no Inspector!)
    [Header("Inimigos")]
    public GameObject inimigoPrefabNormal; // Antigo inimigoPrefab
    public GameObject inimigoPrefabAlto;    // NOVO: Prefab do inimigo que aparece mais acima

    public float intervalo = 3f;
    // Limites de spawn no cenário
    public float limiteX = 8f;
    public float limiteY = 4f;

    // Configurações de Posição
    public float yNormal = -2.11f;
    [Tooltip("Altura extra na coordenada Y para o inimigo mais alto.")]
    public float yOffsetAlto = 2.5f;

    // Configurações de Velocidade
    public float velocidadeNormal = 3f;
    [Tooltip("Velocidade do inimigo que aparece mais acima.")]
    public float velocidadeAlta = 4.5f; // Exemplo: Inimigo de cima é mais rápido!

    // Limite X para destruir o inimigo ao sair da tela
    public float limiteDestruicaoX = -12f;

    void Start()
    {
        // Começa a gerar inimigos repetidamente
        InvokeRepeating("GerarNovoInimigo", 0f, intervalo);
    }

    // Renomeei para refletir a nova lógica de decisão
    void GerarNovoInimigo()
    {
        // Variáveis que vão armazenar as configs do inimigo escolhido
        GameObject prefabSelecionado;
        float yFinal;
        float velocidadeFinal;

        // Decide a posição e o tipo de inimigo (50% de chance para cada)
        if (Random.Range(0, 2) == 0)
        {
            // === INIMIGO NORMAL (50%) ===
            prefabSelecionado = inimigoPrefabNormal;
            yFinal = yNormal;
            velocidadeFinal = velocidadeNormal;
        }
        else
        {
            // === NOVO INIMIGO ALTO (50%) ===
            prefabSelecionado = inimigoPrefabAlto;
            yFinal = yNormal + yOffsetAlto;
            velocidadeFinal = velocidadeAlta; // Usando a velocidade mais alta
        }

        // 1. Define a posição X (à direita da tela, constante)
        float x = limiteX;
        Vector2 posicaoSpawn = new Vector2(x, yFinal);

        // 2. Instancia o inimigo
        GameObject inimigo = Instantiate(prefabSelecionado, posicaoSpawn, Quaternion.identity);

        // 3. Inicia o movimento, passando a velocidade decidida
        StartCoroutine(MoverInimigo(inimigo, velocidadeFinal));
    }

    // O método agora PRECISA receber a velocidade
    IEnumerator MoverInimigo(GameObject inimigo, float velocidadeDoInimigo)
    {
        while (inimigo != null)
        {
            // Move o inimigo usando a velocidade que foi passada
            inimigo.transform.Translate(Vector2.left * velocidadeDoInimigo * Time.deltaTime);

            // ... (Restante do código de destruição inalterado)
            if (inimigo.transform.position.x < limiteDestruicaoX)
            {
                Destroy(inimigo);
                yield break;
            }
            yield return null;
        }
    }
}