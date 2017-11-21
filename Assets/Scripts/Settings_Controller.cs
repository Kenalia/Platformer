using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Settings_Tabs {Video, Audio, Controls}; 

public class Settings_Controller : MonoBehaviour {

    [SerializeField]
	private Settings_Tabs currentTab = Settings_Tabs.Video;

    //Key Assignment Variables
    private Event keyEvent = null;
    private KeyCode newKey;
    private bool waitingForKey = false;


	public void Set_Current_Tab(int tabValue)
	{
        currentTab = (Settings_Tabs)tabValue;
	}

    //TODO: CREATE A STYLE

	void OnGUI()
	{

        if (currentTab == Settings_Tabs.Video)
        {

        }
        else if (currentTab == Settings_Tabs.Audio)
        {

        }
        else if (currentTab == Settings_Tabs.Controls)
        {
            //Control Text Names
            GUI.Label(new Rect(new Vector2((int)(Screen.width / 2 - (Screen.width * .2)), (int)((Screen.height * .2) * 1.0)), new Vector2(160, 30)), InputManager.IM.key_right);
            GUI.Label(new Rect(new Vector2((int)(Screen.width / 2 - (Screen.width * .2)), (int)((Screen.height * .2) * 1.3)), new Vector2(160, 30)), InputManager.IM.key_left);
            GUI.Label(new Rect(new Vector2((int)(Screen.width / 2 - (Screen.width * .2)), (int)((Screen.height * .2) * 1.6)), new Vector2(160, 30)), InputManager.IM.key_down);
            GUI.Label(new Rect(new Vector2((int)(Screen.width / 2 - (Screen.width * .2)), (int)((Screen.height * .2) * 1.9)), new Vector2(160, 30)), InputManager.IM.key_up);
            GUI.Label(new Rect(new Vector2((int)(Screen.width / 2 - (Screen.width * .2)), (int)((Screen.height * .2) * 2.2)), new Vector2(160, 30)), InputManager.IM.key_jump);
            GUI.Label(new Rect(new Vector2((int)(Screen.width / 2 - (Screen.width * .2)), (int)((Screen.height * .2) * 2.5)), new Vector2(160, 30)), InputManager.IM.key_attack);
            GUI.Label(new Rect(new Vector2((int)(Screen.width / 2 - (Screen.width * .2)), (int)((Screen.height * .2) * 2.8)), new Vector2(160, 30)), InputManager.IM.key_sneak);
            GUI.Label(new Rect(new Vector2((int)(Screen.width / 2 - (Screen.width * .2)), (int)((Screen.height * .2) * 3.1)), new Vector2(160, 30)), InputManager.IM.key_interact);
            GUI.Label(new Rect(new Vector2((int)(Screen.width / 2 - (Screen.width * .2)), (int)((Screen.height * .2) * 3.4)), new Vector2(160, 30)), InputManager.IM.key_inventory);
            GUI.Label(new Rect(new Vector2((int)(Screen.width / 2 - (Screen.width * .2)), (int)((Screen.height * .2) * 3.7)), new Vector2(160, 30)), InputManager.IM.key_pause);

            //Control Buttons
            if(GUI.Button(new Rect(new Vector2((int)(Screen.width / 2 - (Screen.width * .1)), (int)((Screen.height * .2) * 1)), new Vector2(200, 30)), InputManager.IM.ctrl_moveRight.ToString()))
            {
                if (waitingForKey == false)
                {
                    waitingForKey = true;
                    InputManager.IM.ctrl_moveRight = Perform_Key_Assignment();
                }
            }
            if(GUI.Button(new Rect(new Vector2((int)(Screen.width / 2 - (Screen.width * .1)), (int)((Screen.height * .2) * 1.3)), new Vector2(200, 30)), InputManager.IM.ctrl_moveLeft.ToString()))
            {
                if (waitingForKey == false)
                {
                    waitingForKey = true;
                    InputManager.IM.ctrl_moveLeft = Perform_Key_Assignment();
                }
            }
            if(GUI.Button(new Rect(new Vector2((int)(Screen.width / 2 - (Screen.width * .1)), (int)((Screen.height * .2) * 1.6)), new Vector2(200, 30)), InputManager.IM.ctrl_moveDown.ToString()))
            {
                if (waitingForKey == false)
                {
                    waitingForKey = true;
                    InputManager.IM.ctrl_moveDown = Perform_Key_Assignment();
                }
            }
            if(GUI.Button(new Rect(new Vector2((int)(Screen.width / 2 - (Screen.width * .1)), (int)((Screen.height * .2) * 1.9)), new Vector2(200, 30)), InputManager.IM.ctrl_moveUp.ToString()))
            {
                if (waitingForKey == false)
                {
                    waitingForKey = true;
                    InputManager.IM.ctrl_moveUp = Perform_Key_Assignment();
                }
            }
            if(GUI.Button(new Rect(new Vector2((int)(Screen.width / 2 - (Screen.width * .1)), (int)((Screen.height * .2) * 2.2)), new Vector2(200, 30)), InputManager.IM.ctrl_jump.ToString()))
            {
                if (waitingForKey == false)
                {
                    waitingForKey = true;
                    InputManager.IM.ctrl_jump = Perform_Key_Assignment();
                }
            }
            if(GUI.Button(new Rect(new Vector2((int)(Screen.width / 2 - (Screen.width * .1)), (int)((Screen.height * .2) * 2.5)), new Vector2(200, 30)), InputManager.IM.ctrl_attack.ToString()))
            {
                if (waitingForKey == false)
                {
                    waitingForKey = true;
                    InputManager.IM.ctrl_attack = Perform_Key_Assignment();
                }
            }
            if(GUI.Button(new Rect(new Vector2((int)(Screen.width / 2 - (Screen.width * .1)), (int)((Screen.height * .2) * 2.8)), new Vector2(200, 30)), InputManager.IM.ctrl_sneak.ToString()))
            {
                if (waitingForKey == false)
                {
                    waitingForKey = true;
                    InputManager.IM.ctrl_sneak = Perform_Key_Assignment();
                }
            }
            if(GUI.Button(new Rect(new Vector2((int)(Screen.width / 2 - (Screen.width * .1)), (int)((Screen.height * .2) * 3.1)), new Vector2(200, 30)), InputManager.IM.key_interact.ToString()))
            {
                if (waitingForKey == false)
                {
                    waitingForKey = true;
                    InputManager.IM.ctrl_interact = Perform_Key_Assignment();
                }
            }
            if(GUI.Button(new Rect(new Vector2((int)(Screen.width / 2 - (Screen.width * .1)), (int)((Screen.height * .2) * 3.4)), new Vector2(200, 30)), InputManager.IM.ctrl_inventory.ToString()))
            {
                if (waitingForKey == false)
                {
                    waitingForKey = true;
                    InputManager.IM.ctrl_inventory = Perform_Key_Assignment();
                }
            }
            if(GUI.Button(new Rect(new Vector2((int)(Screen.width / 2 - (Screen.width * .1)), (int)((Screen.height * .2) * 3.7)), new Vector2(200, 30)), InputManager.IM.ctrl_pause.ToString()))
            {
                if(waitingForKey == false)
                {
                    waitingForKey = true;
                    InputManager.IM.ctrl_pause = Perform_Key_Assignment();
                }
            }
        }
	}

    private KeyCode Perform_Key_Assignment()
    {
		//Counter to prevent infinite loop
		int loopCount = 0;

        while(waitingForKey)
        {
            keyEvent = Event.current;

            if (keyEvent.isKey)
            {
                newKey = keyEvent.keyCode;
                waitingForKey = false;
            }
			loopCount++;
			if (loopCount >= 100000) 
			{
				return KeyCode.A;
			}
        }

        return newKey;


    }


}
