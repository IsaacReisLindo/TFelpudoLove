using UnityEngine;

public class PlayerVida : MonoBehaviour
{
    public int vida = 3;

    public void TomarDano(int dano)
    {
        vida -= dano;
        Debug.Log("Player tomou dano, vida: " + vida);

        if (vida <= 0)
        {
            Debug.Log("Player morreu!");
            // aqui pode reiniciar cena, animacao, etc.
        }
    }
}
