using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class CardsPanel : MonoBehaviour
{
    public GameObject CardPanel;

    private GameObject prefabCard;

    
    
    // Start is called before the first frame update
    void Start()
    {    
        prefabCard=Resources.Load("Prefabs/Compiler Show Card") as GameObject;
        Sprite [] sprite=Resources.LoadAll<Sprite>("Sprites");
         int index=0;
        foreach (var card in CompilerButton.Instance.Cards)
        {  
            GameObject cardObject = Instantiate(prefabCard,new Vector3(0,0,0),Quaternion.identity);
            cardObject.transform.SetParent(CardPanel.transform,false);
             cardObject.gameObject.GetComponent<data>().card=card;
           
           SetCompilerCard(cardObject,card,sprite[index]);
           index++;
           if(index>sprite.Length) index=0;
          
        }
    }

    public static void SetCompilerCard(GameObject cardObject, Card card,Sprite sprite)
    {
         foreach (Transform item in cardObject.transform)
           {  
             if(item.name== "Name C")  item.gameObject.GetComponent<TMP_Text>().text = card.Name;
             else if(item.name =="Back") item.gameObject.GetComponent<Image>().sprite=sprite;
            
             else if(card is UnitsCard unitsCard)
             {
                if(item.name =="Attack C") item.gameObject.GetComponent<TMP_Text>().text = unitsCard.Atack.ToString();
                else if(item.name =="Type C")  item.gameObject.GetComponent<TMP_Text>().text = (unitsCard.Type== UnitsCard.UnitType.Gold)?"Oro" :"Plata";
                else if(item.name =="Power")  item.GetChild(0).gameObject.GetComponent<TMP_Text>().text = unitsCard.Power.ToString();
                else if(item.name =="Effect C")
                {   
                    if(unitsCard.Effect is CompilerEffects effect) item.gameObject.GetComponent<TMP_Text>().text = effect.Values[0].Item1;
                    else item.gameObject.GetComponent<TMP_Text>().text = "None";
                    
                    
                }

            } 
            else if( card is WeatherCard)
            {
                if(item.name =="Type C")  item.gameObject.GetComponent<TMP_Text>().text ="Clima"; 
            }
            else if( card is Increase)
            {
                if(item.name =="Type C")  item.gameObject.GetComponent<TMP_Text>().text ="Aumento"; 
            }  
            else if( card is BossCard bossCard)
            {
                if(item.name =="Type C")  item.gameObject.GetComponent<TMP_Text>().text ="Lider"; 
                else if(item.name =="Power")  item.GetChild(0).gameObject.GetComponent<TMP_Text>().text = bossCard.Power.ToString();

            } 

           }
    }

     
}
