using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int totalDisplays = 2;

    public float delayTime = 5f;

    public Animator transition;

    public float transitionTime = 1f;


    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex < totalDisplays)
        {
            StartCoroutine(DisplayDelay());
        }
    }

    /*
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }*/

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator DisplayDelay()
    {
        yield return new WaitForSeconds(delayTime);

        LoadNextLevel();
    }
}
