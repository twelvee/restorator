using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticProps : MonoBehaviour {
	public GameObject CashBox;
	public GameObject Table1;
	public GameObject chair_1;
	public GameObject modular_kitchen_table_1;
	public GameObject modular_kitchen_table_2;
	public GameObject coffee_table_4;
	public GameObject pouf;
	public GameObject pouf_2;
	public GameObject pouf_3;
	public GameObject pouf_4;
	public GameObject toilet;
	public GameObject toilet_2;
	public GameObject cash_register;

	public GameObject mirror_1;
	public GameObject door_1;
	public static StaticProps Instance;

	void Awake(){
		Instance = this;
	}
}
