using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;

namespace Main
{
    public class NetworkManager : MonoBehaviour{
        
        public GameObject playerPrefab;
        GameObject player;
        // Start is called before the first frame update
        private Socket socket;



        void Start(){
            var serverEndpoint="http://localhost:3000";
            socket = Socket.Connect(serverEndpoint);
            // Debug.Log(typeof(socket));
            socket.On(SystemEvents.connect, () => {
                Debug.Log("Connected To Server");
                player=Instantiate(playerPrefab,new Vector3(0, 0, 0), Quaternion.identity);
                socket.Emit("init","Player Data");
                

                InvokeRepeating("SendPosition", 0f, 0.5f);


                socket.On("remoteDate",(string data)=>{
                    Debug.Log("Remote Data:"+data);
                });
            });

            socket.On(SystemEvents.reconnect, (int reconnectAttempt) => {
                Debug.Log("Hello, Again! " + reconnectAttempt);
            });

            socket.On(SystemEvents.disconnect, () => {
                Debug.Log("Disconnected");
            });

            socket.On("setId", (string id)=>{
                Debug.Log(id);
            });

            socket.On("remoteData", (string data)=>{
                Debug.Log(data);
            });

        }

        void SendPosition(){
            Vector3 pos=player.transform.position;
            Debug.Log(pos);
            Debug.Log(pos.x);

            var position=pos.x+","+pos.y+","+pos.z;

            socket.Emit("update",position);
            
        }
    }
}

