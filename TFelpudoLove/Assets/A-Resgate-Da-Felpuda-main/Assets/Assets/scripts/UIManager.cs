using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject telaGameOver;
    public GameObject telaVitoria;

    public static UIManager instance;

    void Awake() {
        instance = this;
        telaGameOver.SetActive(false);
        telaVitoria.SetActive(false);
    }

    public void MostrarGameOver() {
        telaGameOver.SetActive(true);
        Time.timeScale = 0f; // pausa o jogo
    }

    public void MostrarVitoria() {
        telaVitoria.SetActive(true);
        Time.timeScale = 0f; // pausa o jogo
    }

    public void ReiniciarCena() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void VoltarMenu(string nomeCenaMenu) {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nomeCenaMenu);
    }
}
