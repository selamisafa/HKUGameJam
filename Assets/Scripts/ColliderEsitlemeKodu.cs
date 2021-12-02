using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEsitlemeKodu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().size = gameObject.GetComponent<SpriteRenderer>().size;
    }
}
