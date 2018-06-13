using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerController : MonoBehaviour
{
	#region Fields

	private Vector3 _direction;
	private float _speed = 10;

	#endregion

	#region Singleton

	public static PlayerController Instance { get; private set; }

	#endregion

	#region MonoBehaviour

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
	}

	private void Update()
	{
		ManageInputs();
		UpdatePosition();
	}

	#endregion

	#region Methods

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
		transform.position += _direction * _speed * Time.deltaTime;
	}

	#endregion
}
