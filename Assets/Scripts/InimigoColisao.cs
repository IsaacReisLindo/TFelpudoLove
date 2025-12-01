using UnityEngine;

public class InimigoColisao : MonoBehaviour
{
    public int dano = 1;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // pega posição do contato
            float alturaContato = col.contacts[0].point.y;
            float alturaInimigo = transform.position.y;

            // player bateu por CIMA → mata o inimigo
            if (alturaContato > alturaInimigo + 0.2f)
            {
                Destroy(gameObject);
            }
            else
            {
                // player bateu de lado → leva dano
                col.gameObject.GetComponent<PlayerVida>().TomarDano(dano);
            }
        }
    }
}
