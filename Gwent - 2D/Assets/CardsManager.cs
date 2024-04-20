using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logic;

public class CardsManager : MonoBehaviour
{   

    public GameObject HandPlayer1;
      public GameObject HandPlayer2;

      public static CardsManager Instance;


      private Players player1; 
      private Players player2; 
     public GameObject[] prefabs;
      public List<GameObject> cardsPlayer1;
      public List<GameObject> cardsPlayer2;
    // Start is called before the first frame update

      void Awake(){
      Instance=this;

      }
    void Start()
    {    
         prefabs= Resources.LoadAll<GameObject>("Prefabs");
         cardsPlayer1=new List<GameObject>(); 
         cardsPlayer2=new List<GameObject>();

        GameManager.Instance.updateState(GameManager.GameState.Start);
         player1=GameManager.Instance.Players[0];
         player2=GameManager.Instance.Players[1];
        
         //Cargo todas las cartas en los respectivos arrays de jugadores
         for(int i=0;i<player1.Hand.Count;i++){
           for(int j=0;j<prefabs.Length;j++){
             
             if( player1.Hand[i].Name==prefabs[j].name  ){
              
                 cardsPlayer1.Add(prefabs[j]);
                  
                 cardsPlayer1[i].GetComponent<data>().card=player1.Hand[i];
                 cardsPlayer1[i].GetComponent<data>().player=player1;

               break;
           }
         } 
         }

         for(int i=0;i<player2.Hand.Count;i++){
            for(int j=0;j<prefabs.Length;j++){
               if(player2.Hand[i].Name==prefabs[j].name){
                 cardsPlayer2.Add(prefabs[j]);
                  
                 cardsPlayer2[i].GetComponent<data>().card=player2.Hand[i];
                 cardsPlayer2[i].GetComponent<data>().player=player2;
                 break;
               }
            }
         }
         GameManager.Instance.updateState(GameManager.GameState.Player1Turn);
    }

    // Update is called once per frame
    void Update()
    {    
        
    }
       
       
        public void  ChangeCard(GameManager.GameState state)
    {     
         if(state== GameManager.GameState.Player1Turn){
           
           if(HandPlayer1.transform.childCount!=0){
                 foreach (Transform card in HandPlayer1.transform)
                 {
                  Destroy(card.gameObject);
                 }
              }
           
             foreach (GameObject card in cardsPlayer1 )
             {  
              
               GameObject card1=Instantiate(card,new Vector3(0,0,0),Quaternion.identity);
               card1.transform.SetParent(HandPlayer1.transform,false);
               card1.GetComponent<data>().card=card.GetComponent<data>().card;
               card1.GetComponent<data>().player=card.GetComponent<data>().player;

             }
                  if(HandPlayer2.transform.childCount==0){
                    for(int i=0;i<10;i++){
                  GameObject cardBack = Resources.Load<GameObject>("Prefabs/" + "CardBack");
                  GameObject card=Instantiate(cardBack,new Vector3(0,0,0),Quaternion.identity);
                   card.transform.SetParent(HandPlayer2.transform,false);
                    }
                  } else{

                     foreach (Transform card in HandPlayer2.transform)
                     {
                      Destroy(card.gameObject);
                     }
                      for(int i=0;i<cardsPlayer2.Count;i++){
                 
                
                GameObject cardBack = Resources.Load<GameObject>("Prefabs/" + "CardBack");
                  GameObject card=Instantiate(cardBack,new Vector3(0,0,0),Quaternion.identity);

                card.transform.SetParent(HandPlayer2.transform,false);
                
                 
              }
                  }
             
         
         } 

        
        
         else if(state== GameManager.GameState.Player2Turn){
              
                if(HandPlayer2.transform.childCount!=0){
                 foreach (Transform card in HandPlayer2.transform)
                 {
                  Destroy(card.gameObject);
                 }
              }
             foreach (GameObject card in cardsPlayer2)
             {
                GameObject card1=Instantiate(card,new Vector3(0,0,0),Quaternion.identity);
               card1.transform.SetParent(HandPlayer2.transform,false);
               card1.GetComponent<data>().card=card.GetComponent<data>().card;
               card1.GetComponent<data>().player=card.GetComponent<data>().player;
             }
                  if(HandPlayer1.transform.childCount==0){
                    for(int i=0;i<10;i++){
                  GameObject cardBack = Resources.Load<GameObject>("Prefabs/" + "CardBack");
                  GameObject card=Instantiate(cardBack,new Vector3(0,0,0),Quaternion.identity);
                   card.transform.SetParent(HandPlayer2.transform,false);
                    }
                  } else{
                     foreach (Transform card in HandPlayer1.transform)
             {
               Destroy(card.gameObject);
             }
              for(int i=0;i<cardsPlayer1.Count;i++){
              GameObject cardBack = Resources.Load<GameObject>("Prefabs/" + "CardBack");
                  GameObject card=Instantiate(cardBack,new Vector3(0,0,0),Quaternion.identity);

                card.transform.SetParent(HandPlayer1.transform,false);
             } 
                  }
            
               
              
            
          }
    } 

     public void RemoveCard(GameObject card,GameManager.GameState state){
        if(state== GameManager.GameState.Player1Turn){
            for(int i=0;i<cardsPlayer1.Count;i++){
               if(cardsPlayer1[i].GetComponent<data>().card.Name== card.GetComponent<data>().card.Name){
                 cardsPlayer1.RemoveAt(i);
                 break;
              }
            }
        } else if( state== GameManager.GameState.Player2Turn){
            for(int i=0;i<cardsPlayer2.Count;i++){
               if(cardsPlayer2[i].GetComponent<data>().card.Name== card.GetComponent<data>().card.Name){
                 cardsPlayer2.RemoveAt(i);
                 break;
              }
            }
        }
     }

}
