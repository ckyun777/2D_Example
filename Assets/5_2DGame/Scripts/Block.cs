﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update

	public bool m_GameStarted = false;
   public string m_Type = "wood";
   public int m_Hp = 2;
	public float m_DamageVal = 1f;
	
	public AudioSource m_Audio;

	public AudioClip m_Sound;
	public AudioClip m_SoundBig;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if( !m_GameStarted ) return; 

		//print(collision.relativeVelocity.magnitude);

		m_Audio.clip = m_Sound;

		if (collision.relativeVelocity.magnitude > m_DamageVal)
		{
			m_Audio.clip = m_SoundBig;

			m_Hp--;
			if(m_Hp <= 0)
			{
				m_Audio.Play();
				Destroy(gameObject);
			}

		}

		if(m_Audio != null && m_Audio.clip != null)
			m_Audio.Play();

	}
}
