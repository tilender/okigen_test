using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class green_rnd : MonoBehaviour{
	
	public GameObject green_pref;
	
	void Start(){
		int x = UnityEngine.Random.Range(0,3);//0-2
		if(x==0){//3
			int x2 = UnityEngine.Random.Range(0,2);//0-1
			if(x2==0){//2
				int t = UnityEngine.Random.Range(0,1000);
				System.Random rnd = new System.Random(t);
				int z_1 = rnd.Next(1,5);
				rnd = new System.Random(t+1);
				int z_2 = rnd.Next(1,5);				
				float x_1 = UnityEngine.Random.Range(0,4)-1.5f;				
				float x_2 = UnityEngine.Random.Range(0,4)-1.5f;
				GameObject pref = Instantiate( green_pref, transform.position, Quaternion.Euler(0,0,0) );
				pref.transform.SetParent(transform);
				pref.transform.localPosition = new Vector3(x_1,1.5f,z_1);
				pref = Instantiate( green_pref, transform.position, Quaternion.Euler(0,0,0) );
				pref.transform.SetParent(transform);
				pref.transform.localPosition = new Vector3(x_1,2.5f,z_1);
				pref = Instantiate( green_pref, transform.position, Quaternion.Euler(0,0,0) );
				pref.transform.SetParent(transform);
				pref.transform.localPosition = new Vector3(x_2,1.5f,z_2);
			}else{//1
				int z_1 = UnityEngine.Random.Range(1,5);
				float x_1 = UnityEngine.Random.Range(0,4)-1.5f;
				GameObject pref = Instantiate( green_pref, transform.position, Quaternion.Euler(0,0,0) );
				pref.transform.SetParent(transform);
				pref.transform.localPosition = new Vector3(x_1,1.5f,z_1);
				pref = Instantiate( green_pref, transform.position, Quaternion.Euler(0,0,0) );
				pref.transform.SetParent(transform);
				pref.transform.localPosition = new Vector3(x_1,2.5f,z_1);
				pref = Instantiate( green_pref, transform.position, Quaternion.Euler(0,0,0) );
				pref.transform.SetParent(transform);
				pref.transform.localPosition = new Vector3(x_1,3.5f,z_1);
			}
		}else{//2
			int x2 = UnityEngine.Random.Range(0,2);//0-1
			if(x2==0){//2
				int t = UnityEngine.Random.Range(0,1000);
				System.Random rnd = new System.Random(t);
				int z_1 = rnd.Next(1,5);
				rnd = new System.Random(t+1);
				int z_2 = rnd.Next(1,5);				
				float x_1 = UnityEngine.Random.Range(0,4)-1.5f;				
				float x_2 = UnityEngine.Random.Range(0,4)-1.5f;
				GameObject pref = Instantiate( green_pref, transform.position, Quaternion.Euler(0,0,0) );
				pref.transform.SetParent(transform);
				pref.transform.localPosition = new Vector3(x_1,1.5f,z_1);
				pref = Instantiate( green_pref, transform.position, Quaternion.Euler(0,0,0) );
				pref.transform.SetParent(transform);
				pref.transform.localPosition = new Vector3(x_2,1.5f,z_2);
			}else{//1
				int z_1 = UnityEngine.Random.Range(1,5);
				float x_1 = UnityEngine.Random.Range(0,4)-1.5f;
				GameObject pref = Instantiate( green_pref, transform.position, Quaternion.Euler(0,0,0) );
				pref.transform.SetParent(transform);
				pref.transform.localPosition = new Vector3(x_1,1.5f,z_1);
				pref = Instantiate( green_pref, transform.position, Quaternion.Euler(0,0,0) );
				pref.transform.SetParent(transform);
				pref.transform.localPosition = new Vector3(x_1,2.5f,z_1);
			}
		}
	}
	
}
