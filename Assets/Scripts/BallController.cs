using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallController : MonoBehaviour
{
	#region Constants

	private const int DirectionsToCompute = 100;
	private const int PrecomputedDirectionsRangeInDeg = 100;

	#endregion

	#region Fields

	private Transform _ball;
	private readonly float _speed = 10f;
	private bool _hit;
	private Vector3[] _precomputedDirections;
	private Collider _playerCollider;

	#endregion

	#region Properties

	public Vector3 Direction { get; set; }

	public Transform Player
	{
		get { return PlayerController.Instance.transform; }
	}

	#endregion

	#region MonoBehaviour

	private void Awake()
	{
		_ball = this.transform;
		Direction = Random.insideUnitSphere;
		var tmp = Direction;
		tmp.z = 0;
		Direction = tmp;
		_playerCollider = Player.GetComponent<Collider>();
		PrecomputeDirections();
	}

	private void Update()
	{
		Move();
	}

	#endregion

	#region Methods

	private void Move()
	{
		_ball.position += Direction * _speed * Time.deltaTime;
	}

	/// <summary>
	/// Calcul the normal on collision (average of the multiple collision points
	/// </summary>
	/// <param name="collision"></param>
	/// <returns></returns>
	private Vector3 NormalOnCollision(Collision collision)
	{
		var normal = Vector3.zero;
		foreach (var collisionContact in collision.contacts)
		{
			normal += collisionContact.normal;
		}
		normal.Normalize();

		return normal;
	}

	/// <summary>
	/// Return an index depanding on the ball hit position on the player
	/// Starting from 0 if the ball hit the player far left
	/// Ending at DirectionsToCompute - 1 on far right
	/// </summary>
	/// <returns></returns>
	private int GetOnPlayerHitIndex()
	{
		var xMin = _playerCollider.bounds.min.x;
		var xMax = _playerCollider.bounds.max.x;

		int index;

		Debug.Log("min:" + xMin);
		Debug.Log("ball:" + _ball.position.x);
		Debug.Log("max:" + xMax);

		if (_ball.position.x < xMin) index = 0;
		else if (_ball.position.x > xMax) index = DirectionsToCompute - 1;
		else
		{
			index = (int)(Mathf.Abs(_ball.position.x - xMin) / (xMax - xMin) * DirectionsToCompute);
		}
		Debug.Log(index);
		return index;
	}

	/// <summary>
	/// Calcul the new direction given the normal
	/// </summary>
	/// <param name="normal"></param>
	/// <returns></returns>
	private Vector3 DirectionAfterContact(Vector3 normal)
	{
		//Rr = Ri - 2 N (Ri . N)
		return Direction - 2 * normal * (Vector3.Dot(normal, Direction));
	}

	/// <summary>
	/// Precompute directions of the ball when it hits the player 
	/// </summary>
	private void PrecomputeDirections()
	{
		_precomputedDirections = new Vector3[DirectionsToCompute];

		var startNormal = Quaternion.Euler(0, 0, (float)PrecomputedDirectionsRangeInDeg / 2) * Vector3.up;

		for (var i = 0; i < DirectionsToCompute; i++)
		{
			var angle = -(float)PrecomputedDirectionsRangeInDeg / (DirectionsToCompute - 1) * i;
			_precomputedDirections[i] = Quaternion.Euler(0, 0, angle) * startNormal;
			_precomputedDirections[i].Normalize();
		}
	}

	#endregion

	#region Messages

	// We use OnTriggerEnter for collision with the player because we
	// don't make real "physic" reflection
	private void OnTriggerEnter(Collider other)
	{
		if (!other.CompareTag("Player")) return;
		Direction = _precomputedDirections[GetOnPlayerHitIndex()];
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (_hit) return;
		_hit = true;
		var isPlayer = collision.contacts.FirstOrDefault().otherCollider.CompareTag("Player");
		if (isPlayer) return;
		Direction = DirectionAfterContact(NormalOnCollision(collision));
	}

	private void OnCollisionExit(Collision other)
	{
		// TODO remove _hit everywhere, useless
		_hit = false;
	}

	#endregion
	
}
