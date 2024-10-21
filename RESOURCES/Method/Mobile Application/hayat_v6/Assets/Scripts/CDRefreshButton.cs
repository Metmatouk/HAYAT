using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CDRefreshButton : MonoBehaviour
{
    [SerializeField]
    private GameObject[] targets;
    [SerializeField]
    private int index = -1;
    [SerializeField]
    private TextMeshProUGUI buttonText;

    private bool clickControl = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(clickControl) {
            StartCoroutine(waitButton());
            clickControl = false;
        }
    }

    public void buttonOnClick() {
        index++;
        targets[index].SetActive(true);
    }

    public void connect() {
        clickControl = true;
    }

    public IEnumerator waitButton() {
        buttonText.SetText("Eşleştiriliyor");
        yield return new WaitForSeconds(2);
        buttonText.SetText("Eşleştirildi");
    }
}
