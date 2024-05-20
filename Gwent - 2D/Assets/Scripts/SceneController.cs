using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
     public TextMeshProUGUI textProgres;
     public Slider slider;

     private AsyncOperation loadAsync;

     private float currentPercent;

     public TextMeshProUGUI text;
     
    
    void Start(){
        LoadScene();
    }
     public void LoadScene(){
        StartCoroutine(Load("Game"));
     }
     public IEnumerator Load(string name){
      textProgres.text="Loading... 00%";
      
       loadAsync= SceneManager.LoadSceneAsync(name);
       loadAsync.allowSceneActivation=false;
        while(!loadAsync.isDone){
             
        currentPercent =loadAsync.progress*100/0.9f;
        textProgres.text="Loading... "+currentPercent.ToString("00")+"%";
        yield return null;
            
        }
     }

     void Update(){
         slider.value=Mathf.MoveTowards(slider.value,currentPercent,100*Time.deltaTime);
         if(loadAsync!=null && slider.value>=100){
           text.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space)){
              loadAsync.allowSceneActivation=true;
              
         }
         }
         
        
     }
}
