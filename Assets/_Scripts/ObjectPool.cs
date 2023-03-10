using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Preallocation
{
    public GameObject gameObject;
    public int count;
    public bool expandable;   //phat sinh them object neu khong du dung
}

public class ObjectPool : MonoSingleton<ObjectPool>
{
    public List<Preallocation> preAllocations;
    [SerializeField]
    private Transform holder;
    [SerializeField]
    List<GameObject> pooledGobjects;  //spawn all needed gameobject

    protected override void Awake() {
        base.Awake();
        InitObjectPoolList();
    }

    private void InitObjectPoolList()
    {
        pooledGobjects = new List<GameObject>();   //spawn all needed gameobject

        foreach (Preallocation item in preAllocations)
        {
            for (int i = 0; i < item.count; ++i)
            {
                pooledGobjects.Add(CreateGobject(item.gameObject));
            }
        }
    }

    public GameObject Spawn(string tag)
    {
        for (int i = 0; i < pooledGobjects.Count; ++i)
        {
            if (!pooledGobjects[i].activeSelf && pooledGobjects[i].CompareTag(tag))
            {
                pooledGobjects[i].SetActive(true);
                return pooledGobjects[i];
            }
        }

        for (int i = 0; i < preAllocations.Count; ++i)
        {
            if (preAllocations[i].gameObject.CompareTag(tag))
                if (preAllocations[i].expandable)
                {
                    GameObject obj = CreateGobject(preAllocations[i].gameObject);
                    pooledGobjects.Add(obj);
                    obj.SetActive(true);
                    return obj;
                }
        }
        return null;
    }

    GameObject CreateGobject(GameObject item)
    {
        GameObject gobject = Instantiate(item, holder);
        gobject.SetActive(false);
        return gobject;
    }

    public void SetObjectPoolState(bool state, string tag)
    {
        for (int i = 0; i < pooledGobjects.Count; ++i)
        {
            if (pooledGobjects[i].activeSelf && pooledGobjects[i].CompareTag(tag))
            {
                pooledGobjects[i].SetActive(state);
            }
        }
    }
}

