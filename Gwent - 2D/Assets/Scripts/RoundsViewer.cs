using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundsViewer : MonoBehaviour
{    

    public TMP_Text box;

    private string rounds;

    private GameManager.GameState state;
    // Start is called before the first frame update
    void Start()
    {
        rounds="0/3";
        box.text=rounds;
    }

    // Update is called once per frame
    void Update()
    {
          state=GameManager.Instance.State;
         if(state==GameManager.GameState.Player1Turn){
             box.text=GameManager.Instance.Wins[0].ToString()+"/3";
         } else if(state== GameManager.GameState.Player2Turn){
            box.text=GameManager.Instance.Wins[1].ToString()+"/3";
         }
    }
}
