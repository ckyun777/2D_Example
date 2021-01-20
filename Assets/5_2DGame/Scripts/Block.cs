using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update

   public string m_Type = "wood";
   public int m_Hp = 2;
	public float m_DamageVal = 1f;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		print(collision.relativeVelocity.magnitude);

		if (collision.relativeVelocity.magnitude > m_DamageVal)
		{
			m_Hp--;
			if(m_Hp <= 0)
			{
				Destroy(gameObject);
			}

		}
	}
}
