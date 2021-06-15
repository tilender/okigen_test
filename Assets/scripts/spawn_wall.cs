using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_wall : MonoBehaviour{
	
	public GameObject[] walls;
	public GameObject coin;
	public bool c;
	public bool lr;
	public bool ll;
	
	public void wall_summon(int height){
		if(height>0){
			
			
			GameObject pref = Instantiate(walls[UnityEngine.Random.Range(0,walls.Length)],transform.position,Quaternion.Euler(0,0,0));
			
			pref.transform.SetParent(transform);
			pref.transform.localRotation = Quaternion.Euler(0f,0f,0f);
			
			int t = UnityEngine.Random.Range(0,1000);
			System.Random rnd = new System.Random(t);
			int x0 = rnd.Next(1,5);
			rnd = new System.Random(t+1);
			int x1 = rnd.Next(1,5);
			pref.transform.localPosition = new Vector3(0,0,x0);
			if(x0 == x1){
				if(x0 == 1){
					x1++;
				}else{
					x1--;
				}
			}
			if(c){
				
				pref = Instantiate(coin,transform.position,Quaternion.Euler(0,0,0));
				pref.transform.SetParent(transform);
				pref.transform.localRotation = Quaternion.Euler(0f,0f,0f);
				if(lr){
					pref.transform.localPosition = new Vector3((UnityEngine.Random.Range(0,2)+0.5f),0.6f,x1);
				}else{
					if(ll){
						pref.transform.localPosition = new Vector3((UnityEngine.Random.Range(0,2)-1.5f),0.6f,x1);
					}else{
						pref.transform.localPosition = new Vector3((UnityEngine.Random.Range(0,4)-1.5f),0.6f,x1);
					}
				}
			}
		}
	}
}