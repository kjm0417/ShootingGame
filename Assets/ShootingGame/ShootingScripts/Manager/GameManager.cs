using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPool;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private string PlayerTag;

    public Transform Player {  get; private set; }

    public ObjectPool pool { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
           Destroy(gameObject);
        }
        Instance = this;

        Player = GameObject.FindGameObjectWithTag(PlayerTag).transform;

        pool = GameObject.FindObjectOfType<ObjectPool>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
