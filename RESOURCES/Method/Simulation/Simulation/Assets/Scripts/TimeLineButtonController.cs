using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLineButtonController : MonoBehaviour
{
    [SerializeField]
    private GameObject textArea;
    [SerializeField]
    private RectTransform index;
    [SerializeField]
    private GameObject loadingArea;

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
        index.anchoredPosition = new Vector2(-39f, index.anchoredPosition.y);
        yield return new WaitForSeconds(1.4f);
        loadingArea.SetActive(false);
        textArea.SetActive(true);
        result = true;
    }
}
