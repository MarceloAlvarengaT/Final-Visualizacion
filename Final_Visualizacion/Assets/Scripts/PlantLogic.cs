using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantLogic : MonoBehaviour
{
    public static PlantLogic Instance;
    private int sunCount;
    [SerializeField] private int neededSun;

    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void OnDisable()
    {
        Instance = null;
    }

    public void SumSun()
    {
        sunCount += 1;
        if (sunCount == neededSun)
        {
            ExperienceManager.Instance.FotosinteB = true;
            ExperienceManager.Instance.GrowPlantFlow();
        }
    }

}
