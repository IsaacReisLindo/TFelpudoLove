using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public Transform healthBar;         //Barra
    public GameObject healthBarObject; //Pai das Barras
    private Vector3 healthBarScale;      //Escala da Barra
    private float healthPercent;      //Porcentagem de vida
    public int health = 10;              //Vida total


    void Start() {
        healthBarScale = healthBar.localScale;
        healthPercent = healthBarScale.x / health;

    }

    // Update is called once per frame
    void Update() {

    }

    void UpdateHealthBar() {
        healthBarScale.x = healthPercent * health;
        healthBar.localScale = healthBarScale;



    }
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("bala")) {
            TakeDamage(5);
            Destroy(col.gameObject);


            if (health <= 0) {
                GameManagerRaces.instance.InimigoMorto();
                Destroy(healthBarObject);
                Destroy(this.gameObject);
            }

        }

        if (col.CompareTag("Boss")) {
            BossVida boss = col.GetComponent<BossVida>();
            if (boss != null) {
                boss.TomarDano(2); // Dano fixo de exemplo

            }

            Destroy(gameObject); // destrói o tiro
        }
    }
    public void TakeDamage(int damage) {
        health -= damage;
        UpdateHealthBar();
    }
    public void InimigoMorto()
    {
        // Implemente aqui a lógica desejada ao matar um inimigo, por exemplo:
        //AddScore(10); // Exemplo: adiciona pontos ao score
    }

}

















