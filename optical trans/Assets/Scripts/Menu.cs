using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Menu : MonoBehaviour {

    public static string scenename;
    public GameObject pausedMenu;
    public GameObject optionMenu;
    public GameObject soundSlider;
    public GameObject soundInputField;
    public GameObject dropDown;
    public GameObject windowToggle;
    public bool paused = false;
    public bool option = false;
    public static bool loading;
    
    // Use this for initialization

    void Awake()
    {
        LoadOption();
    }

    void Start() {
        scenename = SceneManager.GetActiveScene().name;
        soundSlider.GetComponent<Slider>().onValueChanged.AddListener(delegate { WhanChangeValue(); });
        soundInputField.GetComponent<InputField>().onEndEdit.AddListener(delegate { WhanChangeText(); });
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Onoff();
            if (option == true)
            {
                OptionOnOff();
                pausedMenu.SetActive(paused);
            }
        }
    }



    public void Onoff() {
        paused = !paused;
        pausedMenu.SetActive(paused);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
    public void OptionOnOff() {
        option = !option;
        pausedMenu.SetActive(!option);
        optionMenu.SetActive(option);
    }

    public void OnOffWithOutCanvas() {
        paused = !paused;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    IEnumerator myYield()
    {
        if (paused)
        {
            Onoff();
        }
        GameObject.Find("Main Camera").GetComponent<GlitchEffect>().enabled = true;
        yield return new WaitForSeconds(3.0f);
        if (!loading)
        {
            SceneManager.LoadScene(scenename, LoadSceneMode.Single);
            loading = !loading;
        }
        Time.timeScale = 1;
        //GameObject.Find("Main Camera").GetComponent<GlitchEffect>().enabled = false;
        //gameObject.GetComponent<ChangePos>().Charactor = GameObject.Find("DemoUnityChan2D");
        //gameObject.GetComponent<ChangePos>().Gun = GameObject.Find("P_Gun");
    }
    
    public void Restart() {
        loading = false;
        StartCoroutine("myYield");
    }

    public void SaveOption() {
        Debug.Log("Save Option");
        FileStream stream = new FileStream(Application.persistentDataPath + "/option.sav", FileMode.Create);
        BinaryWriter w = new BinaryWriter(stream);

        w.Write(dropDown.GetComponent<Dropdown>().value);
        w.Write((int)(soundSlider.GetComponent<Slider>().value * 100 + 0.1));
        w.Write(windowToggle.GetComponent<Toggle>().isOn);

        w.Close();
        LoadOption();
    }

    public void LoadOption() {
        Debug.Log("Load Option");
        if (File.Exists(Application.persistentDataPath + "/option.sav"))
        {
            FileStream stream = new FileStream(Application.persistentDataPath + "/option.sav", FileMode.Open);
            BinaryReader r = new BinaryReader(stream);

            dropDown.GetComponent<Dropdown>().value = r.ReadInt32();
            soundInputField.GetComponent<InputField>().text = r.ReadInt32().ToString();
            WhanChangeText();
            windowToggle.GetComponent<Toggle>().isOn = r.ReadBoolean();

            r.Close();
        }
        else {
            Debug.Log("Don't ");
            dropDown.GetComponent<Dropdown>().value = 0;
            soundInputField.GetComponent<InputField>().text = "100";
            windowToggle.GetComponent<Toggle>().isOn = false;

            SaveOption();
        }

        ChangeResolution();
    }

    public void WhanChangeValue() {
        soundInputField.GetComponent<InputField>().text = ((int)(soundSlider.GetComponent<Slider>().value * 100 + 0.1)).ToString();
    }

    public void WhanChangeText()
    {
        if (soundInputField.GetComponent<InputField>().text == null)
            soundInputField.GetComponent<InputField>().text = "0";
        soundSlider.GetComponent<Slider>().value = (float)(Int32.Parse(soundInputField.GetComponent<InputField>().text)) / 100;
    }

    public void ChangeResolution() {
        switch (dropDown.GetComponent<Dropdown>().value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, !windowToggle.GetComponent<Toggle>().isOn);
                break;
            case 1:
                Screen.SetResolution(1600, 900, !windowToggle.GetComponent<Toggle>().isOn);
                break;
            case 2:
                Screen.SetResolution(1280, 720, !windowToggle.GetComponent<Toggle>().isOn);
                break;
            case 3:
                Screen.SetResolution(1152, 648, !windowToggle.GetComponent<Toggle>().isOn);
                break;
            case 4:
                Screen.SetResolution(1024, 576, !windowToggle.GetComponent<Toggle>().isOn);
                break;
            case 5:
                Screen.SetResolution(960, 540, !windowToggle.GetComponent<Toggle>().isOn);
                break;
        }
    }
}
public struct OptionData {
    public int Sound;
    public int Resolution;
    public bool Window;
}

    /*
[Serializable]
public class OptionData
{
    public int Sound;
    public int Resolution;
    public bool Window;

    public OptionData(int sound, int resolution, bool window)
    {
        Sound = sound;
        Resolution = resolution;
        Window = window;
    }
}
*/