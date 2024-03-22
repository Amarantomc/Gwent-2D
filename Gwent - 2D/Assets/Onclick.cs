using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Logic;
using Unity.VisualScripting;
using System.Runtime;
using System;
using UnityEditor.VersionControl;
using UnityEditor.SearchService;

public class OnClick : MonoBehaviour
{
      public GameObject card;
      public GameObject Hand;

      public Players player1;
      public Players player2;


       
    // Start is called before the first frame update
    void Start()
    {   
      GameBase run=new GameBase();
        player1=run.player1;
        player2=run.player2;
       SetCards();
        Debug.Log("Start");
        GameObject[] test= Resources.LoadAll<GameObject>("Prefabs");
        
         Debug.Log(test[0].name);
        
      //   for(int i=0;i<10;i++){ //pongo cartas en la mano
      //     GameObject carta=Instantiate(card,new Vector3(0,0,0),Quaternion.identity);
      // carta.transform.SetParent(Hand.transform,false);
      //   HandTest.Add(test[i]);
      //   test[i].GetComponent<data>().card=player1.Deck.GetCard(i);
           
           for(int i=0;i<player1.Hand.Count;i++){
               for(int j=0;j<test.Length;j++){
                Debug.Log(player1.Hand[i].Name);
               // Debug.Log(test[j].GetComponent<data>().card.Name);
                 if(player1.Hand[i].Name==test[j].GetComponent<data>().card.Name){
                   GameObject card=Instantiate(test[j],new Vector3(0,0,0),Quaternion.identity);
                   card.transform.SetParent(Hand.transform,false);
                   break;
                 }
               }
           }
        
      //   } 



        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclick()
    { 

      GameObject[] test= Resources.LoadAll<GameObject>("Prefabs");
      player1.InsertCardInHand();
      for(int i=0;i<test.Length;i++){
        if(test[i].GetComponent<data>().card.Name==player1.Hand[player1.Hand.Count-1].Name){
            GameObject card=Instantiate(test[i],new Vector3(0,0,0),Quaternion.identity);
            card.transform.SetParent(Hand.transform,false);
            break;
        }
      }

      
       
       
    } 

    private void SetCards(){
      
      GameObject[] test= Resources.LoadAll<GameObject>("Prefabs");
       
       for(int i=0;i<test.Length;i++){
         for(int j=0;i<player1.Deck.Length;j++){
           if(test[i].name==player1.Deck.GetCard(j).Name){
              test[i].GetComponent<data>().card=player1.Deck.GetCard(j);
              break;
           }
         }
       }
    }
}
