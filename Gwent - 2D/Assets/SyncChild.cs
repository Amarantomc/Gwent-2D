using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SyncChild : MonoBehaviour
{
     private Transform parentTransform;
     private List<Transform> childsTransform;
    void Start()
    {
        childsTransform= new List<Transform>();
        parentTransform=transform;
        foreach (Transform item in transform)
        {
            childsTransform.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(childsTransform.Any())
        {
            foreach (Transform item in childsTransform)
            {
                item.localScale=parentTransform.localScale;
                
                
            }
        }
    }
}
