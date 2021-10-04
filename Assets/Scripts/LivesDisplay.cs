using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{

    [SerializeField] float baseLives = 3;
    [SerializeField] int damage = 1;
    float lives;
    Text liveText;


    // Start is called before the first frame update
    void Start()
    {

        lives = baseLives - PlayerPrefsController.GetDifficulty();
        liveText = GetComponent<Text>();
        UpdateDisplay();
        Debug.Log("Difficulty is " + PlayerPrefsController.GetDifficulty());

    }

    private void UpdateDisplay()
    {
        liveText.text = lives.ToString();
    }

    public void TakeLife()
    {

        lives -= damage;
        UpdateDisplay();

        if (lives <= 0)
        {
            //FindObjectOfType<LevelLoader>().LoadYouLoseScreen();
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
        

    }


   
}
