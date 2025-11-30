using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MovingPlayer : MonoBehaviour
{
    public float speed = 5f;
    bool comecou;
    bool acabou;
    Rigidbody2D corpoJogador;
    Vector2 forcaImpulso = new Vector2(0, 150);

    // Sistema de Vida
    public int maxHealth = 9;
    private int currentHealth;
    public Image healthRenderer;
    public Sprite[] healthSprites;

    // Invencibilidade após dano
    private float invincibleTime = 0.5f;
    private float lastDamageTime = -0.5f;

    // SpriteRenderer para efeito de hit
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float hitFlashDuration = 0.1f;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthSprite();
        corpoJogador = GetComponent<Rigidbody2D>();



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

    void Update()
    {
        transform.Translate(
        Input.GetAxis("Horizontal") * speed * Time.deltaTime,
            0f,
            0f);
    }
    void UpdateHealthSprite()
    {
        if (currentHealth > 0 && currentHealth <= healthSprites.Length)
        {
            int index = currentHealth - 1;
            healthRenderer.sprite = healthSprites[index];
        }
        else
        {
            healthRenderer.sprite = null;
        }
    }
    IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(hitFlashDuration);
        spriteRenderer.color = originalColor;
    }
    void Die()
    {
        if (GameManager.instance != null)
            GameManager.instance.GameOver();

        Destroy(healthRenderer.gameObject);
        Destroy(gameObject);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthSprite();

        if (currentHealth == 0)
        {
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Inimigo"))
        {
            if (Time.time - lastDamageTime > invincibleTime)
            {
                TakeDamage(1);
                StartCoroutine(FlashRed());
                lastDamageTime = Time.time;
            }
        }
    }
}