using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class lvl_create : MonoBehaviour{
	
	public int lvl_length;
	public float size_block;
	public GameObject[] blocks;
	public GameObject block_rot;
	public GameObject finish_g;
	public GameObject g_none;
	public GameObject player;
	public Vector3[] positions;
	int max_blocks_now = 2;
	
	void Start(){
		positions = new Vector3[lvl_length];
		int max_rot = UnityEngine.Random.Range(1,3);
		Vector3 pos = new Vector3(0,0,0);
		int dir = 0;
		int rot_1;
		int rot_2;
		int rot_1_to = 2;//0 left, 1 right		
		int rot_2_to = 2;//0 left, 1 right
		
		if(max_rot==2){
			int t = UnityEngine.Random.Range(0,1000);
			System.Random rnd = new System.Random(t);
			rot_1 = rnd.Next(5,lvl_length-5);
			rnd = new System.Random(t+1);
			rot_2 = rnd.Next(5,lvl_length-5);
			//Debug.Log(rot_1 + " " + rot_2);
		}else{
			rot_1 = UnityEngine.Random.Range(5,lvl_length-5);
			rot_2 = lvl_length*2;
			//Debug.Log(rot_1);
		}
		
		
		
		Vector3 last_pos = pos;
		for(int i=0; i<lvl_length; i++){
			positions[i] = pos;
			if((i == rot_1)||(i == rot_2)){
				int r1 = 2;
				if(i == rot_1){
					r1=0;
				}else{
					r1=1;
				}
				
				switch (dir){
					case 0:
						dir = UnityEngine.Random.Range(1,3);
						if(dir == 1){							
							if(r1==0){
								rot_1_to = 1;//
							}else{
								rot_2_to = 1;//
							}
							pos += new Vector3(size_block,0,size_block);
						}else{
							if(r1==0){
								rot_1_to = 0;//
							}else{
								rot_2_to = 0;//
							}
							pos += new Vector3(-size_block,0,size_block);
						}
					break;				
					case 1:
						rot_1_to = 1;//
						rot_2_to = 0;//
						dir = 0;
						pos += new Vector3(size_block,0,size_block);
					break;
					case 2:
						rot_1_to = 0;//
						rot_2_to = 1;//
						dir = 0;
						pos += new Vector3(-size_block,0,size_block);
					break;
				}
			}
			spawn_pref_controll(i,pos,dir);
			switch (dir){
				case 0://z+
					pos += new Vector3(0,0,size_block);
				break;
				case 1://x+
					pos += new Vector3(size_block,0,0);
				break;
				case 2://x-
					pos += new Vector3(-size_block,0,0);
				break;
			}
		}
		
		Vector3 fin_pos = pos;
		
		switch (dir){
			case 0://z+
				Instantiate(finish_g, fin_pos, Quaternion.Euler(0,0,0));
				// fin_pos+= new Vector3(0,0,43);
			break;
			case 1://x+
				Instantiate(finish_g, fin_pos, Quaternion.Euler(0,90,0));
				// fin_pos+= new Vector3(43,0,0);
			break;
			case 2://x-
				Instantiate(finish_g, fin_pos, Quaternion.Euler(0,-90,0));
				// fin_pos+= new Vector3(-43,0,0);
			break;
		}
		
		Vector3 test_rot_1 = new Vector3(0,0,0);
		Vector3 test_rot_2 = new Vector3(0,0,0);
		
		spawn_rot(rot_1,rot_2,max_rot,rot_1_to,rot_2_to);
		if(max_rot==2){
			
			test_rot_1 = positions[rot_1];
			test_rot_2 = positions[rot_2];
			
			if(rot_1>rot_2){
				//Debug.Log("----");
				Vector3 t12323 = test_rot_2;
				test_rot_2 = test_rot_1;
				test_rot_1 = t12323;
			}
			
			
			player.GetComponent<player>().get_info(max_rot,rot_1,rot_2,test_rot_1,test_rot_2,rot_1_to,rot_2_to,fin_pos);
		}else{			
			test_rot_1 = positions[rot_1];
			
			player.GetComponent<player>().get_info(max_rot,rot_1,rot_2,test_rot_1,positions[0],rot_1_to,rot_2_to,fin_pos);
		}
	}
	void spawn_rot(int rot_1,int rot_2,int max_rot,int rot_1_to,int rot_2_to){
		if(rot_1>rot_2){
			int t123 = rot_2;
			rot_2 = rot_1;
			rot_1 = t123;
		}
		
		int t2 = 0;
		
		GameObject pref = Instantiate(block_rot, positions[rot_1], Quaternion.Euler(0,0,0));
		if(rot_1_to==0){
			pref.transform.localScale = new Vector3(-1,1,1);
			t2 = -90;
		}else{
			t2 = 90;				
		}
		pref.name = "rot_1";
		if(max_rot==2){
			GameObject pref2 = Instantiate(block_rot, positions[rot_2], Quaternion.Euler(0,t2,0));
			if(rot_2_to==0){
				pref2.transform.localScale = new Vector3(-1,1,1);
			}
			pref2.name = "rot_2";
		}
		
		//Debug.Log(rot_1_to+" "+rot_2_to+" "+max_rot);
		
	}
	void spawn_pref_controll(int i,Vector3 pos, int dir_b){
		//Debug.Log(i +" "+ max_blocks_now);
		if(i>1){//start
			int type_b;
			if(max_blocks_now<=2){
				type_b = 3;
				max_blocks_now+=2;
				spawn_pref(pos,dir_b,type_b,0);
			}else{
				int x1 = UnityEngine.Random.Range(0,4);//3
				x1*=2;
				if(x1>2){
					x1 = 2;
				}
				
				if(x1==2){
					type_b = UnityEngine.Random.Range(0,3);
					if((type_b==1)||(type_b==2)){
						int x3 = UnityEngine.Random.Range(0,3);
						if(x3==0){
							spawn_pref(pos,dir_b,type_b,0);
							max_blocks_now-=1;
						}else{
							spawn_pref(pos,dir_b,type_b,2);
							max_blocks_now-=2;
						}
					}else{
						spawn_pref(pos,dir_b,type_b,2);
						max_blocks_now-=2;
					}
				}else{
					int x2 = UnityEngine.Random.Range(0,3);
					if(x2!=0){
						type_b = 0;
						spawn_pref(pos,dir_b,type_b,0);
					}else{
						type_b = 3;
						spawn_pref(pos,dir_b,type_b,0);
						max_blocks_now+=2;
					}
				}				
				//type_b = UnityEngine.Random.Range(0,blocks.Length);
				
				//spawn_pref(pos,dir_b,type_b,0);				
			}
			
		}else{
			Instantiate(blocks[0], pos, Quaternion.Euler(0,0,0));
		}
	}
	void spawn_pref(Vector3 pos, int dir, int type_b, int block_info_del){
		GameObject pref = g_none;
		switch (dir){
			case 0://z+
				pref = Instantiate(blocks[type_b], pos, Quaternion.Euler(0,0,0));
			break;
			case 1://x+
				pref = Instantiate(blocks[type_b], pos, Quaternion.Euler(0,90,0));
			break;
			case 2://x-
				pref = Instantiate(blocks[type_b], pos, Quaternion.Euler(0,-90,0));
			break;
		}
		pref.GetComponent<spawn_wall>().wall_summon(block_info_del);
		pref.transform.SetParent(transform);
		if(block_info_del>0){
			//Debug.DrawLine(pos,pos+new Vector3(0,5,0));
		}
		//UnityEngine.Random.Range(0,blocks.Length);
		//Instantiate(UnityEngine.Random.Range(0,blocks.Length), pos, Quaternion.Euler(0,0,0));//transform.eulerAngles.z;
	}
}