using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager Instance;
    [Header("Animators")]
    [SerializeField] Animator seedAnim;
    [SerializeField] Animator waterAnim;
    [SerializeField] Animator growAnim;
    [SerializeField] Animator rightWindowAnim;
    [SerializeField] Animator leftWindowAnim;
    [SerializeField] Animator peachAnim;
    [SerializeField] Animator secondsAnim;
    [SerializeField] Animator minutesAnim;
    [SerializeField] Animator hoursAnim;
    [SerializeField] Animator fadeAnim;

    [Header("GameObjects")]
    [SerializeField] GameObject seedObject;
    [SerializeField] GameObject growingPlantObject;
    [SerializeField] GameObject peachObject;
    [SerializeField] GameObject maturePlantObject;
    [SerializeField] GameObject WateringCanObject;
    [SerializeField] GameObject Windowbject;
    [SerializeField] GameObject ClockObject;

    int wateringCount = 0;
    int endCount = 0;


    [Space]

    public Image fadeImage;
    public bool dayCycle;
    public ParticleSystem waterVFX;

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


    public void seedAnimation()
    {
        seedAnim.SetBool("Plantar", true);
        ExperienceManager.Instance.sowSeedB = true;
        ExperienceManager.Instance.CheckInitialFlow();
    }
    public void regarAnimation()
    {
        seedObject.SetActive(false);
        StartCoroutine(Regadera());
        if (wateringCount == 0)
        {
            ExperienceManager.Instance.wateringB = true;
            ExperienceManager.Instance.CheckInitialFlow();
        }
        else if (wateringCount == 1)
        {
            ExperienceManager.Instance.wateringB2 = true;
            ExperienceManager.Instance.GrowPlantFlow();
        }

    }

    public void ventanaAnimation()
    {
        leftWindowAnim.SetBool("VentanaIzq", true);
        rightWindowAnim.SetBool("VentanaDer", true);
        Windowbject.GetComponent<AudioSource>().Play();
        StartCoroutine(GrowPlant());
    }

    
    public void crecerAnimation()
    {
        if (endCount == 0)
        {
            StartCoroutine(Fade());
            ExperienceManager.Instance.growPlant.SetActive(false);
            ClockObject.GetComponent<AudioSource>().Play();

        }
        else
        {
            StartCoroutine(FadeFinal());
            ExperienceManager.Instance.growPlant.SetActive(false);
            ClockObject.GetComponent<AudioSource>().Play();



        }
    }
    IEnumerator GrowPlant()
    {
        ExperienceManager.Instance.passTime.SetActive(false);
        secondsAnim.SetBool("time",true);
        minutesAnim.SetBool("time", true);
        hoursAnim.SetBool("time", true);
        dayCycle = true;
        yield return new WaitForSeconds(17f);
        dayCycle = false;
        growingPlantObject.SetActive(true);
        growingPlantObject.GetComponent<AudioSource>().Play();
        growAnim.SetBool("Germinar", true);
        ExperienceManager.Instance.passtimeB = true;
        ExperienceManager.Instance.CheckInitialFlow();
    }

    IEnumerator Fade()
    {
        fadeImage.gameObject.SetActive(true);
        fadeAnim.SetBool("Fade", true);
        yield return new WaitForSeconds(2f);
        ExperienceManager.Instance.smallPlant.SetActive(false);
        maturePlantObject.SetActive(true);
        ExperienceManager.Instance.GrowPlantFlow();
        ExperienceManager.Instance.growPlantB = true;
        ExperienceManager.Instance.GrowFlowers();
        yield return new WaitForSeconds(2f);           
        yield return new WaitForSeconds(0.2f);
        fadeImage.gameObject.SetActive(false);
        endCount++;


    }

    IEnumerator FadeFinal()
    {
        fadeImage.gameObject.SetActive(true);
        fadeAnim.SetBool("Fade", true);
        yield return new WaitForSeconds(2f);
        ExperienceManager.Instance.plantDead.SetActive(true);
        ExperienceManager.Instance.mediumPlant.SetActive(false);
        ExperienceManager.Instance.KillFlowers();
        yield return new WaitForSeconds(2f);
        fadeImage.gameObject.SetActive(false);

    }


    IEnumerator Regadera()
    {
        waterAnim.SetBool("PopIn", true);
        yield return new WaitForSeconds(1f);
        waterAnim.SetBool("Regar", true);
        waterVFX.Play();
        WateringCanObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3f);
        waterAnim.SetBool("PopOut", true);

        yield return new WaitForSeconds(3f);
        waterAnim.SetBool("PopIn", false);
        waterAnim.SetBool("Regar", false);
        waterAnim.SetBool("PopOut", false);
        if (wateringCount < 1)
        {
            wateringCount++;

        }


    }

}
