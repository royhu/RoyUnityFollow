/****************************************************************************
 *
 * Copyright (c) 2011 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	void Update () {
		transform.Rotate(Vector3.down * Time.deltaTime * 10);
		transform.Rotate(Vector3.right * Time.deltaTime * 1);
		transform.Rotate(Vector3.forward * Time.deltaTime * 8);
	}
}
