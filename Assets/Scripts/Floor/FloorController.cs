using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {

	public GameObject floorTexture;
	public GameObject wallTexture;
	public LayerMask floorLayer;

	public int sizeLeft;
	public int sizeRight;
	public int sizeBlock;
	public static bool allowFloorClick = true;
	private GridController grid;
	public static GameObject curObject = null;
	public static GameObject prevObject = null;
	public static string prevGrid = "";
	// Use this for initialization
	void Start () {
		GuiManager.Instance.PropMenu.SetActive (false);
		grid = new GridController ();
		grid.createGrid (sizeLeft,sizeRight,sizeBlock);
		grid.spawnFloor (floorTexture);
		grid.spawnWalls (wallTexture);
		spawnDefault ();
	}

	void spawnDefault(){
		PropController.create (StaticProps.Instance.modular_kitchen_table_1, "12", new Vector3(-90,0,-90), 0.5F);
		PropController.create (StaticProps.Instance.modular_kitchen_table_1, "13", new Vector3(-90,0,-90), 0.5F);
		PropController.create (StaticProps.Instance.cash_register, "13", new Vector3(-90,0,0), 8.5F);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			if (allowFloorClick) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
				{
					if(prevObject!=null)
						prevObject.GetComponent<Renderer> ().material.color = Color.white;
					if (hit.collider.gameObject.name.StartsWith ("floor_")) {
						string key = hit.collider.gameObject.name.Replace ("floor_", "");
						curObject = GridController.floor[key];
						prevGrid = key;
						Debug.Log (key);
						if (curObject == null) {
							hit.collider.gameObject.GetComponent<Renderer> ().material.color = Color.green;
							GuiManager.Instance.setGrid (key);
							allowFloorClick = false;
							GuiManager.Instance.PropMenu.SetActive (true);
							GuiManager.rotateButtonActive = false;
						} else {
							hit.collider.gameObject.GetComponent<Renderer> ().material.color = Color.red;
							GuiManager.Instance.setGrid (key);
							GuiManager.rotateButtonActive = true;
						}
					}
					if (hit.collider.gameObject.name.StartsWith ("wall_")) {
						string key = hit.collider.gameObject.name.Replace ("wall_", "");
						curObject = GridController.walls[key];
						prevGrid = key;
					}
					prevObject = hit.collider.gameObject;

				}
			}
		}
	}
}
