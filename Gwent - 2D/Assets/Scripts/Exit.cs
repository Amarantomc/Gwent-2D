using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject canvas;
     public void Onclick(){
        canvas.SetActive(false);
        EditorApplication.isPlaying = false;
     }
}
