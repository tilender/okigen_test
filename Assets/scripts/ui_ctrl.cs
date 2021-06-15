using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_ctrl : MonoBehaviour{
	
	public GameObject start;
	public GameObject rest;
	public GameObject cont;	
	public GameObject coin_g;
	
	public Text money_txt;	
	public Text g_money_txt;
	
	public player pl_s;
	
	void Update(){
		g_money_txt.text = pl_s.money.ToString();
		if(Input.GetKey(KeyCode.Mouse0)){
			start.gameObject.SetActive(false);
			coin_g.gameObject.SetActive(true);				
		}
	}
	
	public void rest_i(){
		rest.gameObject.SetActive(true);	
	}
	
	public void cont_i(int money){
		cont.gameObject.SetActive(true);
		coin_g.gameObject.SetActive(false);	
		money_txt.text = money.ToString()+" coins";
	}
	
	public void restart(){
		Application.LoadLevel("SampleScene");
	}
	
}