using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    //Singleton variable
    public static InputManager IM;

	public KeyCode ctrl_moveRight = KeyCode.D;
	public KeyCode ctrl_moveLeft = KeyCode.A;
    public KeyCode ctrl_moveDown = KeyCode.S;
    public KeyCode ctrl_moveUp = KeyCode.W;
    public KeyCode ctrl_jump = KeyCode.Space;
	public KeyCode ctrl_attack = KeyCode.Mouse0;
    public KeyCode ctrl_sneak = KeyCode.LeftShift;
	public KeyCode ctrl_interact = KeyCode.F;
	public KeyCode ctrl_inventory = KeyCode.I;
	public KeyCode ctrl_pause = KeyCode.Escape;
          
    public string key_right = "ctrl_right";
    public string key_left = "ctrl_left";
    public string key_down = "ctrl_down";
    public string key_up = "ctrl_up";
    public string key_jump = "ctrl_jump";
    public string key_attack = "ctrl_attack";
    public string key_sneak = "ctrl_sneak";
    public string key_interact = "ctrl_interact";
    public string key_inventory = "ctrl_inventory";
    public string key_pause = "ctrl_pause";

    private void Start()
    {
        //Singleton
        if (IM == null)
        {
            DontDestroyOnLoad(gameObject);
            IM = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Get_Ctrls();
    }

    private void Get_Ctrls()
    {
        ctrl_moveRight = PlayerPrefsManager.PPM.Get_Ctrl(key_right, ctrl_moveRight);
        ctrl_moveLeft = PlayerPrefsManager.PPM.Get_Ctrl(key_left, ctrl_moveLeft);
        ctrl_moveDown = PlayerPrefsManager.PPM.Get_Ctrl(key_down, ctrl_moveDown);
        ctrl_moveUp = PlayerPrefsManager.PPM.Get_Ctrl(key_up, ctrl_moveUp);
        ctrl_jump = PlayerPrefsManager.PPM.Get_Ctrl(key_jump, ctrl_jump);
        ctrl_attack = PlayerPrefsManager.PPM.Get_Ctrl(key_attack, ctrl_attack);
        ctrl_sneak = PlayerPrefsManager.PPM.Get_Ctrl(key_sneak, ctrl_sneak);
        ctrl_interact = PlayerPrefsManager.PPM.Get_Ctrl(key_interact, ctrl_interact);
        ctrl_inventory = PlayerPrefsManager.PPM.Get_Ctrl(key_inventory, ctrl_inventory);
        ctrl_pause = PlayerPrefsManager.PPM.Get_Ctrl(key_pause, ctrl_pause);
    }
}
