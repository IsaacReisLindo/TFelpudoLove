using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaCena : MonoBehaviour
{
    public string cenaParaCarregar = "FelpudoRace";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(cenaParaCarregar);
        }
    }
}
