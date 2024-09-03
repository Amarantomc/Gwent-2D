using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialDrag : MonoBehaviour
{
    public GameObject Canvas;
    private bool isDraging = false;
    private bool isOverZone = false;

    

    
    private GameObject dropeZone;

    private GameObject startParent;
    private Vector2 startPos;

    void Awake()
    {
        Canvas=GameObject.Find("Canvas");
    }

    void Update()
    {   
        
        if(isDraging ){
            transform.position=new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform,true);
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name== "Cards Player1"|| collision.gameObject.name=="Cards Player2")
        {
            isOverZone=true;
            dropeZone=collision.gameObject;
        }
    }

     private void OnCollisionExit2D(Collision2D collision)
     {
        isOverZone=false;
        dropeZone=null;
    }

    public void StartDrag()
    {
        
        startParent=transform.parent.gameObject;
        startPos=transform.position;
        isDraging=true;
    }

    public void EndDrag()
    {
        isDraging=false;
        if(isOverZone)
        {
            transform.SetParent(dropeZone.transform,false);
            startPos=transform.position; 
        } else
        {
           transform.position=startPos;
           transform.SetParent(startParent.transform,false);
        }
    }
}
