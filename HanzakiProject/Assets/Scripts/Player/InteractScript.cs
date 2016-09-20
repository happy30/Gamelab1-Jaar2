//InteractScript by Jordi

using UnityEngine;
using System.Collections;

public class InteractScript : MonoBehaviour
{
    public enum InteractType
    {
        OnTrigger,
        OnInput
    };

    public InteractType interactType;
    public GameObject linkedObject;
}
