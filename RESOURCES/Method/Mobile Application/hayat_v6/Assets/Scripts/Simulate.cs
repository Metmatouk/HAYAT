using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Simulate : MonoBehaviour
{
    [SerializeField]
    private SetBoneAngles boneManager;
    [SerializeField]
    private GameObject tigh;
    [SerializeField]
    private GameObject calf;
    [SerializeField]
    private GameObject foot;
    [SerializeField]
    private double tighLength = 0.0d;
    [SerializeField]
    private double calfLength = 0.0d;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        tigh.transform.rotation = Quaternion.Euler((float)boneManager.getAngles(tighLength, calfLength, (double)foot.transform.position.x, (double)foot.transform.position.y, (double)foot.transform.position.z, (double)tigh.transform.position.x, (double)tigh.transform.position.y, (double)tigh.transform.position.z)[2], 0.0f, (float)boneManager.getAngles(tighLength, calfLength, (double)foot.transform.position.x, (double)foot.transform.position.y, (double)foot.transform.position.z, (double)tigh.transform.position.x, (double)tigh.transform.position.y, (double)tigh.transform.position.z)[0]);
        
        calf.transform.localEulerAngles = new Vector3(0.0f, 0.0f, (float)boneManager.getAngles(tighLength, calfLength, (double)foot.transform.position.x, (double)foot.transform.position.y, (double)foot.transform.position.z, (double)tigh.transform.position.x, (double)tigh.transform.position.y, (double)tigh.transform.position.z)[1]);
        float y = calf.transform.eulerAngles.y;
        float z = calf.transform.eulerAngles.z;
        //print(z);
        //calf.transform.eulerAngles = new Vector3((float)boneManager.getAngles(tighLength, calfLength, (double)foot.transform.position.x, (double)foot.transform.position.y, (double)foot.transform.position.z, (double)tigh.transform.position.x, (double)tigh.transform.position.y, (double)tigh.transform.position.z)[3], y, z);
        /*if(tigh.transform.position.x - foot.transform.position.x > 0) {
            tigh.transform.localEulerAngles = new Vector3(calf.transform.localEulerAngles.x, calf.transform.localEulerAngles.y, Math.Abs(calf.transform.localEulerAngles.z));
        }*/
    }
}
