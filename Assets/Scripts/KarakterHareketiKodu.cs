using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public bool haveWrench = false;

    public List<GameObject> kalpler;

    public Sprite doluKalp;
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
        if (other.gameObject.tag == "KirilabilenPlatform")
        {
            if (!haveWrench)
            {
                other.gameObject.GetComponent<HingeJoint2D>().useLimits = false;
            }
        }
        
        anim.SetBool("onAir", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Anahtar")
        {
            Debug.Log("anahtar toplandi!");
            other.GetComponent<AnahtarKapiKodu>().KapiyiAc();
            
            Destroy(other.gameObject);
        }
        
        if (other.tag == "Kalp")
        {
            Debug.Log("Kalp toplandi!");

            if (kalpler.Count > 0)
            {
                kalpler[0].GetComponent<Image>().sprite = doluKalp;
                kalpler.RemoveAt(0);
            }
            
            PlayerPrefs.SetInt("kalp", PlayerPrefs.GetInt("kalp", 0) + 1);
            
            Destroy(other.gameObject);
        }
        
        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (other.tag == "IngilizAnahtari")
        {
            Debug.Log("Ingiliz anahtari toplandi!");

            haveWrench = true;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Lav"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(yerKontrolu.position, Vector2.down* 0.1f);
    }
}
