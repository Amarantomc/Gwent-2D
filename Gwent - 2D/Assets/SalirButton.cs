using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalirButton : MonoBehaviour
{
     
     public void OnClick()
     {
        SceneManager.LoadScene("StartMenu");

     }
}
