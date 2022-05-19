using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationManager : MonoBehaviour
{
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

    [SerializeField] GameObject seedObject;
    [SerializeField] GameObject growingPlantObject;
    [SerializeField] GameObject peachObject;
    [SerializeField] GameObject maturePlantObject;

    public Image fadeImage;

    public bool dayCycle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void seedAnimation()
    {
        seedAnim.SetBool("Plantar", true);
    }
    public void regarAnimation()
    {
        seedObject.SetActive(false);
        waterAnim.SetBool("Regar", true);
    }
    public void ventanaAnimation()
    {
        leftWindowAnim.SetBool("VentanaIzq", true);
        rightWindowAnim.SetBool("VentanaDer", true);
        StartCoroutine(GrowPlant());
    }

    public void crecerAnimation()
    {
        StartCoroutine(Fade());
    }
    IEnumerator GrowPlant()
    {
        secondsAnim.SetBool("time",true);
        minutesAnim.SetBool("time", true);
        hoursAnim.SetBool("time", true);
        dayCycle = true;
        yield return new WaitForSeconds(17f);
        dayCycle = false;
        growingPlantObject.SetActive(true);
        growAnim.SetBool("Germinar", true);
    }

    IEnumerator Fade()
    {
        fadeImage.gameObject.SetActive(true);
        fadeAnim.SetBool("Fade", true);
        yield return new WaitForSeconds(2f);
        maturePlantObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        fadeImage.gameObject.SetActive(false);
    }

}
