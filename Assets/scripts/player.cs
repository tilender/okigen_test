using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour{
	
	public ui_ctrl uct;
	
	public int block;
	public GameObject block_pref;
	public List<GameObject> blocks;
	public GameObject hero;
	public GameObject hero_x;
	public int block_now;
	
	public int g_max_rot;
	public int g_rot_1;
	public int g_rot_2;
	public Vector3 g_pos_1;
	public Vector3 g_pos_2;
	public Vector3 g_fin_pos;
	public int g_rot_1_to;
	public int g_rot_2_to;
	
	public int now_pos = 0;//0 0-rot_1 //1 rot_1-rot_2 //3 rot_2+
	
	public bool created;
	public bool started;
	public bool finished;	
	public bool finished2;
	
	public bool now_rotation;
	
	public float speed;
	public float speed_rot;
	
	public GameObject now_rot_pos;
	
	[Range(-1f,1f)]
	public float x_pos;
	//float last_x_pos;
	public float width_road;
	
	public touch_info s_t_i;
	public float koef_t;
	
	public int money;
	
	public void add_block(){
		block++;
		GameObject pref = Instantiate(block_pref,hero_x.transform.position + new Vector3(0,block+0.5f,0),Quaternion.Euler(0,0,0));
		pref.transform.SetParent(hero_x.transform);
		blocks.Add(pref);
		
	}
	
	public void dell_block(){
		Destroy(blocks[blocks.Count-1]);
		blocks.Remove(blocks[blocks.Count-1]);
		block--;
	}
	
	public void get_info(int max_rot,int rot_1,int rot_2,Vector3 pos_1,Vector3 pos_2,int rot_1_to,int rot_2_to,Vector3 fin_pos){
		g_max_rot = max_rot;
		g_rot_1 = rot_1;
		g_rot_2 = rot_2;
		g_pos_1 = pos_1;
		g_pos_2 = pos_2;
		g_rot_1_to = rot_1_to;
		g_rot_2_to = rot_2_to;		
		g_fin_pos = fin_pos;
		
		g_start();
	}
	
	void g_start(){
		//last_x_pos = 0;
		x_pos = 0;
		created = true;
	}
	
	void do_rot(int n_r){
		now_rotation = true;
		Invoke("end_rot",((90/speed_rot)*0.02f));
		now_rot_pos = GameObject.Find("rot_" + n_r).GetComponent<rot_info>().pos;
		transform.SetParent(now_rot_pos.transform);
	}
	
	void end_rot(){
		now_rotation = false;
	}
	
	void FixedUpdate(){
		
		if(created){
			if(Input.GetKey(KeyCode.Mouse0)){
				started = true;
				created = false;
			}
		}
		
		int x1 = 0;
		
		if(g_rot_1_to==0){//0 left, 1 right
			x1 = -1;
		}else{
			x1 = 1;
		}
		if(!finished){
			if(!now_rotation){
				if(started){
					if(now_pos == 0){
						if(transform.position.z<g_pos_1.z){
							transform.position+=new Vector3(0,0,speed);
						}else{
							//Debug.Log("rot 1");					
							now_pos = 1;
							do_rot(1);
						}
					}else{
						if(g_max_rot==2){
							if(now_pos == 1){
								if(Mathf.Abs(transform.position.x)<Mathf.Abs(g_pos_2.x)){
									transform.position+=new Vector3(speed*x1,0,0);
								}else{
									//Debug.Log("rot 2");					
									now_pos = 2;
									do_rot(2);
								}
							}else{
								if(now_pos == 2){
									if(transform.position.z<g_fin_pos.z){
										transform.position+=new Vector3(0,0,speed);
									}else{
										transform.position = new Vector3(transform.position.x,transform.position.y,g_fin_pos.z);
										finished=true;
									}
								}
							}
						}else{
							if(Mathf.Abs(transform.position.x)<Mathf.Abs(g_fin_pos.x)){
								transform.position+=new Vector3(speed*x1,0,0);
							}else{
								transform.position = new Vector3(g_fin_pos.x,transform.position.y,transform.position.z);
								finished=true;
							}
						}
						
					}
				}
				
				
				
				
				
			}else{
				//rot
				now_rot_pos.transform.localRotation = Quaternion.Euler(0,now_rot_pos.transform.localEulerAngles.y+speed_rot,0);
			}
		}else{
			//fin
			if(!finished2){
				float x2;
				if(block_now<11){
					x2 = 1.5f + 3*(block_now-1);
				}else{
					x2 = 35f;
				}
				if(g_max_rot==2){
					if(transform.position.z<g_fin_pos.z+x2){
						transform.position+=new Vector3(0,0,speed);
					}else{
						finished2 = true;
						coin_x();
					}
				}else{
					if(Mathf.Abs(transform.position.x)<Mathf.Abs(g_fin_pos.x) + x2){
						transform.position+=new Vector3(speed*x1,0,0);
					}else{
						finished2 = true;
						coin_x();
					}
				}
				
				
			}
			//Invoke("reload_lvl",1f);
		}
		
		x_pos+=s_t_i.touch_p_ch*koef_t;
		
		if(x_pos<-1){
			x_pos = -1;
		}else{
			if(x_pos>1){
				x_pos = 1;
			}
		}
		
		//Debug.Log((last_x_pos-x_pos)*(width_road/2));
		if(started){
			if(!finished){
				hero_x.transform.localPosition = new Vector3((x_pos*(width_road/2)),0,0);
			}else{
				hero_x.transform.localPosition = new Vector3(Mathf.Lerp(hero_x.transform.localPosition.x,0,0.05f),0,0);
			}
		}
		//last_x_pos = x_pos;
		
		if(block_now==0){
			//reload_lvl();
			started = false;
			uct.rest_i();
		}
		
	}
	void reload_lvl(){
		Application.LoadLevel("SampleScene");
	}
	
	void coin_x(){
		//if(block_now<11){
			//Debug.Log(money);
			//money*=1+(block_now-1)*0.5;
			//Debug.Log(money);
		//}else{
			//Debug.Log(money);
			//money*=5;
			//Debug.Log(money);
		//}
		uct.cont_i(money);
	}
	
	void Update(){
		
		
		if(Input.GetKeyDown(KeyCode.Space)){
			//reload_lvl();
		}
		if(block_now<0){
			block_now = 0;
		}
		if(block_now>block){
			add_block();			
		}		
		if(block_now<block){
			dell_block();			
		}
		hero.transform.localPosition = new Vector3(0,block+0.5f,0);
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "add_block"){
			Destroy(other.gameObject);
			block_now++;
		}
		if (other.gameObject.tag == "coin"){
			Destroy(other.gameObject);
			money++;
		}
		if (other.gameObject.tag == "wall"){
			//Destroy(other.gameObject);
			block_now--;
		}
	}
	
}