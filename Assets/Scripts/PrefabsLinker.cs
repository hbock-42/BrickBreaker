using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Prefabs
{
	Spawner,
	Sphere
}

public class PrefabsLinker : MonoBehaviour
{

	[SerializeField] private GameObject _spherePrefab;
	[SerializeField] private GameObject _spawner;

	#region singleton
	public static PrefabsLinker Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(this.gameObject);
		}
	}
	#endregion

	public GameObject GetPrefab(Prefabs prefabs)
	{
		var ret = new GameObject();
		switch (prefabs)
		{
			case Prefabs.Spawner:
				ret = _spawner;
				break;
			case Prefabs.Sphere:
				ret =  _spherePrefab;
				break;
			default:
				Debug.LogError("Prefabs " + prefabs + " not linked to the PrefabsLinker gameobject");
				break;
		}

		return ret;
	}
}