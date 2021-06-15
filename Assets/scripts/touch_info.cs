using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch_info : MonoBehaviour{
	
	public float touch_x;
	public float sw;
	public float touch_x_p;
	float last_touch_x_p;
	public float touch_p_ch;
	
	void Update(){
		
		sw = Screen.width;
		
		if(Input.GetKey(KeyCode.Mouse0)){
			
			touch_x = Input.mousePosition.x;//Screen.width
			touch_x_p = touch_x/sw;
			if(last_touch_x_p!=0){
				touch_p_ch = touch_x_p - last_touch_x_p;
			}
			last_touch_x_p = touch_x_p;
			
		}else{
			
			touch_x = 0;
			touch_x_p = 0;
			touch_p_ch = 0;
			last_touch_x_p = 0;
			
		}
		
		
		
		
	}
	
}