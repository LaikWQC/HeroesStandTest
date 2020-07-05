using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private string heroName = null;
    void Start()
    {
        GameManager.Inst.HeroSubscribe(GetComponent<Unit>(), heroName);
        gameObject.name = heroName;
    }
}
