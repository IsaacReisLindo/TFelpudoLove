using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFinal : MonoBehaviour
{
    public void Reiniciar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuInicial"); // nome da cena do menu
    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("Saindo do jogo...");
    }
}
