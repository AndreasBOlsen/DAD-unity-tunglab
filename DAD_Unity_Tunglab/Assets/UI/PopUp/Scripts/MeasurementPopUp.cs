using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Security.Policy;
using TMPro;
using UnityEngine.UI;




public class MeasurementPopUp : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject PopUp;
    public GameObject TMP_Tagname;
    public GameObject TMP_Measurement;
    public string phpURL;


    //Text components
    TextMeshProUGUI TagnameText;
    TextMeshProUGUI MeasurementText;

    //Private variables
    private string url;


    void Start()
    {
        //url = "http://
        PopUp.SetActive(false);
        TagnameText = TMP_Tagname.GetComponent<TextMeshProUGUI>();
        MeasurementText = TMP_Measurement.GetComponent<TextMeshProUGUI>();
    }

    void OnTriggerEnter(Collider other)
    { 
        PopUp.SetActive(true);

        TagnameText.text = name;

        url = phpURL + "?tagname=" + name + "&amount=1";

        //MeasurementText.text = GetMeasurementsFromDataBase();
        this.UpdatePopupInfo();

    }

    void OnTriggerExit(Collider other)
    {
        PopUp.SetActive(false); 
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
    // Update is called once per frame
    void Update()
    {

    }
}
