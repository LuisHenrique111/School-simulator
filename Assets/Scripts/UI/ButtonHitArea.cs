using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHitArea : MonoBehaviour
{
    //public GameObject constPanel;
    
    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }

    public void Enter()
    {
        LeanTween.scale(this.gameObject, (this.transform.localScale*1.05f), 0.1f).setEase(LeanTweenType.easeInOutSine);
    }

    public void Exit()
    {
        LeanTween.scale(this.gameObject, (this.transform.localScale / 1.05f), 0.1f).setEase(LeanTweenType.easeInOutSine);

    }

    /*private void Update()
    {
        if (constPanel.transform.position.y <= (-607))
        {
            this.GetComponent<Button>().interactable = false;
        }
    }*/
}
