using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Zoom : MonoBehaviour
{   

    private GameObject Canvas;

    private GameObject card;
    // Start is called before the first frame update
    void Start()
    {
        Canvas=GameObject.Find("UI");
    }

    public void OnZoom(){
         
        card = Instantiate(gameObject,new Vector2(Input.mousePosition.x,Input.mousePosition.y+200),Quaternion.identity);
        card.transform.SetParent(Canvas.transform,false);
        card.layer=LayerMask.NameToLayer("Zoom");

        RectTransform rect=card.GetComponent<RectTransform>();
        rect.sizeDelta=new Vector2(266,318);
    }

    public void OffZoom(){
  
      Destroy(card);
    }
}
