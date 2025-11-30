using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float dano = 10f;

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            VidaPlayer player = col.GetComponent<VidaPlayer>();
            if (player != null) {
                player.ReceberDano(dano);
                }
            }
        }

    }


