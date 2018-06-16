using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBuilder : MonoBehaviour {


	private void Start ()
	{
		//Instantiate(BrickBuilder.BrickGo);
		if (BrickBuilder.BrickGo.activeSelf)
		{
			Debug.Log("Lol");

		}
	}

}
