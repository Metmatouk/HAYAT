using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PulseManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI pulse;
    [SerializeField]
    private int lowLimit;
    [SerializeField]
    private int highLimit;

    private IEnumerator exam;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 2) {
            pulse.SetText(Random.Range(lowLimit, highLimit).ToString());
            timer = 0.0f;
        }
    }

    void func() {
        //yield return new WaitForSeconds(5);
        print(Random.Range(10, 0));
        //StartCoroutine(func());
    }
}
