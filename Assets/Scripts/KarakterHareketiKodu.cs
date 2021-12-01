using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterHareketiKodu : MonoBehaviour
{
    // Oyuncunun girdisini almak
    // Karakterimize girdiye bağlı olarak bir güç uygulamak

    public Rigidbody2D rb;
    
    public float ziplamaGucu;
    public float hareketHizi;
    
    public Animator anim;
    public SpriteRenderer renderer;

    public Transform yerKontrolu;

    public AudioSource jump;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start fonksiyonu");
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(h * hareketHizi, rb.velocity.y);

        if (h != 0)
        {
            if (h > 0)
            {
                renderer.flipX = false;
            }
            else
            {
                renderer.flipX = true;
            }
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics2D.Raycast(yerKontrolu.position, Vector2.down, 0.1f))
            {
                jump.Play();
                anim.SetBool("onAir", true);

                rb.AddForce(Vector2.up * ziplamaGucu);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        anim.SetBool("onAir", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Anahtar")
        {
            Debug.Log("anahtar toplandi!");
            
            Destroy(other.gameObject);
        }
        
        if (other.tag == "Kalp")
        {
            Debug.Log("Kalp toplandi!");
            
            Destroy(other.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(yerKontrolu.position, Vector2.down* 0.1f);
    }
}
