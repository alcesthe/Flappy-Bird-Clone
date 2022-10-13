using UnityEngine;

public class AudioSystem : MonoBehaviour
{
	public static AudioSystem instace;

	public static void PlaySound(AudioClip audioClip)
	{
		GameObject soundGameObject = new GameObject("Sound");
		AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
		audioSource.PlayOneShot(audioClip);
		Destroy(soundGameObject, audioClip.length);
	}
}
