using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendersSpawner : MonoBehaviour
{
     Defender defender;
    GameObject defenderParent;
    const string DEFENDERS_PARENT_NAME = "Defenders";


    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDERS_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDERS_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
        
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var startDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();
        if (startDisplay.HaveEnoughStars(defenderCost))
        {
        // If we have enough Stars or Cash
           // spawn the defender
           // spend the Stars
            SpawnDefender(gridPos);
            startDisplay.SpendStars(defenderCost);
        }
    }

    // We want to return a vector
    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
    
    private void SpawnDefender(Vector2 roundedPos)
    {
        Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }
}
