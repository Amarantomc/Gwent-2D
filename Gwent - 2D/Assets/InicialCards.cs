using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InicialCards : MonoBehaviour
{
     public GameObject HandCards;

     public GameObject SelectedCards;
    private GameObject clickedCard;

    public static InicialCards Instance;

    void Awake(){
        Instance=this;
    }

    public void SetCards(){
         if(GameManager.Instance.State == GameManager.GameState.InitialPlayer1){
             GameObject hand= GameObject.Find("Hand Player1");
             while(hand.transform.childCount!=0){
                  hand.transform.GetChild(0).gameObject.transform.SetParent(HandCards.transform,false);
             }
         } else  if(GameManager.Instance.State == GameManager.GameState.InitialPlayer2){
             GameObject hand= GameObject.Find("Hand Player2");
             while(hand.transform.childCount!=0){
                  hand.transform.GetChild(0).gameObject.transform.SetParent(HandCards.transform,false);
             }
         }
    }

        void Update()
    {
         if (Input.GetMouseButtonDown(0))
            {   
                PointerEventData pointerData = new PointerEventData(EventSystem.current);
                pointerData.position = Input.mousePosition;

                List<RaycastResult> results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerData, results);

                if (results.Count > 0)
                {
                    clickedCard = results[0].gameObject;
                     
                }
                 if(clickedCard!=null && clickedCard.gameObject.GetComponent<data>()!=null){
                   if(clickedCard.transform.parent.name== HandCards.name && SelectedCards.transform.childCount<2){
                clickedCard.transform.SetParent(SelectedCards.transform,false);
                 
            } else if(clickedCard.transform.parent.name== SelectedCards.name){
                clickedCard.transform.SetParent(HandCards.transform,false);
            }
            
            
              }
            }   

             

           
    }
}
