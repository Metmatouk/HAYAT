using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FootPressureController : MonoBehaviour
{
    [SerializeField]
    private Transform[] transforms = null;
    [SerializeField]
    private float divisionCount = 0.0f;
    [SerializeField]
    private float scaleChangeSpeed = 0.0f;
    [SerializeField]
    private GameObject runControl = null;

	private float timer;
    private string commingData = "";
    private string[] inputArrayString = null;
    private int[] inputArray = null;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GetScores());
        inputArray = new int[5];
        inputArrayString = new string[5];
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(runControl.activeSelf) {
            timer += Time.deltaTime;
            if(timer > 0.20) {
                StartCoroutine(GetScores());
                timer = 0.0f;            
                inputArrayString = commingData.Split(",");
                for(int i = 0; i < inputArrayString.Length; i++) {
                    try {
                        inputArray[i] = Int32.Parse(inputArrayString[i]);
                        Vector3 targetScale = new Vector3(inputArray[i] / divisionCount, inputArray[i] / divisionCount, 1.0f);
                        transforms[i].localScale = Vector3.Lerp(transforms[i].localScale, targetScale, scaleChangeSpeed * Time.deltaTime);
                    }
                    catch(FormatException e) {
                        print(e.Message);
                    }
                }
            }
        }
    }

    IEnumerator GetScores()
    {
        UnityWebRequest hs_get = UnityWebRequest.Get("http://160.20.109.2/getFSR.php");
        yield return hs_get.SendWebRequest();
        if (hs_get.error != null)
            Debug.Log("There was an error getting the high score: "
                    + hs_get.error);
        else
        {
            string dataText = hs_get.downloadHandler.text;
            commingData = dataText;
            //print(dataText);
        }
    }
}
