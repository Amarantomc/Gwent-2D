using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsViewer : MonoBehaviour

{    
    public TMP_Text box;

    private string points;

    private GameManager.GameState state;
    // Start is called before the first frame update
    void Start()
    {
        box.text="0";
    }

    // Update is called once per frame
    void Update()
    {
        state=GameManager.Instance.State;
         if(state==GameManager.GameState.Player1Turn){
             box.text=GameManager.Instance.Players[0].Points.ToString();
         } else if(state== GameManager.GameState.Player2Turn){
            box.text=GameManager.Instance.Players[1].Points.ToString();
         }
    }
}
