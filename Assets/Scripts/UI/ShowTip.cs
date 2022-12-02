using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowTip : MonoBehaviour
{
    public GameObject tip;
    public TextMeshProUGUI text;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       text.text = Reader.instance.GenerateTips();
       
    }
    void OnEnable() {
        anim = tip.GetComponent<Animator>();
        StartCoroutine(s());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator s()
    {
        while(true)
        {
            anim.SetBool("ShowTip",true);
            yield return new WaitForSeconds(10f);
            anim.SetBool("ShowTip",false);
            
            yield return new WaitForSeconds(1f);
            text.text = Reader.instance.GenerateTips();
        }
            
            
            
        
        
        
        
        

        
    }
}
