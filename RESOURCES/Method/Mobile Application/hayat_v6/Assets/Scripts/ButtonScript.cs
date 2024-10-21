using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private GameObject textArea;
    [SerializeField]
    private GameObject loadingArea;
    [SerializeField]
    private GameObject instance;

    public bool result;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonOnClick() {
        StartCoroutine(yess());
    }

    public IEnumerator yess() {
        loadingArea.SetActive(true);
        yield return new WaitForSeconds(2);
        loadingArea.SetActive(false);
        textArea.SetActive(true);
        result = true;
    }
}
