using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour {

    [System.Serializable]
    public class BasicForms
    {
        public GameObject form;
        public int widthDimention;
        public int heigthDimention;
    }

    public int width = 20;
	public int height = 20;
  
    [SerializeField]
    public List<BasicForms> forms;
    public NavMeshSurface surface;
	//public GameObject player;
    
	//private bool playerSpawned = false;

	
	void Start () {
		GenerateLevel();
        surface.BuildNavMesh();
	}
	
	
	void GenerateLevel()
	{
		// Loop over the grid
		for (int x = 0; x <= width; x+=4)
		{
			for (int y = 0; y <= height; y+=4)
			{
				// Should we place a wall?
				if (Random.value > 0.7f)
				{
                    int index = Random.Range(0, forms.Count);
                    BasicForms item = forms[index];

                    if (index > 0)
                    {
                        Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f);
                        Instantiate(item.form, pos,item.form.transform.rotation);
                    }
                    else
                    {
                        Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f);
                        Instantiate(item.form, pos, item.form.transform.rotation);
                    }
					
				}
                /*else if (!playerSpawned) // Should we spawn a player?
				{
					// Spawn the player
					Vector3 pos = new Vector3(x - width / 2f, 1.25f, y - height / 2f);
					Instantiate(player, pos, Quaternion.identity);
					playerSpawned = true;
				}*/
			}
		}
	}

}
