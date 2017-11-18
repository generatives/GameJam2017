using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour
{
    public float RespawnTime;

    private List<GameObjectRespawn> _respawns = new List<GameObjectRespawn>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(isServer)
        {
            List<int> toRemove = new List<int>();
            for (int i = 0; i < _respawns.Count; i++)
            {
                var respawn = _respawns[i];
                respawn.TimeRemaining = respawn.TimeRemaining - Time.deltaTime;
                if (respawn.TimeRemaining <= 0)
                {
                    RespawnGameobj(respawn.Obj);
                    toRemove.Add(i);
                }
            }

            for (int i = 0; i < toRemove.Count; i++)
            {
                _respawns.RemoveAt(toRemove[i]);
            }
        }
	}

    private void RespawnGameobj(GameObject obj)
    {
        var positions = GameObject.FindObjectsOfType<NetworkStartPosition>();
        var index = Random.Range(0, positions.Length);
        var position = positions[index];
        obj.transform.position = position.transform.position;
        obj.SetActive(true);
    }

    public void GameObjectDied(GameObject obj)
    {
        _respawns.Add(new GameObjectRespawn() { Obj = obj, TimeRemaining = RespawnTime });
        obj.SetActive(false);
    }

    private class GameObjectRespawn
    {
        public GameObject Obj;
        public float TimeRemaining;
    }
}
