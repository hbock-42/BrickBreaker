using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshCollider))]
public class Brick : MonoBehaviour, IDamagable, IDestroyable {

	#region Constants

	private const int InitialHp = 2;

	#endregion

	#region Events

	private UnityEvent _noHpRemaining;

	#endregion

	#region Fields

	private int _hp;

	#endregion

	#region Properties


	public int Hp
	{
		get { return _hp; }
		set
		{
			if (value >= 0) _hp = value;
			else
			{
				_hp = 0;
				_noHpRemaining.Invoke();
			}
		}
	}

	#endregion

	#region MonoBehaviour

	private void Start()
	{
		Initialize();
	}

	#endregion

	#region Methods

	private void Initialize()
	{
		Hp = InitialHp;
		_noHpRemaining = new UnityEvent();
		_noHpRemaining.AddListener(NoHpRemainingCallback);
	}

	public void Destroy()
	{
		Destroy(gameObject);
	}

	public void TakeDamage(int amount)
	{
		Hp -= amount;
	}

	/// <summary>
	/// Action to take when the brick hits zero hp
	/// </summary>
	private void NoHpRemainingCallback()
	{
		Destroy();
	}

	#endregion

	#region Messages

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Ball"))
		{
			TakeDamage(1);
		}
	}

	#endregion
}
