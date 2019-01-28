using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcoscphereScript : MonoBehaviour {

	void FixedUpdate () {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, Mathf.Sin(Time.time * 3) + 3f, gameObject.transform.position.z);
	}
}