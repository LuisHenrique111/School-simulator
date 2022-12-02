using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Birdder : MonoBehaviour
{
    public static Birdder instance;
    public TextMeshProUGUI textIssuer,textMessage;
    // Start is called before the first frame update
    void Awake() {
        instance = this;
    }
    void Start()
    {
        textIssuer.text = Reader.instance.Issuer();
        
    }
    public void DestroyMessage()
    {
        Destroy(this.gameObject);
    }

}
