using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : MonoBehaviour {

	public float m_damage = 10; // TODO: Scalable based on charge up time

	private int m_playerNumber = 0;
	public bool m_punching = false;

	public int playerNumber { set { m_playerNumber = value; } }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionStay(Collision _collision)
	{
		if (!m_punching)
			return;

		Fighter _fighter = _collision.collider.GetComponent<Fighter>();
		Fist _fist = _collision.collider.GetComponent<Fist>();
		// TODO: Check if punching
		if (_fighter != null)
		{
			// TODO: Deal damage
			_fighter.DealDamage(m_damage);
			m_punching = false;
		}
		// TODO: Check that we are in the process of punching before doing knockback
		else if (_fist != null)
		{
			// TODO: Knockback
			m_punching = false;
		}
	}
}
