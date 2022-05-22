using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager Instance;
    [SerializeField] private Button startGame;
    [SerializeField] private GameObject sowSeed;
    [SerializeField] private GameObject watering;
    [SerializeField] private GameObject passTime;
    [SerializeField] private GameObject growPlant;
    [SerializeField] private GameObject sunMinigame;
    [SerializeField] private GameObject beeAnimation;
    [SerializeField] private Button fruitGrow;
    [SerializeField] private Button plantDead;
    private bool sowSeedB = false;
    private bool wateringB = false;
    private bool passtimeB = false;
    private bool wateringB2 = false;
    private bool growPlantB = false;
    public bool FotosinteB = false;
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
        CheckInitialFlow();
    }

    private void OnDisable()
    {
        Instance = null;
    }

    public void CheckInitialFlow()
    {
        if (!sowSeedB && !wateringB && !passtimeB)
        {
            sowSeed.SetActive(true);
        }
        else if (sowSeedB && !wateringB && !passtimeB)
        {
            watering.SetActive(true);
        }
        else if (sowSeedB && wateringB && !passtimeB)
        {
            passTime.SetActive(true);
        }
        else
        {
            GrowPlantFlow();
        }
    }

    public void GrowPlantFlow()
    {

        if ( !wateringB2 && !growPlantB && !FotosinteB)
        {
            watering.SetActive(true);
        }
        else if (wateringB2 && !growPlantB && !FotosinteB)
        {
            sunMinigame.SetActive(true);
        }
        else if (wateringB2 && !growPlantB && FotosinteB)
        {
            sunMinigame.SetActive(false);
            growPlant.SetActive(true);
        }

    }

}
