using UnityEngine;
using System.Collections;

public static class InputName
{
    public static string LeftHorizontalJoystick { get { return "Left_Horizontal_Joystick"; } }
    public static string LeftVerticalJoystick { get { return "Left_Vertical_Joystick"; } }
    public static string RightHorizontalJoystick { get { return "Right_Horizontal_Joystick"; } }
    public static string RightVerticalJoystick { get { return "Right_Vertical_Joystick"; } }

    public static string LeftHorizontalKeyboard { get { return "Left_Horizontal_Keyboard"; } }
    public static string LeftVerticalKeyboard { get { return "Left_Vertical_Keyboard"; } }
    public static string RightHorizontalKeyboard { get { return "Right_Horizontal_Keyboard"; } }
    public static string RightVerticalKeyboard { get { return "Right_Vertical_Keyboard"; } }

    public static string Ability1 { get { return "Button_Ability1"; } }
    public static string Ability2 { get { return "Button_Ability2"; } }
    public static string Ability3 { get { return "Button_Ability3"; } }

    public static string PrimaryFire { get { return "Button_PrimaryFire"; } }
    public static string SecondaryFire { get { return "Button_SecondaryFire"; } }

    public static string Jump { get { return "Button_Jump"; } }
}

public static class InputManager
{
	// -- Axis
	public static float LeftHorizontal()
	{
		Debug.Log("meh");
		float r = 0.0f;
		r += Input.GetAxis (InputName.LeftHorizontalJoystick);
		r += Input.GetAxis (InputName.LeftHorizontalKeyboard);
		return Mathf.Clamp (r, -1.0f, 1.0f);
	}
	public static float LeftVertical()
	{
		float r = 0.0f;
		r += Input.GetAxis (InputName.LeftVerticalJoystick);
		r += Input.GetAxis (InputName.LeftVerticalKeyboard);
		return Mathf.Clamp (r, -1.0f, 1.0f);
	}
	public static Vector3 LeftJoystick()
	{
		return new Vector3 (LeftHorizontal (), 0, LeftVertical ());
	}

	public static float RightHorizontal()
	{
		float r = 0.0f;
		r += Input.GetAxis (InputName.RightHorizontalJoystick);
		r += Input.GetAxis (InputName.RightHorizontalKeyboard);
		return Mathf.Clamp (r, -1.0f, 1.0f);
	}
	public static float RightVertical()
	{
		float r = 0.0f;
		r += Input.GetAxis (InputName.RightVerticalJoystick);
		r += Input.GetAxis (InputName.RightVerticalKeyboard);
		return Mathf.Clamp (r, -1.0f, 1.0f);
	}
	public static Vector3 RightJoystick()
	{
		return new Vector3 (RightHorizontal (), 0, RightVertical ());
	}

    // -- Buttons
    public static bool IsHeld(string buttonName)
    {
        return Input.GetButton(buttonName);
    }
    public static bool IsDown(string buttonName)
    {
        return Input.GetButtonDown(buttonName);
    }
    public static bool IsUp(string buttonName)
    {
        return Input.GetButtonUp(buttonName);
    }
}
