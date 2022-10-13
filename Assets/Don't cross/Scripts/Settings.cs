using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {

	public Canvas settings;
	public Image on, off;
	public AudioSource music;
	public void Close()
	{
		settings.gameObject.SetActive(false);
	}
	void Start()
	{
		AudioSource musicplay = Instantiate(music);
		if(PlayerPrefs.GetInt("music") == 0)
		{
			on.gameObject.SetActive(true);
			off.gameObject.SetActive(false);
			music.Play();
		}
		if(PlayerPrefs.GetInt("music") == 1)
		{
			on.gameObject.SetActive(false);
			off.gameObject.SetActive(true);
			music.Stop();
		}
	}
	public void MusicSwitch()
	{
		if(PlayerPrefs.GetInt("music") == 1) // NOW MUSIC IS OFF
		{
			PlayerPrefs.SetInt("music", 0); // SET MUSIC ON
			on.gameObject.SetActive(true);
			off.gameObject.SetActive(false);
			music.Play();
			return;
		}
		if(PlayerPrefs.GetInt("music") == 0) // NOW MUSIC IS ON
		{
			PlayerPrefs.SetInt("music", 1); // SET MUSIC OFF
			on.gameObject.SetActive(false);
			off.gameObject.SetActive(true);
			music.Stop();
			return;
		}
	}
}
