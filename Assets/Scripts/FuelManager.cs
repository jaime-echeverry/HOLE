using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI timePanel;

    [SerializeField]
    Image FuelBar;

    [SerializeField]
    TextMeshProUGUI PointsBar;

    public float points = 0;
    public float fuel = 50;
    float time = 0;
    float maxFuel = 100;

    private static FuelManager instance;
    public static FuelManager Instance { get { return instance; } }


    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        FuelBar.fillAmount = fuel/maxFuel;
        timePanel.text = Time.time + "s";
    }

    // Update is called once per frame
    void Update()
    {
        time = Mathf.FloorToInt(Time.time);
        timePanel.text =  time.ToString() + " s";
    }

    public void GrabbedGem(float gemValue) {
        points += gemValue + 20f;
        fuel += gemValue;
        if (fuel > maxFuel) { 
            fuel = maxFuel;
        }
        FuelBar.fillAmount = fuel / maxFuel;
        PointsBar.text = points.ToString() + " pts";
    }

    public void ResetScores() {
        points = 0;
        fuel = 50;
        time = 0;
        FuelBar.fillAmount = fuel / maxFuel;
        PointsBar.text = points.ToString();
    }

    public void SpentFuel(float fuelValue) {
        fuel -= fuelValue;
        FuelBar.fillAmount = fuel / maxFuel;
    }
}
