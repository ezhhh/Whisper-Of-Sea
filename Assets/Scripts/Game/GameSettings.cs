using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance { get; private set; }

    private void Start() => Instance = this;
    

    public bool RawInput = true;

    public KeyCode InteractKey = KeyCode.E;
    public KeyCode BestiariyKey = KeyCode.I;
    public KeyCode JumpKey = KeyCode.Space;
    public KeyCode RunKey = KeyCode.LeftControl;
    public KeyCode CrouchKey = KeyCode.LeftShift;

    public bool IsPressed(KeyCode key)
    {
        return Input.GetKeyDown(key);  
    }

    public bool IsDown(KeyCode key)
    {
        return Input.GetKey(key);
    }

    public float ReadAxis(string axis)
    {
        return RawInput ? Input.GetAxisRaw(axis) : Input.GetAxis(axis);
    }
}
