using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : MonoBehaviour {

	public float m_damage = 10; // TODO: Scalable based on charge up time
	public bool m_punching = false;
	public float m_maxMuscle = 100;

	private int m_playerNumber = 0;
	private float m_muscle = 100;

	public int playerNumber { set { m_playerNumber = value; } }
	public float muscle { get { return m_muscle; } set {m_muscle = value;} }

	// Use this for initialization
	void Start () {
		m_muscle = m_maxMuscle;
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
		if (_fighter != null)
		{
			// TODO: Deal damage
			_fighter.DealDamage(m_damage);
			m_punching = false;
		}
		else if (_fist != null)
		{
			// TODO: Knockback
			m_punching = false;
		}
	}

	// Update is called once per frame
	public void UseMuscle (float _muscle) 
	{
		m_muscle -= _muscle;
		if (m_muscle < 0)
			m_muscle = 0;
	}
}
