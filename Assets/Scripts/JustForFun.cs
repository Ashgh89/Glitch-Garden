using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JustForFun : MonoBehaviour
{

    int currentSceneIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(Waiting());
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(5);
        LoadScene();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
