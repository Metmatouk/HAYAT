using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FootAngleController : MonoBehaviour
{
    [SerializeField]
    private Transform arrow = null;
    [SerializeField]
    private float samenessLimit = 0.0f;
    [SerializeField]
    private GameObject startControl;
    [SerializeField]
    SmoothRotator rotator;
    [SerializeField]
    private float limit;
    [SerializeField]
    private float addCount;
    [SerializeField]
    private bool isClicked = false;

    public int x;
    public int y;
    public int z;

    private float timer;
    private string commingData = "";
    private string[] inputArrayString = null;
    private int[] inputArray = null;
    private int[] rotationMemory = null;
    int a, b, c;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GetScores());
        inputArray = new int[3];
        inputArrayString = new string[3];
        rotationMemory = new int[3];
        rotationMemory[0] = -361;
        rotationMemory[1] = -361;
        rotationMemory[2] = -361;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(startControl.activeSelf) {
            timer += Time.deltaTime;
            if(timer > 0.20) {
                StartCoroutine(GetScores());
                timer = 0.0f;            
                inputArrayString = commingData.Split(",");
                for(int i = 0; i < inputArrayString.Length; i++) {
                    try {
                        inputArray[i] = Int32.Parse(inputArrayString[i]);
                        
                        if(rotationMemory[i] == -361 || Math.Abs(mod(rotationMemory[i], 360) - mod(inputArray[i], 360)) <= samenessLimit) {
                            rotationMemory[i] = inputArray[i];
                        }
                    }
                    catch(FormatException e) {
                        print(e.Message);
                    }
                }
            }
            if(!isClicked) {
                arrow.localEulerAngles = new Vector3(rotationMemory[2], 180.0f, rotationMemory[1]);
            }
            else {
                arrow.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMemory[1]);
                print(rotationMemory[1] + "++++++++++" + inputArray[1]);
            }
            //print(mod(-400, 360));
        }
    }

    int mod(int number, int Base) {
        return number >= 0 ? (number - Base <= 0 ? number : mod(number - Base, Base)) : number/*(number + Base >= 0 ? number + Base : mod(number + Base, Base))*/;
    }

    IEnumerator GetScores()
    {
        UnityWebRequest hs_get = UnityWebRequest.Get("http://160.20.109.2/getIMU.php");
        yield return hs_get.SendWebRequest();
        if (hs_get.error != null)
            Debug.Log("There was an error getting the high score: "
                    + hs_get.error);
        else
        {
            string dataText = hs_get.downloadHandler.text;
            commingData = dataText;
        }
    }
}
