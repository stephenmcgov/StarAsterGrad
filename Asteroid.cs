using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.SceneManagement;  

public class Asteroid : MonoBehaviour {      
float posX;
float posY;
float posZ;  
float randV;
public float maxSpeed = 20f;
public AudioSource audioSource;
public AudioClip audioClip;
    
void Start ()
{    
	//set starting speed
	Rigidbody r = GetComponent<Rigidbody>();
	Scene currentScene = SceneManager.GetActiveScene();
    string sceneName = currentScene.name;
 
    if(sceneName == "Asteroids") 
    {
        r.velocity = new Vector3(0f, 0f, Random.Range(-1f, 1f)); 
		r.AddTorque(new Vector3(0f,Random.Range(-2f,2f),0f)); 
    }
     
	else if(sceneName == "Gradius")
    {
		r.velocity = new Vector3(0f, 0f, 0f+randomiseVelocity()); 
	    r.AddTorque(new Vector3(0f,Random.Range(-5f,5f),0f)); 
    }
		 
	else if(sceneName == "Starfox")
	{
		r.velocity = new Vector3(Random.Range(-500f, -100f), 0f, Random.Range(-100f, 250f));
		r.AddTorque(new Vector3(Random.Range(-250f,250f),0f,0f));
	}    
}          

void Update()
{
	Rigidbody r = GetComponent<Rigidbody>();
	posX = r.position.x;
	posZ = r.position.z;
	Vector3 localVelocity = r.velocity;
	Scene currentScene = SceneManager.GetActiveScene ();
    string sceneName = currentScene.name;
	
	//restrict speed	
	if(sceneName=="Asteroids")
	{
		if(r.velocity.magnitude > maxSpeed)
		{
			r.velocity = Vector3.ClampMagnitude(r.velocity, maxSpeed);
     	}
	}
	
	//set Gradius scene out of bounds
	if(sceneName=="Gradius")
	{
		if(this.gameObject.name == "asteroid1(Clone)") 
        {
          	if(this.gameObject.transform.position.z<-150f||this.gameObject.transform.position.z>500f)
				GameObject.DestroyImmediate(this.gameObject, true);
        }   
	}
	
	//destroy when out of bounds all scenes
    if(this.gameObject.name == "asteroid1(Clone)") 
    {
     	if(this.gameObject.transform.position.x<-1500f||this.gameObject.transform.position.x>1500f)
			GameObject.DestroyImmediate(this.gameObject, true);
	
		if(this.gameObject.transform.position.z<-1500f||this.gameObject.transform.position.z>1500f)
			GameObject.DestroyImmediate(this.gameObject, true);
    }   
}     

public float randomiseVelocity()
{
	randV = Random.Range(-10f, 0.25f);
	
	if(randV==0f || randV==1f || randV==-1f)
		randomiseVelocity();
	
	return randV;
}	

void OnCollisionEnter(Collision collision)
{
	if(collision.transform.gameObject.name == ("arwing(Clone)") || collision.transform.gameObject.name == ("Bullet(Clone)"))
	{
		GameObject.Destroy(this.gameObject);
		Debug.Log("ouch");
	}
}

void OnTriggerEnter(Collider collider)
{
	if(collider.transform.gameObject.name == ("arwing(Clone)"))
	{
		audioSource.clip = audioClip;
		audioSource.Play();
		GameObject.Destroy(this.gameObject);
	}
	
	if(collider.transform.gameObject.name == ("Bullet(Clone)"))
		GameObject.Destroy(this.gameObject);
}

}