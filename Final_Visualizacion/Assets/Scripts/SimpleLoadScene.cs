using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimpleLoadScene : MonoBehaviour
{
    public Button btn;
    public string SceneName;
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        if (SceneName != "")
        {
            SceneManager.LoadScene(SceneName);

        }
    }
}
