using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string[] speechtxt;
    public string actorName;

    public LayerMask playerLayer;
    public float radius;    

    private DialogueControl dc;
    bool onRadius;

    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
    }

    public void FixedUpdate()
    {
        interact();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && onRadius)
        {
            
                dc.Speech(profile, speechtxt, actorName);
            
        }
    }

    public void interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position,radius,playerLayer);
       
        if(hit != null)
        {
            onRadius = true;
           
        }
        else
        {
            onRadius = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
