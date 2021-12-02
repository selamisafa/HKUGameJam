using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnahtarKapiKodu : MonoBehaviour
{
    //Kapıya ulaşmak
    //Kapının açılması
    //Oyuncu kapıya çarparsa/değerse sonraki seviyeye geçmek

    public GameObject kapi;
    public Sprite acikKapi;
    
    public void KapiyiAc()
    {
        kapi.GetComponent<SpriteRenderer>().sprite = acikKapi;

        kapi.GetComponent<BoxCollider2D>().enabled = true;
    }
}
