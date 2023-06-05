using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGameObject : MonoBehaviour
{
    public GameObject _gameObject;

    public void Activate()
    {
        _gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        _gameObject.SetActive(false);
    }
}
