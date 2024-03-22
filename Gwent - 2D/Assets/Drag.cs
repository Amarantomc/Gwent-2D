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
    private GameObject dropeZone;

    private GameObject startParent;
    private Vector2 startPos;

    private Card card;

    
   

     private void Awake(){
        Canvas=GameObject.Find("UI");
         
        card=gameObject.GetComponent<data>().card;
     }
    
    
    
    
    void Update()
    {   
        if(isDraging){
            transform.position=new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform,true);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision){
         Boards.Rows row=collision.gameObject.GetComponent<Row>().row;
         Debug.Log(row.ToString());
           
          Debug.Log(card.Name);
          
          
          if(card is UnitsCard unitsCard){
              Debug.Log(unitsCard.Atack.ToString());
              if(unitsCard.Atack.ToString()==row.ToString()){
                isOverZone=true;
                dropeZone=collision.gameObject;
                card.Rows=row;
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
       
       if(isOverZone){
        transform.SetParent(dropeZone.transform,false);
       } else{
        transform.position=startPos;
        transform.SetParent(startParent.transform,false);
       }
    }
}
