 using UnityEngine;
using System.IO;
using UnityEditor;

public class LoadButton : MonoBehaviour
{
      public void LoadFile()
    {
        string path = EditorUtility.OpenFilePanel("Cargar archivo Gwent", "", "gwent");
        var input=CompilerButton.Instance.Input;
        if (!string.IsNullOrEmpty(path))
        {
            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                Debug.Log("Archivo cargado desde: " + path);
                 input.text=content;
                 return;
            }
            else
            {
                Debug.LogError("El archivo no existe.");
                 return;
            }
        }
        return;
    }
}

