using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

    public Material forms;
    public Material Plataform;
    public Color final;
    
   
	void Start ()
    {
       forms.color = Random.ColorHSV(0f, 1f, 0.9f, 0.9f, 0.8f, 0.8f,0.5f, 0.5f);
       Plataform.color = Random.ColorHSV(0f, 1f, 0.9f, 0.9f, 0.8f, 0.8f, 0.5f, 0.5f);
        
    }
}
