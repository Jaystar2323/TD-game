using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour
{
    public Text text;
    public GameObject gameCamera;
    public Slider slider;
    public GameObject settingsWindow;

    // Start is called before the first frame update


    // Update is called once per frame
    public void Start()
    {
        //slider.gameObject.SetActive(true);
        slider.value = PlayerPrefs.GetFloat("scrollSpeed");
        //slider.gameObject.SetActive(false);
        gameCamera.GetComponent<CameraControler>().panSpeed = this.GetComponent<Slider>().value * 100;
        settingsWindow.SetActive(false);
        slider.onValueChanged.AddListener(delegate { updateGlobalSettings(); });
    }
    void Update()
    {

        text.text = Mathf.Round(this.GetComponent<Slider>().value * 100).ToString();
    }

    public void speedSlider()
    {
        gameCamera.GetComponent<CameraControler>().panSpeed = this.GetComponent<Slider>().value * 100;
    }

    public void updateGlobalSettings()
    {
        PlayerPrefs.SetFloat("scrollSpeed", slider.value);
        gameCamera.GetComponent<CameraControler>().panSpeed = this.GetComponent<Slider>().value * 100;
    }

}
