using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour {

    public GameObject loadImg;

    public void LoadScene(int level)
    {
        loadImg.SetActive(true);
        Application.LoadLevel(level);
        //SceneManager.LoadScene(level);
    }
}
