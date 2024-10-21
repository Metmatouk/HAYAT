using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpeningScene : MonoBehaviour
{
    [SerializeField]
    private GameObject openingSceneScreen;
    [SerializeField]
    private float openingSceneWaitTime;
    [SerializeField]
    private Material openingSceneCloseMaterial;
    [SerializeField, Range(0, 1)]
    private float closeEffectIntensity;
    [SerializeField, Range(0, 1)]
    private float closeEffectSpeed;
    [SerializeField]
    private TextMeshProUGUI mainText;
    [SerializeField]
    private float closedWaitTime = 0;

    private int screenWidth;
    private int screenHeight;
    private bool sceneStartControl;

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        openingSceneScreen.GetComponent<RectTransform>().sizeDelta = new Vector2(screenWidth, screenHeight);
        openingSceneCloseMaterial.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f));
    }
    
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(firstScene());
        if(sceneStartControl) {
            if(openingSceneCloseMaterial.GetColor("_Color").r < closeEffectIntensity) {
                openingSceneCloseMaterial.SetColor("_Color", new Color(0.0f, 0.0f, 0.0f, 1.0f));
                mainText.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
                sceneStartControl = false;
                StartCoroutine(destroyWait(closedWaitTime));
            }
            else {
                openingSceneCloseMaterial.SetColor("_Color", new Color(openingSceneCloseMaterial.GetColor("_Color").r - closeEffectIntensity * Time.deltaTime / closeEffectSpeed, openingSceneCloseMaterial.GetColor("_Color").g - closeEffectIntensity * Time.deltaTime / closeEffectSpeed, openingSceneCloseMaterial.GetColor("_Color").b - closeEffectIntensity * Time.deltaTime / closeEffectSpeed, 1.0f));
                mainText.color = new Color(mainText.color.r - closeEffectIntensity * Time.deltaTime / closeEffectSpeed, mainText.color.g - closeEffectIntensity * Time.deltaTime / closeEffectSpeed, mainText.color.b - closeEffectIntensity * Time.deltaTime / closeEffectSpeed, 1.0f);
            }
        }
    }

    IEnumerator firstScene() {
        yield return new WaitForSecondsRealtime(openingSceneWaitTime);
        sceneStartControl = true;
    }

    IEnumerator destroyWait(float time) {
        yield return new WaitForSecondsRealtime(time);
        Destroy(openingSceneScreen);
        openingSceneCloseMaterial.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f, 1.0f));
    }
}
