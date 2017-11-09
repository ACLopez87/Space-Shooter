using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;
	
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
			Debug.Log("ITS A PLAYA");
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
		}
        
		Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

