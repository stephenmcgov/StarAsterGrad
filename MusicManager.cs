using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MusicManager : MonoBehaviour
{
    public GameObject musicPlayer;
    
    void Awake() 
    {
		//keep object between scenes
        musicPlayer = GameObject.Find("MUSIC");
        
        if(musicPlayer==null)
        {
            musicPlayer = this.gameObject;
            musicPlayer.name = "MUSIC";
            DontDestroyOnLoad(musicPlayer);
        }
        
        else
        {
            if(this.gameObject.name!="MUSIC")
            {
                Destroy(this.gameObject);
            }
        }
    }

    void Update()
    {
		//stop bg music conflict with main menu
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
 
        if(sceneName == "Menu") 
        {
            Destroy(this.gameObject);
        }
    }
}
