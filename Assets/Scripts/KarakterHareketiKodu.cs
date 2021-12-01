using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterHareketiKodu : MonoBehaviour
{
    // Oyuncunun girdisini almak
    // Karakterimize girdiye bağlı olarak bir güç uygulamak

    public Rigidbody2D rb;
    public float ziplamaGucu;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start fonksiyonu");
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        
        rb.velocity = Vector2.right * h;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * ziplamaGucu);
        }
    }
}
