using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestarGame : MonoBehaviour
{
     public GameObject canvas;
    public void Onclick(){
        canvas.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
