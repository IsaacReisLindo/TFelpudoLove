using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject painelTutorial; // arraste o painel do tutorial aqui

    public void Jogar()
    {
        SceneManager.LoadScene("SampleScene"); // coloque o nome da cena do jogo
    }

    public void AbrirTutorial()
    {
        painelTutorial.SetActive(true);
    }

    public void FecharTutorial()
    {
        painelTutorial.SetActive(false);
    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("Saindo...");
    }
}
