﻿using UnityEngine.Networking;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componentsToDisable;

    [SerializeField]
    string remoteLayerName = "RemotePlayer";
    Camera sceneCamera;

     void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i= 0; i<componentsToDisable.Length; i++)
            {
                DisableComponents();
                AssignRemoteLayer();
            }
        }else
        {
            sceneCamera = Camera.main;
            if (sceneCamera !=null)
            {

                sceneCamera.gameObject.SetActive(false);

            }
            
        }

        GetComponent < Player>().Setup();

    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();

        GameManager.RegisterPlayer(_netID, _player);
    }


    void AssignRemoteLayer ()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }

    void DisableComponents ()
    {
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = false;
        }
    }

     void OnDisable()
    {
        if (sceneCamera !=null)
        {
            sceneCamera.gameObject.SetActive(true);
        }

        GameManager.UnRegisterPlayer(transform.name);
    }



}
