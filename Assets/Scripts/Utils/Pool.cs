using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    private GameObject poolObject;
    private List<GameObject> listOfObjects;

    #region Public API

    public void NewPool(GameObject poolObject)
    {
        this.poolObject = poolObject;
        listOfObjects = new List<GameObject>();
    }

    public GameObject NewObject()
    {
        return NewObject(Vector3.zero);
    }

    public GameObject NewObject(Vector3 newPosition)
    {
        GameObject newObject = listOfObjects.Find(n => !n.activeSelf);

        if (newObject == null)
        {
            newObject = MonoBehaviour.Instantiate(poolObject, newPosition, Quaternion.identity);
            listOfObjects.Add(newObject);
        }
        else
        {
            newObject.transform.position = newPosition;
            newObject.SetActive(true);
        }

        return newObject;
    }

    public void RemoveObject(GameObject activatedObject)
    {
        activatedObject.SetActive(false);
    }

    #endregion
}
