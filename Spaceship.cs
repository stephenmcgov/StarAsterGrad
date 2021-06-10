using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;  
using UnityEngine.SceneManagement;

public class Spaceship : MonoBehaviour {      
float posX;
float posY;
float posZ;
public Vector3 spawnPos;  
public float turnSpeed = 100f;

void Start ()
{         
//
}          

void Update()
{
	Rigidbody r = GetComponent<Rigidbody>();
	posX = r.position.x;
	posY = r.position.y;
	posZ = r.position.z;
	Vector3 localVelocity = r.velocity;

	Scene currentScene = SceneManager.GetActiveScene ();
    string sceneName = currentScene.name;
	
	//set scene controls
	if(this.gameObject.name == "arwing(Clone)")
	{
		if (sceneName == "Asteroids") 
        {
        	r.position = new Vector3(posX, 0, posZ);
            //need to stop ship spiralling on diagonal turn:
			r.constraints = RigidbodyConstraints.FreezeRotation;
			
			if (Input.GetKey("w"))
				r.velocity = transform.TransformDirection(new Vector3(1f, 0f, 0f) * -30);

			if (Input.GetKey("s"))
				r.velocity = transform.TransformDirection(new Vector3(1f, 0f, 0f) * 30);
         
			if(Input.GetKey("a"))
        	    r.transform.Rotate(new Vector3(0f, 1000f, 0f), -225 * Time.deltaTime);
        
			if(Input.GetKey("d"))
            	r.transform.Rotate(new Vector3(0f, 1000f, 0f), 225 * Time.deltaTime);

            if(Input.GetKey(KeyCode.Escape))
			{
            	//Debug.Log("escape!!!!!");
            	SceneManager.LoadScene("Menu");
			}

			/*if(Input.anyKey)
 			{
      			Debug.Log(Input.inputString);
 			}*/

            //screen bounds (refactor as dynamic)
            if(posX<-80f)
            	r.position = new Vector3(-80f, posY, posZ);

            if(posX>80f)
            	r.position = new Vector3(80f, posY, posZ);

            if(posZ<-42.5f)
            	r.position = new Vector3(posX, posY, -42.5f);

            if(posZ>42.5f)
            	r.position = new Vector3(posX, posY, 42.5f);
         }

         else if (sceneName == "Gradius")
         {
            if (Input.GetKey("w"))
			{
				//trying to pseudo-animate wing tilting
				r.velocity = transform.TransformDirection(new Vector3(0f, 0f, -20f));
				
				if(r.transform.rotation.y>25f)
					r.transform.Rotate(new Vector3(5f, 0f, 0f), -turnSpeed * Time.deltaTime);
			}

			if(Input.GetKey("s"))
			{
				//trying to pseudo-animate wing tilting
				r.velocity = transform.TransformDirection(new Vector3(0f, 0f, 20f));
			
				if(r.transform.rotation.y<-25f)
					r.transform.Rotate(new Vector3(1f, 0f, 0f), turnSpeed * Time.deltaTime);
			}
			
			if(Input.GetKey("a"))
            	r.velocity = transform.TransformDirection(new Vector3(20f, 0f, 0f));
        
			if(Input.GetKey("d"))
            	r.velocity = transform.TransformDirection(new Vector3(-20f, 0f, 0f));

            if(Input.GetKey(KeyCode.Escape))
			{
            	//Debug.Log("escape!!!!!");
            	SceneManager.LoadScene("Menu");
			}

			/*if(Input.anyKey)
 			{
      			Debug.Log(Input.inputString);
 			}*/

            //screen bounds (refactor as dynamic)
            if(posY<-20f)
            	r.position = new Vector3(posX, -20f, posZ);

            if(posY>17.5f)
            	r.position = new Vector3(posX, 17.5f, posZ);

            if(posZ<-40f)
            	r.position = new Vector3(posX, posY, -40f);

            if(posZ>27.5f)
            	r.position = new Vector3(posX, posY, 27.5f);
         }
		 
		 else if (sceneName == "Starfox")
		 {
		 	//3D ship controls
			if (Input.GetKey("w"))
			{
				r.transform.Rotate(new Vector3(0f, 1f, 0f), 1 * Time.deltaTime);

            	if(r.transform.rotation.y<5f)
					r.velocity = transform.TransformDirection(new Vector3(0f, 2f, 0f) * 10);
			}

			if (Input.GetKey("s"))
			{
				r.transform.Rotate(new Vector3(0f, 1f, 0f), -1 * Time.deltaTime);

				if(r.transform.rotation.y>-5f)
					r.velocity = transform.TransformDirection(new Vector3(0f, 2f, 0f) * -10);
			}
         
			if(Input.GetKey("a"))
			{
            	r.velocity = transform.TransformDirection(new Vector3(0f, 0f, 2f) * -10);

				if(r.transform.rotation.x>-15f)
					r.transform.Rotate(new Vector3(1f, 0f, 0f), -1 * Time.deltaTime);
			}
        
			if(Input.GetKey("d"))
			{
            	r.velocity = transform.TransformDirection(new Vector3(0f, 0f, 2f) * 10);
				
				if(r.transform.rotation.x<15f)
					r.transform.Rotate(new Vector3(1f, 0f, 0f), 1 * Time.deltaTime);
			}

			if(Input.GetKey(KeyCode.Escape))
			{
            	//Debug.Log("escape!!!!!");
            	SceneManager.LoadScene("Menu");
			}

			/*if(Input.anyKey)
 			{
      			Debug.Log(Input.inputString);
 			}*/
			
			//screen bounds (refactor as dynamic)
            if(posY<-17.5f)
            	r.position = new Vector3(posX, -17.5f, posZ);

            if(posY>10f)
            	r.position = new Vector3(posX, 10f, posZ);

            if(posZ<-27.5f)
            	r.position = new Vector3(posX, posY, -27.5f);

            if(posZ>20f)
            	r.position = new Vector3(posX, posY, 20f);
		} 
	}
} 	

void OnCollisionEnter(Collision collision)
{
	/*if(this.gameObject.name == "arwing(Clone)" && collision.transform.gameObject.name == "asteroid1(Clone)")
		HealthManager.health-=1;
	
	if(HealthManager.health<0)
	{
		GameObject.Destroy(this.gameObject);
		SceneManager.LoadScene("Menu");
	}*/
	//Debug.log("ouch");
}
}