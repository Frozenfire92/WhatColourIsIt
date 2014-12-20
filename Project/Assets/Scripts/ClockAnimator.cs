//http://catlikecoding.com/unity/tutorials/clock/
using UnityEngine;
using System;

public class ClockAnimator : MonoBehaviour {

	public Transform hours, minutes, seconds;
	public bool analog;

	private const float
		hoursToDegrees = 360f / 12f,
		minutesToDegrees = 360f / 60f,
		secondsToDegrees = 360f / 60f;
	
	// Update is called once per frame
	void Update () {

		//continuos movement
		if (analog) {
			// Get current time
			TimeSpan timespan = DateTime.Now.TimeOfDay;

			// Rotate clock hands
			hours.localRotation = Quaternion.Euler(0f,0f,(float)timespan.TotalHours * -hoursToDegrees);
			minutes.localRotation = Quaternion.Euler(0f,0f,(float)timespan.TotalMinutes * -minutesToDegrees);
			seconds.localRotation = Quaternion.Euler(0f,0f,(float)timespan.TotalSeconds * -secondsToDegrees);
		}

		// discrete steps (seconds)
		else { 
			// Get current time
			DateTime time = DateTime.Now;

			// Rotate clock hands
			hours.localRotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegrees);
			minutes.localRotation = Quaternion.Euler(0f, 0f, time.Minute * -minutesToDegrees);
			seconds.localRotation = Quaternion.Euler(0f, 0f, time.Second * -secondsToDegrees);
		}
	}

	public void ToggleAnalog()
	{
		analog = !analog;
	}
}
