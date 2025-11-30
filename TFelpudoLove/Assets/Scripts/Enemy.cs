using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Vida do inimigo
    int health = 30;

    // Partículas de hit e destruição

    public GameObject Destroyparticle;



    // SpriteRenderer para efeito de hit
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float hitFlashDuration = 0.1f;


    // Start is called before the first frame update
    void Start()
    {

        health = 20;







        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }


    }



    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Instantiate(Destroyparticle, transform.position, Quaternion.identity);
            Destroy(gameObject);

            if (GameManager.instance != null)
            {
                GameManager.instance.AddScore(100);
            }
        }
    }

    // Coroutine para piscar vermelho ao ser atingido
    IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(hitFlashDuration);
        spriteRenderer.color = originalColor;
    }

    // Detecta colisões com balas
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            health -= 10;
            if (health < 0) health = 0;

            StartCoroutine(FlashRed());
            Destroy(collision.gameObject);

            
        }
    }
}