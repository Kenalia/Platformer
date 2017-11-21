using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    //Singleton variable
    public static PlayerPrefsManager PPM;

	public string key_volume = "volume";
	public string key_fullscreen = "fullscreen";

	public int value_volume = 10;
	public int value_fullscreen = 0;

    private void Start()
    {
        if(PPM == null)
        {
            DontDestroyOnLoad(gameObject);
            PPM = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Set_Ctrl(KeyCode ctrl, string keyString)
	{
		PlayerPrefs.SetString (keyString, ctrl.ToString());
	}

    public KeyCode Get_Ctrl(string keyString, KeyCode defaultValue)
    {
        return (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(keyString, defaultValue.ToString()));
    }

	public void Save_Player_Prefs()
	{
		PlayerPrefs.SetInt (key_volume, value_volume);
		PlayerPrefs.SetInt (key_fullscreen, value_fullscreen);
	}

	private void Load_Player_Prefs()
	{
		value_volume = PlayerPrefs.GetInt (key_volume);
		value_fullscreen = PlayerPrefs.GetInt (key_fullscreen);
	}
}
