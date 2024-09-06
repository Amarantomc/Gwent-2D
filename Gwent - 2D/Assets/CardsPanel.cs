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
        Sprite sprite=Resources.Load<Sprite>("Sprites/Default_Personaje_Rick_de_la_serie_animada_Rick_and_Morty_esti_3");
        foreach (var card in CompilerButton.Instance.Cards)
        {  
            GameObject cardObject = Instantiate(prefabCard,new Vector3(0,0,0),Quaternion.identity);
            cardObject.transform.SetParent(CardPanel.transform,false);
             cardObject.gameObject.GetComponent<data>().card=card;
           
           SetCompilerCard(cardObject,card,sprite);
          
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
                    var effect= unitsCard.Effect as CompilerEffects;
                    item.gameObject.GetComponent<TMP_Text>().text = effect.Values[0].Item1;
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
            else if( card is BossCard)
            {
                if(item.name =="Type C")  item.gameObject.GetComponent<TMP_Text>().text ="Lider"; 
            } 

           }
    }

     
}
