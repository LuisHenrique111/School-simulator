using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarouselMenu : MonoBehaviour
{
    public GameObject scrollbar;
    float scrollPos = 0;
    float[] pos;
 




    void Update() { 
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++) {
            pos[i] = distance * i;
        }
        if (Input.GetMouseButton(0)){
            scrollPos = scrollbar.GetComponent<Scrollbar>().value;
        } else {
            for (int i = 0; i< pos.Length; i++) {
                if(scrollPos < pos [i] + (distance/2) && scrollPos > pos[i] - (distance/2)) {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (scrollPos < pos[i] + (distance / 2) && scrollPos > pos[i] - (distance / 2))
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1.2f, 1.2f), 0.1f);


                for (int a = 0; a < pos.Length; a++)
                {
                    transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.7f, 0.7f), 0.1f);
                }
            }
        }
    }
    
}
