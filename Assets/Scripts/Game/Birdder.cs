using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Birdder : MonoBehaviour
{
    public TextMeshProUGUI textIssuer,textMessage;
    // Start is called before the first frame update
    void Start()
    {
        textIssuer.text = Reader.instance.Issuer();
        textMessage.text = Reader.instance.Message();
    }

}
