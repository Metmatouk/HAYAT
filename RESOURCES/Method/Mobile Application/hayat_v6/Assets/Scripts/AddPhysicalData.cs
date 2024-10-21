using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using System;
using System.Threading.Tasks;
using UnityEngine.Networking;
using Firebase.Firestore;

public class AddPhysicalData : MonoBehaviour
{  
    [SerializeField]
    private TextMeshProUGUI addDoctorNameSurnameField = null;
    [SerializeField]
    private TextMeshProUGUI addDoctorHospitalField = null;
    [SerializeField]
    private TextMeshProUGUI addDoctorBranchField = null;

    [SerializeField]
    private TextMeshProUGUI doctorNameSurnameField = null;
    [SerializeField]
    private TextMeshProUGUI doctorHospitalField = null;
    [SerializeField]
    private TextMeshProUGUI doctorBranchField = null;
    [SerializeField]
    private GameObject doctorElementObject = null;
    [SerializeField]
    private GameObject addDoctorObject = null;

    public void addDoctorOnClick() {
        if(!string.IsNullOrEmpty(addDoctorNameSurnameField.text) && !string.IsNullOrEmpty(addDoctorBranchField.text) && !string.IsNullOrEmpty(addDoctorHospitalField.text)) {
            doctorElementObject.SetActive(true);
            doctorNameSurnameField.text = addDoctorNameSurnameField.text;
            doctorBranchField.text = addDoctorBranchField.text;
            doctorHospitalField.text = addDoctorHospitalField.text;
            addDoctorObject.SetActive(false);
        }
    }
}
