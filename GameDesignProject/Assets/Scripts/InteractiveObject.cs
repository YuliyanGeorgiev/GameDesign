using UnityEngine;
using System.Collections;

public class InteractiveObject : MonoBehaviour
{
    public enum eInteractiveState
    {
        Active, //Open
        Inactive, //Close

    }

    private eInteractiveState m_state;

    void Start()
    {
        m_state = eInteractiveState.Inactive;
    }

    public void TriggerInteraction()
    {
        if (!GetComponent<Animation>().isPlaying)
        {
            Debug.Log("Interactive object");
            switch (m_state)
            {
                case eInteractiveState.Active:
                    GetComponent<Animation>().Play("Close");
                    m_state = eInteractiveState.Inactive;
                    break;
                case eInteractiveState.Inactive:
                    GetComponent<Animation>().Play("Open");
                    m_state = eInteractiveState.Active;
                    break;
                default:
                    break;
            }
        }
    }
}
