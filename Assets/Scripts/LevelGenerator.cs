using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour {

    [System.Serializable]
    public class BasicForms
    {
        public string nameFigure;
        public Transform figure;
        private Vector3 limitFigure;

       public void setLimit(Vector3 limitFigure)
        {
            this.limitFigure = limitFigure;
        }     
    }

    public int width = 20;
	public int height = 20;
    public Transform enviroment;
  
    [SerializeField]
    public List<BasicForms> forms;

    public NavMeshSurface surface;
	//public GameObject player;
    
	//private bool playerSpawned = false;

	
	void Start () {
        CreateFigure();
        surface.BuildNavMesh();
	}


    void CreateFigure()
    {
        foreach (BasicForms item in forms)
        {
            MeshRenderer mesh;
           if(item.figure.childCount == 0)
            {
                mesh = item.figure.gameObject.GetComponent<MeshRenderer>();
            }
            else
            {
                mesh = item.figure.GetChild(0).gameObject.GetComponent<MeshRenderer>();
            }

            Transform instansceObject = Instantiate(item.figure, new Vector3(0.0f, 1.5f, 0.0f), transform.rotation);
            instansceObject.SetParent(enviroment);

            item.setLimit(new Vector3(mesh.bounds.extents.x * 2, mesh.bounds.extents.y, mesh.bounds.extents.z * 2));

            print(mesh.bounds);
   

        }
    }

}
