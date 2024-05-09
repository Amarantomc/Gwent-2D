using System.Collections;
using System.Collections.Generic;
using Logic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeletePanel : MonoBehaviour
{
     public GameObject AllCards;

     public GameObject DeleteCard;

     public GameObject box;
    
    private GameObject clickedCard;

    public static DeletePanel Instance;

    void Awake()
    {   
        Instance=this;
 }  


   public void SetCards(){
         GameObject MRow;
        GameObject RRow;
          GameObject SRow;
        if(GameManager.Instance.State== GameManager.GameState.Player1Turn){
            MRow=GameObject.Find("M Player2");
            RRow=GameObject.Find("R Player2");
            SRow=GameObject.Find("S Player2");
              foreach (Transform child in MRow.transform)
         { 
             if(child.gameObject.GetComponent<data>().card is UnitsCard unitsCard && unitsCard.Type== UnitsCard.UnitType.Silver){

               child.gameObject.transform.SetParent(AllCards.transform,false);
             }
         }
           foreach (Transform child in RRow.transform)
         {
             if(child.gameObject.GetComponent<data>().card is UnitsCard unitsCard && unitsCard.Type== UnitsCard.UnitType.Silver){

               child.gameObject.transform.SetParent(AllCards.transform,false);
             }
         }
           foreach (Transform child in SRow.transform)
         {
             if(child.gameObject.GetComponent<data>().card is UnitsCard unitsCard && unitsCard.Type== UnitsCard.UnitType.Silver){

               child.gameObject.transform.SetParent(AllCards.transform,false);
             }
         }

            
        } else if(GameManager.Instance.State== GameManager.GameState.Player2Turn){
             MRow=GameObject.Find("M Player1");
            RRow=GameObject.Find("R Player1");
            SRow=GameObject.Find("S Player1");
              foreach (Transform child in MRow.transform)
         {
             if(child.gameObject.GetComponent<data>().card is UnitsCard unitsCard && unitsCard.Type== UnitsCard.UnitType.Silver){

               child.gameObject.transform.SetParent(AllCards.transform,false);
             }
         }
           foreach (Transform child in RRow.transform)
         {
             if(child.gameObject.GetComponent<data>().card is UnitsCard unitsCard && unitsCard.Type== UnitsCard.UnitType.Silver){

               child.gameObject.transform.SetParent(AllCards.transform,false);
             }
         }
           foreach (Transform child in SRow.transform)
         {
             if(child.gameObject.GetComponent<data>().card is UnitsCard unitsCard && unitsCard.Type== UnitsCard.UnitType.Silver){

               child.gameObject.transform.SetParent(AllCards.transform,false);
             }
         }
           
        }  if(AllCards.transform.childCount==0){
              box.SetActive(true);
            StartCoroutine(Wait());
              
             
              
          }
    }
         IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        box.SetActive(false);
        gameObject.SetActive(false);
         
    }

    // Update is called once per frame
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
            }   

              if(clickedCard!=null && clickedCard.gameObject.GetComponent<data>()!=null){
              
                     if(DeleteCard.transform.childCount!=0){
                DeleteCard.transform.GetChild(0).gameObject.transform.SetParent(AllCards.transform,false);
                clickedCard.transform.SetParent(DeleteCard.transform,false);
            } else{
                clickedCard.transform.SetParent(DeleteCard.transform,false);
            }
             
              }
                    
   
    }
}
