using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class TempPlayerController : MonoBehaviour
{

	[SerializeField] private float speed = 1f;
	private bool status = false;
    // Update is called once per frame
    void Update()
    {
		if (status)
		{
			transform.position = Vector3.right * speed * Time.deltaTime + transform.position ;
			if (transform.position.x >= 10f)
			{
				status = false;
			}
		}
		else
		{
			transform.position = Vector3.left * speed * Time.deltaTime + transform.position ;
			if (transform.position.x <= -10f)
			{
				status = true;
			}
		}
	}
}
