﻿
public interface IDamagable
{
	#region Properties

	int Hp { get; set; }

	#endregion


	#region Methods

	void TakeDamage(int amount);

	#endregion

}
