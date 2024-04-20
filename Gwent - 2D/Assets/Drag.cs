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
         
        Card card=gameObject.GetComponent<data>().card;
        Boards.Rows row;
         if(collision.gameObject.GetComponent<Row>()!=null) {
         row=collision.gameObject.GetComponent<Row>().row;
         } else row= Boards.Rows.Graveyard; //Posible falla este parche
        
      
         
        
           if(card is UnitsCard unitsCard){
           
              if(unitsCard.Atack.ToString().Contains(row.ToString())){
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
        transform.SetParent(dropeZone.transform,false);
        startPos=transform.position; 
         isPlacedBefore=true;
         
        GameManager.PlayCard(gameObject);
       
        
       
       }
        else{
        transform.position=startPos;
        transform.SetParent(startParent.transform,false);
       }
    }
}
