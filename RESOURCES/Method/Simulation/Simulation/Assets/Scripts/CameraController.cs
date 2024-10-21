using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform cameraIndex;

    private float xAxis = 0;
    private float yAxis = 0;

    private float timeCount = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) {
            xAxis += 0.1f;
        }
        else if(Input.GetKey(KeyCode.S)) {
            xAxis -= 0.1f;
        }
        if(Input.GetKey(KeyCode.A)) {
            yAxis += 0.1f;
        }
        else if(Input.GetKey(KeyCode.D)) {
            yAxis -= 0.1f;
        }
        Quaternion target = Quaternion.Euler(0f, yAxis, xAxis);
        /*transform.rotation = Quaternion.RotateTowards(transform.rotation, target, turnTime * Time.deltaTime);
        cameraIndex.rotation = Quaternion.Euler(xAxis, yAxis, 0f);*/

        cameraIndex.rotation = Quaternion.Slerp(cameraIndex.rotation, target, timeCount);
        timeCount = timeCount + Time.deltaTime;
    }
}
