using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gwent;
using System.Linq;
using Logic;
using TMPro;

public class CompilerButton : MonoBehaviour
{
        public TMP_InputField Input;
        public List<Card> Cards;

        public static CompilerButton Instance;
        void Awake()
        {
          Cards=new List<Card>();
          Instance=this;
        }
        
        
        public void Compile( )
     {
         Cards=new List<Card>();
         
        try
        {
          var tree=SyntaxTree.Parse(Input.text); 
          
          if( Error.ErrorList.Any())
          {
             string error="";
             foreach (var item in Error.ErrorList)
             {
                error+=item.Type+" " +  item.Text + " in "+ item.Position+ " position" +"\n";
             }
              
             Input.textComponent.color=Color.red;
             Input.text=error;
             return;
          } 

          try
          {
            List<Card> aux=tree.Visitor();
             foreach (var item in aux)
             {
               Cards.Add(item);
             }
          }
          catch (System.Exception e)
          {
             Input.textComponent. color=Color.red;
             Input.text=e.ToString();
             
          }
        }
        catch (System.Exception e)
        {
            
             Input.textComponent. color=Color.red;
             Input.text=e.ToString();
        }
           Instance=this;
     }
        
         
}
