using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject completeLevelUI;
    public GameObject startLevelUI;
    public GameObject gameOverUI;
    public GameObject targetUI;
    public GameObject redScreenUI;

    private void OnGUI()
    {
    }

    private void Start()
    {
        //startLevelUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        StartCoroutine(OpenMenu());
    }

    public void RedScreen()
    {
        redScreenUI.SetActive(true);
    }

    public void NormalScreen()
    {
        redScreenUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //startLevelUI.SetActive(false);
            //targetUI.SetActive(true);
        }
    }

    public IEnumerator OpenMenu()
    {
        yield return (new WaitForSeconds(3));
        SceneManager.LoadScene(0);
    }
}
