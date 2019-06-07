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
    public int settingNum = 0;

    private static bool done = false;
    private static bool done2 = false;

    // Start is called before the first frame update


    // Update is called once per frame
    public void Start()
    {
        if (settingNum == 1)
        {
            //settingsWindow.SetActive(true);
           // Debug.Log("running");
            slider.value = PlayerPrefs.GetFloat("volume");
            CameraControler.soundVolume = this.GetComponent<Slider>().value;
            slider.onValueChanged.AddListener(delegate { updateVolumeSettings(); });
            done2 = true;
            //settingsWindow.SetActive(false);

        }

        //slider.gameObject.SetActive(true);
        if (settingNum == 0)
        {
            //settingsWindow.SetActive(true);

            slider.value = PlayerPrefs.GetFloat("scrollSpeed");
            gameCamera.GetComponent<CameraControler>().panSpeed = this.GetComponent<Slider>().value * 100;
            slider.onValueChanged.AddListener(delegate { updateGlobalSettings(); });
            done = true;
            //settingsWindow.SetActive(false);

        }



        //slider.gameObject.SetActive(false);


    }
    void Update()
    {
        //Debug.Log(done + " " + done2);
        if (done && done2 && settingsWindow.activeSelf)
        {
            //Debug.Log("off");
            settingsWindow.SetActive(false);
            done = false;
        }
        text.text = Mathf.Round(this.GetComponent<Slider>().value * 100).ToString();
    }

    public void speedSlider()
    {
        gameCamera.GetComponent<CameraControler>().panSpeed = this.GetComponent<Slider>().value * 100;
    }
    public void volumeSlider()
    {
        CameraControler.soundVolume = this.GetComponent<Slider>().value;
    }

    public void updateGlobalSettings()
    {
        PlayerPrefs.SetFloat("scrollSpeed", slider.value);
        gameCamera.GetComponent<CameraControler>().panSpeed = this.GetComponent<Slider>().value * 100;
    }
    public void updateVolumeSettings()
    {
        PlayerPrefs.SetFloat("volume", slider.value);
        CameraControler.soundVolume = this.GetComponent<Slider>().value;
    }
}
