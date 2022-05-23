using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager Instance;
    [SerializeField] private Button startGame;
    [SerializeField] private GameObject sowSeed;
    [SerializeField] private GameObject watering;
    [SerializeField] public GameObject passTime;
    [SerializeField] public GameObject growPlant;
    [SerializeField] private GameObject sunMinigame;
    [SerializeField] private GameObject beeAnimation;
    [SerializeField] public GameObject smallPlant;
    [SerializeField] public GameObject mediumPlant;
    [SerializeField] public GameObject plantDead;
    [SerializeField] private GameObject peach;
    [SerializeField] private GameObject flowerVideo;
    [SerializeField] private GameObject flowerVideo1;
    [SerializeField] private GameObject[] otherFlowers;
    [SerializeField] public GameObject nextBtn;
    [SerializeField] public GameObject Creditos;


    public bool sowSeedB = false;
    public bool wateringB = false;
    public bool passtimeB = false;
    public bool wateringB2 = false;
    public bool growPlantB = false;
    public bool FotosinteB = false;
    public bool growPlantB2 = false;


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

    public IEnumerator ActivateText (float time)
    {
        yield return new WaitForSeconds(time);
        TextSystem.Instance.TextGo.SetActive(true);
        nextBtn.SetActive(true);
    }


    public IEnumerator ActivateWatering1(float time)
    {
        yield return new WaitForSeconds(time);
        sowSeed.SetActive(false);
        watering.SetActive(true);
    }

    public IEnumerator ActivateTime1(float time)
    {
        watering.SetActive(false);
        yield return new WaitForSeconds(time);
        passTime.SetActive(true);
    }


    public IEnumerator ActivateWatering2(float time)
    {
        yield return new WaitForSeconds(time);
        passTime.SetActive(false);
        GrowPlantFlow();
    }


    public void CheckInitialFlow()
    {
        if (!sowSeedB && !wateringB && !passtimeB)
        {
            sowSeed.SetActive(true);
        }
        else if (sowSeedB && !wateringB && !passtimeB)
        {
            StartCoroutine(ActivateText(2f));
            StartCoroutine(ActivateWatering1(2f));

        }
        else if (sowSeedB && wateringB && !passtimeB)
        {
            StartCoroutine(ActivateText(5f));
            StartCoroutine(ActivateTime1(5f));

        }
        else
        {

            StartCoroutine(ActivateText(3f));
            StartCoroutine(ActivateWatering2(3f));         
        }
    }

    public void GrowPlantFlow()
    {

        if (!wateringB2 && !growPlantB && !FotosinteB)
        {
            watering.SetActive(true);
        }
        else if (wateringB2 && !growPlantB && !FotosinteB)
        {
            StartCoroutine(ActivateText(3f));
            watering.SetActive(false);
            sunMinigame.SetActive(true);
        }
        else if (wateringB2 && !growPlantB && FotosinteB)
        {
            sunMinigame.SetActive(false);
            growPlant.SetActive(true);
        }
        if (growPlantB)
        {
            growPlant.SetActive(false);
        }
    }

    public void GrowFlowers()
    {
        StartCoroutine(ActivateText(0.1f));
    }

    public void StarFlowers()
    {
        StartCoroutine(BeeAndFlowersAnimation());
    }

    public IEnumerator BeeAndFlowersAnimation()
    {
        growPlant.SetActive(false);
        flowerVideo.SetActive(true);
        flowerVideo.GetComponent<MeshRenderer>().enabled = true;
        flowerVideo.GetComponent<VideoPlayer>().Play();
        flowerVideo.GetComponent<AudioSource>().Play();

        for (int i = 0; i < otherFlowers.Length; i++)
        {
            otherFlowers[i].GetComponent<MeshRenderer>().enabled = true;
            otherFlowers[i].GetComponent<VideoPlayer>().Play();
            otherFlowers[i].GetComponent<AudioSource>().Play();

        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(ActivateText(0.1f));
    }

    public void Bee()
    {
        StartCoroutine(StartBee());
    }

    IEnumerator StartBee()
    {

        flowerVideo1.GetComponent<MeshRenderer>().enabled = true;
        flowerVideo1.GetComponent<VideoPlayer>().Play();
        flowerVideo.SetActive(false);
        beeAnimation.SetActive(true);
        yield return new WaitForSeconds(8f);
        beeAnimation.SetActive(false);
        peach.SetActive(true);
        yield return new WaitForSeconds(1f);
        flowerVideo1.SetActive(false);
        yield return new WaitForSeconds(1f);
        StartCoroutine(ActivateText(0.1f));
        yield return new WaitForSeconds(1f);
        growPlant.SetActive(true);
    }


    public void KillFlowers()
    {
        for (int i = 0; i < otherFlowers.Length; i++)
        {
            otherFlowers[i].gameObject.SetActive(false);        
        }
        growPlant.SetActive(false);
        End();
    }

    private void End()
    {
        StartCoroutine(ActivateText(3f));
    }

    public void EndScreenActivate()
    {
        StartCoroutine(EndScreen());
    }
    IEnumerator EndScreen()
    {
        yield return new WaitForSeconds(2f);
        Creditos.SetActive(true);

    }
}
