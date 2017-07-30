using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerReadout : MonoBehaviour {

	public int m_playerNumber;
	public Text m_playerNumberDisplay;
	public Text m_healthDisplay;
	public Text m_fistDisplayR;
	public Text m_fistDisplayL;

	public Fighter m_player;

	// Use this for initialization
	void Start () 
	{
		m_playerNumberDisplay.text = "Player "+(m_playerNumber+1).ToString();
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_healthDisplay.text = m_player.health.ToString();
		m_fistDisplayR.text = m_player.m_fists[0].muscle.ToString();
		m_fistDisplayL.text = m_player.m_fists[1].muscle.ToString();
	}
}
