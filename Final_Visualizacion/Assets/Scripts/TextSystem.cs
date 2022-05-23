using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSystem : MonoBehaviour
{
    public static TextSystem Instance;
    public GameObject[] TextList;
    public GameObject TextGo;
    public GameObject NextBtn;
    public int textCount = -1;

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

        UseTextSystem();
    }

    private void OnDisable()
    {
        Instance = null;
    }

    public void UseTextSystem()
    {
        textCount++;
        if (textCount < TextList.Length)
        {
            TextList[textCount].SetActive(true);

        }
        if (textCount > 0)
        {
            TextList[textCount - 1].SetActive(false);
        }
        if (textCount == 2 || textCount == 3 || textCount == 8 || textCount == 12  || textCount == 14 || textCount == 16 || textCount == 18 || textCount == 20 || textCount == 25)
        {
            CloseText();
        }
    }
    public void CloseText()
    {
        TextGo.SetActive(false);
        NextBtn.SetActive(false);
        if (textCount == 16)
        {
            ExperienceManager.Instance.StarFlowers();
        }
        if (textCount == 18)
        {
            ExperienceManager.Instance.Bee();
        }
        if (textCount == 25)
        {
            ExperienceManager.Instance.EndScreenActivate();

        }
    }

}
