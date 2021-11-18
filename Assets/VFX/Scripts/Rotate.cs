/****************************************************************************
 *
 * Copyright (c) 2011 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
	public Vector3 speed = Vector3.one;

	void Update ()
	{
		transform.Rotate(Vector3.down * Time.deltaTime * speed.x);
		transform.Rotate(Vector3.right * Time.deltaTime * speed.y);
		transform.Rotate(Vector3.forward * Time.deltaTime * speed.z);
	}
}
