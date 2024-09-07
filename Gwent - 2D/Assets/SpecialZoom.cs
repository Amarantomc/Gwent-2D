using System.Collections;
using System.Collections.Generic;
 
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpecialZoom : MonoBehaviour
{
     private GameObject Canvas;

    private GameObject card;
    // Start is called before the first frame update
    void Start()
    {
        Canvas=GameObject.Find("UI");
    }

    public void OnZoom(){
         
        GameObject prefab=Resources.Load<GameObject>("Prefabs/Compiler Show Card");
        card = Instantiate(prefab,new Vector2(Input.mousePosition.x,Input.mousePosition.y+200),Quaternion.identity);
        card.transform.SetParent(Canvas.transform,false);
        card.layer=LayerMask.NameToLayer("Zoom");
 
       
        foreach (Transform item in card.transform)
        {
            if(item.name=="Name C") item.GetComponent<TMP_Text>().text=gameObject.transform.Find("Name C").GetComponent<TMP_Text>().text;
            else if(item.name=="Attack C") item.GetComponent<TMP_Text>().text=gameObject.transform.Find("Attack C").GetComponent<TMP_Text>().text;
            else if(item.name=="Type C") item.GetComponent<TMP_Text>().text=gameObject.transform.Find("Type C").GetComponent<TMP_Text>().text;
            else if(item.name=="Effect C") item.GetComponent<TMP_Text>().text=gameObject.transform.Find("Effect C").GetComponent<TMP_Text>().text;
           else if(item.name=="Power") 
           {
               item.GetChild(0).GetComponent<TMP_Text>().text=gameObject.transform.Find("Power").GetChild(0).GetComponent<TMP_Text>().text;
           } 
           else if(item.name=="Back") item.GetComponent<Image>().sprite=gameObject.transform.Find("Back").GetComponent<Image>().sprite;

           

        }
         RectTransform rect=card.GetComponent<RectTransform>();
        rect.sizeDelta=new Vector2(400,350);
    }

    public void OffZoom(){
  
      Destroy(card);
    }
}
