using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	float posX;
	float posZ;  

    void Start()
    {
        Rigidbody r = GetComponent<Rigidbody>();         
		r.velocity = transform.up*-50f;
    }

    void Update()
    {
        Rigidbody r = GetComponent<Rigidbody>();
	
		posX = r.position.x;
		posZ = r.position.z;
		
		//destroy on out of bounds
		if(this.gameObject.name == "Bullet(Clone)")
		{
			//check bullet position
			//top side
			if(posZ > (2000f))
			{
				GameObject.Destroy(this.gameObject); 
			}
			
			//bottom side
			if(posZ < (-2000f))
			{
				GameObject.Destroy(this.gameObject); 
			}
			
			//left side
			if(posX < (-2000f))
			{
				GameObject.Destroy(this.gameObject); 
			}
			
			//right side
			if(posX > (2000f))
			{
				GameObject.Destroy(this.gameObject); 
			}
		}
    }
	
	void OnCollisionEnter(Collision collision)
	{
		if(this.gameObject.name == "Bullet(Clone)" && collision.transform.gameObject.name == "asteroid1(Clone)")
			GameObject.Destroy(this.gameObject);
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if(this.gameObject.name == "Bullet(Clone)" && collider.transform.gameObject.name == "asteroid1(Clone)")
			GameObject.Destroy(this.gameObject);
	}
}
