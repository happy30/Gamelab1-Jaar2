using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    public InputManager instance;

    public static KeyCode Slash = KeyCode.Z;
    public static KeyCode Shuriken = KeyCode.X;
    public static KeyCode Hook = KeyCode.C;
    public static KeyCode SmokeBomb = KeyCode.V;

    void Start()
    {
        if (instance)
        {
            return;
        }

        if (PlayerPrefs.HasKey("keya"))
        {
            Slash = (KeyCode)PlayerPrefs.GetInt("keya");
        }
        if (PlayerPrefs.HasKey("keyb"))
        {
            Shuriken = (KeyCode)PlayerPrefs.GetInt("keyb");
        }
        if (PlayerPrefs.HasKey("keyc"))
        {
            Hook = (KeyCode)PlayerPrefs.GetInt("keyc");
        }
        if (PlayerPrefs.HasKey("keyd"))
        {
            SmokeBomb = (KeyCode)PlayerPrefs.GetInt("keyd");
        }

        instance = this;
    }
}

