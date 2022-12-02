using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Security.Policy;
using TMPro;
using UnityEngine.UI;

public class Unit_and_descriptions_pop_up : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject PopUp;
    public GameObject TMP_Tagname;
    public GameObject TMP_Description;
    public GameObject TMP_Unit;
    public string phpURL;


    //Text components
    TextMeshProUGUI TagnameText;
    TextMeshProUGUI DescriptionText;
    TextMeshProUGUI UnitText;
    //Private variables
    private string url;


    void Start()
    {
        //url = "http://
        PopUp.SetActive(false);
        TagnameText = TMP_Tagname.GetComponent<TextMeshProUGUI>();
        DescriptionText = TMP_Description.GetComponent<TextMeshProUGUI>();
        UnitText = TMP_Unit.GetComponent<TextMeshProUGUI>();
    }

    void OnTriggerEnter(Collider other)
    {
        PopUp.SetActive(true);

        TagnameText.text = name;

        url = phpURL + "?tagname=" + name;

        //MeasurementText.text = GetMeasurementsFromDataBase();
        this.UpdatePopupInfo();

    }

    void OnTriggerExit(Collider other)
    {
        PopUp.SetActive(false);
    }

    private void UpdatePopupInfo()
    {
        DescriptionText.text = GetMeasurementsFromDataBase();
        UnitText.text = GetUnitFromDataBase();
    }

    private string GetMeasurementsFromDataBase()
    {
        string response;
        using (WebClient client = new WebClient())
        {
            response = client.DownloadString(url);
        }
        string[] parts = response.Split(',');
        return parts[0];
    }

    private string GetUnitFromDataBase()
    {
        string response;
        using (WebClient client = new WebClient())
        {
            response = client.DownloadString(url);
        }
        string[] parts = response.Split(',');
        return parts[3];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
