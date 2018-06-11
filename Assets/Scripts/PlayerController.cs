using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerController : MonoBehaviour
{

	private Vector3 _direction;
	private Transform _player;
	private float _speed = 10;

	public static PlayerController Instance { get; private set; }

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

		_player = this.transform;
	}

	private void Update()
	{
		ManageInputs();
		UpdatePosition();
	}

	private void ManageInputs()
	{
		_direction = Vector3.zero;
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			_direction = Vector3.left;
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			_direction = Vector3.right;
		}
	}

	private void UpdatePosition()
	{
		//_player.position += _direction * _speed * Time.deltaTime;
		this.transform.position += _direction * _speed * Time.deltaTime;
	}
}
