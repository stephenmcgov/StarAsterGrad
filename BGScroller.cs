using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{   
	public float scrollSpeed;
	public Renderer quadRenderer;

	void Update()
	{
	    Vector2 textureOffset = new Vector2(scrollSpeed*Time.time,0);
	    quadRenderer.material.mainTextureOffset = textureOffset;
	}
}
