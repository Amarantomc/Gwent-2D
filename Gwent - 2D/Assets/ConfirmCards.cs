using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmCards : MonoBehaviour
{
    public GameObject CardsPlayer1;

    public GameObject CardsPlayer2;

    public void Onclick()
    {
        if(CardsPlayer1.transform.childCount!=0)
        {   
            
            foreach (Transform item in CardsPlayer1.transform)
            {
                 item.gameObject.GetComponent<data>().card.Owner=1;
                PlayerManager.Instance.CompilerCardsPlayer1.Add(item.gameObject.GetComponent<data>().card);
                //PlayerManager.Instance.Player1.Hand.RemoveAt(0);
                //PlayerManager.Instance.Player1.Hand.Add(item.gameObject.GetComponent<data>().card);
            }
        }

        if(CardsPlayer2.transform.childCount!=0)
        {   
             
            foreach (Transform item in CardsPlayer2.transform)
            {
                item.gameObject.GetComponent<data>().card.Owner=2;
                PlayerManager.Instance.CompilerCardsPlayer2.Add(item.gameObject.GetComponent<data>().card);
            }
        }

        SceneManager.LoadScene("Game");
    }
}
