using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Security.Policy;
using TMPro;
using UnityEngine.UI;


public class Color_change : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PopUp;
    public GameObject TMP_Tagname;
    public GameObject TMP_Measurement;
    public string phpURL;

    //Text components
    TextMeshProUGUI TagnameText;
    TextMeshProUGUI MeasurementText;

    int tall = 0;
    
    //Private variables
    private string url;

    [SerializeField] private Material myMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myMaterial.color = Color.green;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myMaterial.color = Color.red;
        }
    }

    
    void Start()
    {
        //url = "http://
        TagnameText = TMP_Tagname.GetComponent<TextMeshProUGUI>();
        MeasurementText = TMP_Measurement.GetComponent<TextMeshProUGUI>();
        TagnameText.text = name;

        url = phpURL + "?tagname=" + name + "&amount=1";

        //MeasurementText.text = GetMeasurementsFromDataBase();
        PopUp.SetActive(false);
        this.UpdatePopupInfo();
    }


    private void UpdatePopupInfo()
    {
        MeasurementText.text = GetMeasurementsFromDataBase();
    }

    private string GetMeasurementsFromDataBase()
    {
        string response;
        using (WebClient client = new WebClient())
        {
            response = client.DownloadString(url);
        }
        string[] parts = response.Split(',');
        return parts[1];
    }

    private void updateColorBasedOnInput()
    {
        TagnameText.text = name;

        url = phpURL + "?tagname=" + name + "&amount=1";
        this.UpdatePopupInfo();
        if (MeasurementText.text == "1")
            myMaterial.color = Color.green;
        else
            myMaterial.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (tall < 60)
        {
            tall = tall + 1;
        }
        else
        {
            this.updateColorBasedOnInput();
        }
    }
}
