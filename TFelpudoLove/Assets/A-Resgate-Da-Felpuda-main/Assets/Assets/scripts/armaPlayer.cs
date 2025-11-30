using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armaPlayer : MonoBehaviour
{
    public GameObject balaProjetil; // vai ser a nossa bala;
    public Transform arma; // vai ser o ponto de saida da bala;
    private bool tiro; // nosso imput do tiro da nossa arma;
    public float forcaDoTiro; // velocidade do tiro;
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        tiro = Input.GetButtonDown("Jump"); // pegando o imput do tiro;
        Atirar();
    }

    private void Atirar() {
        if (tiro == true) {
            GameObject temp = Instantiate(balaProjetil);
            temp.transform.position = arma.position;
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(forcaDoTiro, 0);
            Destroy(temp.gameObject, 3f);

        }
    }
   
}
