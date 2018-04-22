using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorPoints : MonoBehaviour {

    public ChangeColor Othercolor;
    


    void Start ()
    {
        if (GetComponent<TextMesh>() == null)
        {
            GetComponent<Camera>().backgroundColor = Othercolor.forms.GetColor("_TopColor") * 0.1f;
        }
        else
        {
            GetComponent<TextMesh>().color = Othercolor.forms.GetColor("_TopColor") * 0.1f;
            
        }
        
		
	}
	

}
