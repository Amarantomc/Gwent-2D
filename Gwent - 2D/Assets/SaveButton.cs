 using UnityEngine;
using System.IO;
using UnityEditor;

public class SaveButton : MonoBehaviour
{
    public static void SaveFile()
    {
        string path = EditorUtility.SaveFilePanel("Guardar archivo Gwent", "", "archivo.gwent", "gwent");
        string content=CompilerButton.Instance.Input.text;
        if (!string.IsNullOrEmpty(path))
        {
            // Verificar si el archivo ya existe
            if (File.Exists(path))
            {
                // Aquí puedes mostrar un mensaje de advertencia o manejar la lógica de tu elección
                if (EditorUtility.DisplayDialog("Archivo existente", "El archivo ya existe. ¿Deseas sobrescribirlo?", "Sí", "No"))
                {
                    File.WriteAllText(path, content);
                    Debug.Log("Archivo sobrescrito en: " + path);
                }
                else
                {
                    Debug.Log("Operación cancelada por el usuario.");
                }
            }
            else
            {
                File.WriteAllText(path, content);
                Debug.Log("Archivo guardado en: " + path);
            }
        }
    }
}

