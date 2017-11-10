using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//When the thing hits the thing it will die
public class DestroyByContact : MonoBehaviour 
{ 
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cant find 'GameController' script");
		}
	}
	
	void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Boundary")
        {
            return;
        }

		Instantiate(explosion, transform.position, transform.rotation);

		GetComponent<AudioSource> ().Play ();
		
		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
		}
        gameController.AddScore (scoreValue);
		Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

