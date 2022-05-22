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
    [SerializeField] private GameObject sunMinigame;
    [SerializeField] private GameObject beeAnimation;
    [SerializeField] private Button fruitGrow;
    [SerializeField] private Button plantDead;
    private bool sowSeedB = false;
    private bool wateringB = false;
    private bool passtimeB = false;
    private bool sowSeedB2 = false;
    private bool wateringB2 = false;
    private bool growPlantB= false;
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
            sowSeed.gameObject.SetActive(true);
        }
        else if (sowSeedB && !wateringB && !passtimeB)
        {
            watering.gameObject.SetActive(true);
        }
        else if (sowSeedB && wateringB && !passtimeB)
        {
            passTime.gameObject.SetActive(true);
        }
        else
        {
            sunMinigame.SetActive(true);
        }
    }

    public void GrowPlantFlow()
    {
        if (!sowSeedB2 && !wateringB2 && !growPlantB)
        {
            sowSeed.gameObject.SetActive(true);
        }
        else if (sowSeedB && !wateringB && !passtimeB)
        {
            watering.gameObject.SetActive(true);
        }
        else if (sowSeedB && wateringB && !passtimeB)
        {
            passTime.gameObject.SetActive(true);
        }
        else
        {
            sunMinigame.SetActive(true);
        }
    }

}
