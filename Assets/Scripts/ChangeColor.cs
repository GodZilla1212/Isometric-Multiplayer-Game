using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

    public Material forms;
    public Material Plataform;
    public Color final;
    private Color TopBaseColor;
    private Color BottomBaseColor;
   // private Vector4 plusOfColor = new Vector4();
    
   
	void Start ()
    {
        TopBaseColor = Random.ColorHSV(0f, 1f, 0.25f, 0.65f);
        BottomBaseColor = Random.ColorHSV(0f, 1f, 0.25f, 0.65f);

        
        //forms.SetColor("_BottomColor", BottomBaseColor);       
        //RenderSettings.skybox.SetColor("_Color1", BottomBaseColor);

    }

    private void Update()
    {
        forms.SetColor("_TopColor", TopBaseColor);
        forms.SetColor("_FrontTopColor", TopBaseColor);
        RenderSettings.skybox.SetColor("_Color2", TopBaseColor * BottomBaseColor);
    }
}
