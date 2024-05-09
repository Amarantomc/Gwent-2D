using System.Collections;
using System.Collections.Generic;
using Logic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeatherPanel : MonoBehaviour
{
     public GameObject AllCards;

     public GameObject SelectedCard;
    private GameObject clickedCard;
   
    public GameObject box;

    public static WeatherPanel Instance;


    void Awake(){
        Instance=this;
    }

       
    public void SetCards(){
      if(GameManager.Instance.State == GameManager.GameState.Player1Turn ){
             GameObject hand= GameObject.Find("Hand Player2");
               for(int i=0;i<hand.transform.childCount;i++){
                  if(hand.transform.GetChild(i).gameObject.GetComponent<data>().card is WeatherCard){
                    hand.transform.GetChild(i).gameObject.transform.SetParent(AllCards.transform,false);
                  }
               }
         } else  if(GameManager.Instance.State == GameManager.GameState.Player2Turn){
             GameObject hand= GameObject.Find("Hand Player1");
               for(int i=0;i<hand.transform.childCount;i++){
                  if(hand.transform.GetChild(i).gameObject.GetComponent<data>().card is WeatherCard){
                    hand.transform.GetChild(i).gameObject.transform.SetParent(AllCards.transform,false);
                  }
               }
         } 

         if(AllCards.transform.childCount==0){
             box.SetActive(true);
              StartCoroutine(Wait());

         }
    }

              IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        box.SetActive(false);
        gameObject.SetActive(false);
         
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
                   if(clickedCard.transform.parent.name== AllCards.name && SelectedCard.transform.childCount<1){
                clickedCard.transform.SetParent(SelectedCard.transform,false);
                 
            } else if(clickedCard.transform.parent.name== SelectedCard.name){
                clickedCard.transform.SetParent(AllCards.transform,false);
            }
            
            
              }
            }   

             

           
    }
}
