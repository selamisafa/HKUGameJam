using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KalpSayisiKodu : MonoBehaviour
{
    public Text kalpSayisi;
    
    // Start is called before the first frame update
    void Start()
    {
        kalpSayisi.text = PlayerPrefs.GetInt("kalp", 0) + " kalp topladın!";
        
        PlayerPrefs.DeleteKey("kalp");
    }

}
