using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorPoints : MonoBehaviour {

    public ChangeColor Othercolor;
    


    void Start ()
    {
        if (GetComponent<TextMesh>() == null)
        {
            GetComponent<Camera>().backgroundColor = Othercolor.forms.color;
        }
        else
        {
            GetComponent<TextMesh>().color = Othercolor.forms.color;
            
        }
        
		
	}
	
	
	void Update () {
		
	}
}
