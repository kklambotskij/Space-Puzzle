using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionSender : MonoBehaviour
{
    public void LoadNext()
    {
        GameMachine.Instance.LoadNext();
    }
}
