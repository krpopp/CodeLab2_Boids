using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util 
{
    public static Vector3 PointOnCircle(float radius, float theta) {
		return new Vector3(Mathf.Cos(theta), Mathf.Sin(theta), 0) * radius;
	}

	public static Vector3 PointOnSphere(float radius, float horizTheta, float vertTheta) {
		Vector3 toreturn = Vector3.zero;
		toreturn.x = Mathf.Sin(horizTheta) * Mathf.Cos(vertTheta);
		toreturn.y = Mathf.Sin(vertTheta);
		toreturn.z = Mathf.Cos(horizTheta) * Mathf.Cos(vertTheta);

		return radius * toreturn;
	}

	public static Vector3 Limit(Vector3 v, float max) {
		if (v.magnitude > max) {
			return v.normalized * max;
		} else {
			return v;
		}
	}
}
