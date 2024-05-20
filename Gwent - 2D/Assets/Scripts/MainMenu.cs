using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
     public GameObject panel;

     public void ExitButton(){
        EditorApplication.isPlaying = false;
         
     }

     public void StartGame(){
        panel.SetActive(true);
         
     }
}
