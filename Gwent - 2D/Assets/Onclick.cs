using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onclick : MonoBehaviour
{
    // Start is called before the first frame update
     private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    Debug.Log("Objeto clickeado!");
                }
            }
        }
    }
}
