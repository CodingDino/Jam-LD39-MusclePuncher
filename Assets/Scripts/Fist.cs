using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : MonoBehaviour {

	public float m_damageMult = 1; // Damage dealt per muscle used
	public float m_maxMuscle = 100;
	public string m_punchString = "Punch-R-";
	public float m_punchMuscleMult = 10; // Muscle used per second of charge up

	private Animator m_animator;
	private int m_playerNumber = 0;
	private float m_muscle = 100;
	private string m_inputPunch;
	private float m_punchMuscle = 10;
	private float m_chargeStartTime = 0;
	private bool m_punching = false;

	public int playerNumber { set { 
			m_playerNumber = value; 
			m_inputPunch = m_punchString+m_playerNumber.ToString();
		} }
	public float muscle { get { return m_muscle; } set {m_muscle = value;} }

	// Use this for initialization
	void Start () {
		m_muscle = m_maxMuscle;
		m_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// TODO: Hold down to charge up punch?
		if (Input.GetButtonDown(m_inputPunch))
		{
			// StartCharging
			m_animator.SetBool("Charging", true);
			m_chargeStartTime = Time.time;
		}
		if (Input.GetButtonUp(m_inputPunch))
		{
			// Punch
			m_animator.SetBool("Charging", false);
			m_punchMuscle = (Time.time - m_chargeStartTime)*m_punchMuscleMult;
			m_punchMuscle = UseMuscle(m_punchMuscle);
		}
		
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
			_fighter.DealDamage(m_damageMult * m_punchMuscle);
			m_punching = false;
		}
		else if (_fist != null)
		{
			// TODO: Knockback
			m_punching = false;
		}
	}

	// Update is called once per frame
	public float UseMuscle (float _muscle) 
	{
		if (_muscle > m_muscle)
			_muscle = m_muscle;
		m_muscle -= _muscle;
		return _muscle;
	}

	public void StartPunching()
	{
		m_punching = true;
	}

	public void StopPunching()
	{
		m_punching = false;
	}
}
