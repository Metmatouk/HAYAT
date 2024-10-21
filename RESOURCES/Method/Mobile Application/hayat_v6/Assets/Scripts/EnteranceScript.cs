using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteranceScript : MonoBehaviour
{
    [SerializeField]
    private GameObject logo = null;
    [SerializeField]
    private float targetPosition = 0.0f;
    [SerializeField]
    private float acceleration = 0.0f;
    [SerializeField]
    private float decreaseSpeed = 0.0f;
    [SerializeField]
    private GameObject openingSceneControlObject = null;
    [SerializeField]
    private float minimumDecreaseSpeed = 0.0f;
    [SerializeField]
    private bool movementDirection = false;

    // Start is called before the first frame update
    void Start()
    {
        print(logo.GetComponent<RectTransform>().localPosition.y);
        if (!movementDirection) {
            decreaseSpeed = -decreaseSpeed;
            acceleration = -acceleration;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(openingSceneControlObject == null && targetPosition != 0) {
            if((bool)(logo.GetComponent<RectTransform>().localPosition.y > targetPosition + decreaseSpeed * Time.deltaTime) == movementDirection) {
                logo.GetComponent<RectTransform>().localPosition = new Vector3(logo.GetComponent<RectTransform>().localPosition.x, logo.GetComponent<RectTransform>().localPosition.y - decreaseSpeed * Time.deltaTime, logo.GetComponent<RectTransform>().localPosition.z);
                if(decreaseSpeed >= minimumDecreaseSpeed + acceleration) {
                    decreaseSpeed -= acceleration;
                }
            }
            else {
                logo.GetComponent<RectTransform>().localPosition = new Vector3(logo.GetComponent<RectTransform>().localPosition.x, targetPosition, logo.GetComponent<RectTransform>().localPosition.z);
                targetPosition = 0;
            }
        }
    }
}
