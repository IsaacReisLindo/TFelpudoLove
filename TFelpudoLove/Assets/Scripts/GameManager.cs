using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int score = 0;
    public TMP_Text scoreText;
    public GameObject gameOverPanel;
    public TMP_Text finalScoreTextBad;
    public GameObject gameWonPanel;
    public TMP_Text finalScoreTextGood;
    public float scoreMax;

    // NOVO: Variável para rastrear a Corrotina do efeito Pop
    private Coroutine popEffectCoroutine;

    private Vector3 originalScale;

    void Start()
    {
        // ... (Código Singleton inalterado)

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        gameOverPanel.SetActive(false);
        gameWonPanel.SetActive(false);
        AtualizarScoreUI();

        if (scoreText != null)
            originalScale = scoreText.transform.localScale;
    }

    public void Update()
    {
        if (score >= scoreMax)
        {
            GameWon();
        }
    }

    public void AddScore(int value)
    {
        score += value;
        AtualizarScoreUI();

        if (scoreText != null)
        {
            // CORREÇÃO: Para o pop anterior antes de começar um novo, evitando que vários rodem juntos.
            if (popEffectCoroutine != null)
            {
                StopCoroutine(popEffectCoroutine);
            }
            // CORREÇÃO: Armazena a corrotina para que possamos pará-la depois.
            popEffectCoroutine = StartCoroutine(PopScoreEffect());
        }
    }

    void AtualizarScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Pontuação: " + score;
    }

    // Corrotina inalterada (mas agora é parada de forma segura)
    IEnumerator PopScoreEffect()
    {
        // ... (Corpo da corrotina inalterado)
        float t = 0f;
        float popScale = 1.3f;
        float speed = 6f;

        while (t < 1f)
        {
            t += Time.deltaTime * speed;
            float scale = Mathf.Lerp(1f, popScale, Mathf.Sin(t * Mathf.PI));
            // NOTA: Se o objeto for destruído antes desta linha, o erro acontece, 
            // por isso é VITAL parar a corrotina em GameOver/GameWon.
            scoreText.transform.localScale = originalScale * scale;
            yield return null;
        }

        scoreText.transform.localScale = originalScale;
    }

    // NOVO: Função auxiliar para parar o efeito e restaurar o tamanho
    void StopScoreEffect()
    {
        if (popEffectCoroutine != null)
        {
            StopCoroutine(popEffectCoroutine);
        }
        // Garante que o texto volte ao tamanho normal antes de sumir
        if (scoreText != null)
        {
            scoreText.transform.localScale = originalScale;
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;

        // 1. CHAMA A FUNÇÃO DE PARADA SEGURA
        StopScoreEffect();

        // 2. CORREÇÃO: APENAS DESATIVA o objeto para que outros scripts não disparem o erro.
        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(false);
        }

        gameOverPanel.SetActive(true);
        finalScoreTextBad.text = "Pontuação Final: " + score;
    }

    public void GameWon()
    {
        Time.timeScale = 0;

        // 1. CHAMA A FUNÇÃO DE PARADA SEGURA
        StopScoreEffect();

        // 2. CORREÇÃO: APENAS DESATIVA o objeto.
        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(false);
        }

        gameWonPanel.SetActive(true);
        finalScoreTextGood.text = "Pontuação Final: " + score;
    }

   public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void voltarMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}