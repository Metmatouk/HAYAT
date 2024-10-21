using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLineController : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject instance;
    [SerializeField]
    private RectTransform timelineIndex;
    [SerializeField]
    public bool controlValue = false;
    [SerializeField]
    private bool controlType = false;
    [SerializeField]
    private TimeLineController messager;
    [Range(0, 16)]
    public float speed;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private TimeLineButtonController tlbc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!controlType && tlbc.result && timelineIndex.anchoredPosition.x > 245.0f) {
            buttonOnClick();
            tlbc.result = false;
        }
        if(timelineIndex.anchoredPosition.x < 922.2053f) {
            if(!controlType && messager.controlValue) {
                timelineIndex.anchoredPosition = new Vector2(timelineIndex.anchoredPosition.x + speed, timelineIndex.anchoredPosition.y);
                anim.speed = 0.75f;
                if(tlbc.result) { 
                    anim.speed = 0.38f;
                    anim.SetBool("Control", true);
                }
            }
            else if(controlType && !controlValue) {
                anim.speed = 0.0f;
            }
        }
        else {
            anim.speed = 0.0f;
        }
    }

    public void buttonOnClick() {
        target.SetActive(true);
        instance.SetActive(false);
        if(!controlType) {
            messager.controlValue = false;
        }
        else {
            controlValue = true;
        }
    }
}
