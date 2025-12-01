using UnityEngine;

public class NpcCheck : MonoBehaviour
{
    public GameObject gameWonUI; // a tela de vitória

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController p = collision.GetComponent<PlayerController>();

            if (p != null && p.pena > 0)
            {
                // ele tem a pena
                gameWonUI.SetActive(true);
                Time.timeScale = 0f; // pause romântico
            }
        }
    }
}
