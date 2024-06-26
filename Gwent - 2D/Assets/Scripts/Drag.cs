using System;
using System.Collections;
using System.Collections.Generic;
using Logic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Drag : MonoBehaviour
{
    
    public GameObject Canvas;
    private bool isDraging = false;
    private bool isOverZone = false;

    private bool isPlacedBefore=false;

    
    private GameObject dropeZone;

    private GameObject startParent;
    private Vector2 startPos;
    
    
     
    
   

     private void Awake(){
        Canvas=GameObject.Find("UI");
         
       
     }
    
    
    
    
    void Update()
    {   
        
        if(isDraging && (!isPlacedBefore)){
            transform.position=new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform,true);
            
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision){
         string player="";
         if(GameManager.Instance.State== GameManager.GameState.Player1Turn) player="Player1";
        else if(GameManager.Instance.State== GameManager.GameState.Player2Turn) player="Player2";

        Card card=gameObject.GetComponent<data>().card;
        Boards.Rows row;
         if(collision.gameObject.GetComponent<Row>()!=null) {
         row=collision.gameObject.GetComponent<Row>().row;
         } else row= Boards.Rows.Graveyard; //Posible falla este parche
        
          
         
        
           if(card is UnitsCard unitsCard &&(collision.gameObject.name.Contains(player))){
             
              if(unitsCard.Atack.ToString().Contains(row.ToString())){
                 Debug.Log("Entro");
                isOverZone=true;
                dropeZone=collision.gameObject;
                gameObject.GetComponent<data>().card.Rows=row;
                 
                
              }
          } else if(card is WeatherCard &&(collision.gameObject.name.Contains(player))){
                  if(row == Boards.Rows.Weather){
                     
                      isOverZone=true;
                dropeZone=collision.gameObject;
                if(collision.gameObject.name.Contains("W1")) gameObject.GetComponent<data>().card.Rows=Boards.Rows.M;
                
                 else if(collision.gameObject.name.Contains("W2"))gameObject.GetComponent<data>().card.Rows=Boards.Rows.R;
                
                  else if(collision.gameObject.name.Contains("W3")) gameObject.GetComponent<data>().card.Rows=Boards.Rows.S;
                  }
          }  else  if((card is Increase || card is Lure || card is Clearance) &&(collision.gameObject.name.Contains(player))){
                  if(row!= Boards.Rows.Weather){
                      isOverZone=true;
                      dropeZone=collision.gameObject;
                      gameObject.GetComponent<data>().card.Rows=row;
                   
                  }
                  
                   
          }
              
            
          
       
          
           
         
    }

      



    private void OnCollisionExit2D(Collision2D collision){
        isOverZone=false;
        dropeZone=null;
    }
    public void StartDrag(){
        
        
         startParent=transform.parent.gameObject;
        startPos=transform.position;
        isDraging=true;
       
        
    }

     public void EndDrag(){
       
        isDraging=false;
       
       if(isOverZone && !isPlacedBefore){
        Card card=gameObject.GetComponent<data>().card;
        Boards.Rows row=card.Rows;
        transform.SetParent(dropeZone.transform,false);
        startPos=transform.position; 
         isPlacedBefore=true;
            if(card is Increase){
                        if(row== Boards.Rows.M && (GameManager.Instance.State== GameManager.GameState.InitialPlayer1 ||
                 GameManager.Instance.State== GameManager.GameState.Player1Turn))
                     EffectManager.Instance.ActiveIncreasePlayer1[0]=true;
                    
                     else if(row== Boards.Rows.M) EffectManager.Instance.ActiveIncreasePlayer2[0]=true;
                     
                     else if(row== Boards.Rows.R && (GameManager.Instance.State== GameManager.GameState.InitialPlayer1 ||
                 GameManager.Instance.State== GameManager.GameState.Player1Turn))
                     EffectManager.Instance.ActiveIncreasePlayer1[1]=true;

                     else if(row== Boards.Rows.R) EffectManager.Instance.ActiveIncreasePlayer2[1]=true;

                     else if(row== Boards.Rows.S && (GameManager.Instance.State== GameManager.GameState.InitialPlayer1 ||
                 GameManager.Instance.State== GameManager.GameState.Player1Turn))
                     EffectManager.Instance.ActiveIncreasePlayer1[2]=true;

                     else if(row== Boards.Rows.S) EffectManager.Instance.ActiveIncreasePlayer2[2]=true;
            } 
            
            else    if(card is WeatherCard){
                        if(row== Boards.Rows.M && (GameManager.Instance.State== GameManager.GameState.InitialPlayer1 ||
                 GameManager.Instance.State== GameManager.GameState.Player1Turn))
                     EffectManager.Instance.ActiveWeatherPlayer1[0]=true;
                    
                     else if(row== Boards.Rows.M) EffectManager.Instance.ActiveWeatherPlayer2[0]=true;
                     
                     else if(row== Boards.Rows.R && (GameManager.Instance.State== GameManager.GameState.InitialPlayer1 ||
                 GameManager.Instance.State== GameManager.GameState.Player1Turn))
                     EffectManager.Instance.ActiveWeatherPlayer1[1]=true;

                     else if(row== Boards.Rows.R) EffectManager.Instance.ActiveWeatherPlayer2[1]=true;

                     else if(row== Boards.Rows.S && (GameManager.Instance.State== GameManager.GameState.InitialPlayer1 ||
                 GameManager.Instance.State== GameManager.GameState.Player1Turn))
                     EffectManager.Instance.ActiveWeatherPlayer1[2]=true;

                     else if(row== Boards.Rows.S) EffectManager.Instance.ActiveWeatherPlayer2[2]=true;
                      }          
         
        GameManager.PlayCard(gameObject);
       
        
       
       }
        else{
        transform.position=startPos;
        transform.SetParent(startParent.transform,false);
       }
    }
}
