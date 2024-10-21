using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteranceButtonOnclickScript : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private bool activation;
    [SerializeField]
    private GameObject instance;
    [SerializeField]
    private bool needInstance = false;
    [SerializeField]
    private bool continiousControl = false;
    [SerializeField]
    private bool bgControl = false;
    [SerializeField]
    private GameObject bg = null;
    [SerializeField]
    private bool array;
    [SerializeField]
    private GameObject[] gameObjectArray = null;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonOnClick() {
        if(array) {
            for(int i = 0; i < gameObjectArray.Length; i++) {
                if(instance != gameObjectArray[i]) {
                    gameObjectArray[i].SetActive(!activation);
                }
            }
        }
        target.SetActive(activation);
        if(needInstance) {
            instance.SetActive(!activation);
        }
        if(continiousControl) {
            activation = !activation;
        }
        if(bg != null) {
            bg.SetActive(!bgControl);
        }
    }
}
