using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D Felpudo;
    public Transform posicaoDoPe;
    DialogueSystem dialogueSystem;
    public LayerMask chao;

    private float direcao;
    public float forcaPulo;
    public float velocidade;
    private bool estaNoChao;
    private bool OlharDireita = true;
    public Animator animator;
    public Transform npc;



    private void Awake()
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
    }



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        estaNoChao = Physics2D.OverlapCircle(posicaoDoPe.position, 0.3f, chao);
        animator.SetBool("estaNoChao", estaNoChao);
        animator.SetFloat("velocidadeY", Felpudo.velocity.y);

        direcao = Input.GetAxis("Horizontal");
        Felpudo.velocity = new Vector2(direcao * velocidade, Felpudo.velocity.y);
        animator.SetFloat("velocidade", Mathf.Abs(direcao));
        if ((direcao < 0 && OlharDireita) || (direcao > 0 && !OlharDireita))
        {
            OlharDireita = !OlharDireita;
            transform.Rotate(0f, 180f, 0f);
        }




        if (estaNoChao && Input.GetButtonDown("Jump"))
        {
            Felpudo.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
        }


        if (Mathf.Abs(transform.position.x - npc.position.x) < 5.0f)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogueSystem.Next();
            }
        }

    }
}