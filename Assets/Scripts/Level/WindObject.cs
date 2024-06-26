using UnityEngine;

[CreateAssetMenu(fileName ="NewWind", menuName = "Wind")]
public class WindObject : ScriptableObject
{
	public float windForce = 10f; // Сила ветра
	public float windDuration = 2f; // Длительность ветра
	public float windInterval = 5f; // Интервал между порывами ветра
}
