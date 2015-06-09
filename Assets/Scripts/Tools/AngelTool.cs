using UnityEngine;
using System.Collections;

public static class AngelTool {
	
	public static Quaternion FaceObject(Vector2 startingPosition, Vector2 targetPosition, FacingDirection facing) {
		Vector2 direction = targetPosition - startingPosition;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		angle -= (float)facing;
		return Quaternion.AngleAxis(angle, Vector3.forward);
	}
}

public enum FacingDirection {
	UP = 270,
	DOWN = 90,
	LEFT = 180,
	RIGHT = 0
}