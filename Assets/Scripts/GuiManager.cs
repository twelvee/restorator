using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GuiManager : MonoBehaviour {

	public GameObject PropMenu;
	public Button BlackToilet;
	public Button WhiteToilet;
	public Button BluePouf;
	public Button WhitePouf;
	public Button GreenPouf;
	public Button GoldPouf;

	private string grid = "";
	private GameObject rotateObject = null;
	public static bool rotateButtonActive = false;
	public static GuiManager Instance;
	void Awake(){
		//rotateButton = GetComponent<Button> ();
		Instance = this;
		BlackToilet.onClick.AddListener(() => Placer("toilet"));
		WhiteToilet.onClick.AddListener(() => Placer("toilet_2"));
		WhitePouf.onClick.AddListener(() => Placer("pouf"));
		GoldPouf.onClick.AddListener(() => Placer("pouf_2"));
		GreenPouf.onClick.AddListener(() => Placer("pouf_3"));
		BluePouf.onClick.AddListener(() => Placer("pouf_4"));

	}
	void OnGUI() // deprecated, use ordinary .UI now available in Unity
	{
		if (rotateButtonActive){
			GUIStyle style = new GUIStyle ();
			style.fontSize = 42;
			style.fontStyle = FontStyle.Bold;
			if (GUI.Button (new Rect (50, 50, 50, 50), "↺", style)) {
				rotateObject = GridController.floor[grid];
				rotateObject.transform.Rotate (new Vector3(0,0,90));
				//rotateObject.transform.rotation.z = rotateObject.transform.rotation.z+90;
			}
		}
	}
	public void setGrid(string ng){
		grid = ng;
	}

	public void Placer(string name){
		PropMenu.SetActive (true);
		switch (name)
		{
		/*
		PropController.create (StaticProps.Instance.toilet_2, 55, new Vector3(-90,0,0), 0.5F);
		PropController.createOnWall (StaticProps.Instance.door_1, 9, new Vector3(0,90,180), -10, 1F);
		PropController.createOnWall (StaticProps.Instance.mirror_1, 10, new Vector3(90,-90,90),5, -0.5F, 1F);
		*/
		case "toilet":
			PropController.create (StaticProps.Instance.toilet, grid, new Vector3(-90,0,-90), 0.5F);
			break;
		case "toilet_2":
			PropController.create (StaticProps.Instance.toilet_2, grid, new Vector3(-90,0,0), 0.5F);
			break;
		case "pouf":
			PropController.create (StaticProps.Instance.pouf, grid, new Vector3(-90,0,0), 0.5F);
			break;
		case "pouf_2":
			PropController.create (StaticProps.Instance.pouf_2, grid, new Vector3(-90,0,0), 0.5F);
			break;
		case "pouf_3":
			PropController.create (StaticProps.Instance.pouf_3, grid, new Vector3(-90,0,0), 0.5F);
			break;
		case "pouf_4":
			PropController.create (StaticProps.Instance.pouf_4, grid, new Vector3(-90,0,0), 0.5F);
			break;
		default:
			
			break;
		}
		PropMenu.SetActive (false);
		rotateButtonActive = true;
		FloorController.allowFloorClick = true;
	}
}
