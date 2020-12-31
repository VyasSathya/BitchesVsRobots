using UnityEngine;
using Mirror;


    // Custom NetworkManager that simply assigns the correct racket positions when
    // spawning players. The built in RoundRobin spawn method wouldn't work after
    // someone reconnects (both players would be on the same side).

    public class NetworkManagerBVP : NetworkManager
    {

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            // add player at correct spawn position

            GameObject player = Instantiate(playerPrefab, new Vector3(0.205705f, 0.49f, -0.03258991f), 
                 Quaternion.identity);
            NetworkServer.AddPlayerForConnection(conn, player);


            
        }

        public override void OnServerDisconnect(NetworkConnection conn)
        {


            // call base functionality (actually destroys the player)
            base.OnServerDisconnect(conn);
        }
    }
