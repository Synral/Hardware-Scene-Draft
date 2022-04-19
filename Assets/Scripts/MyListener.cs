using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class MyListener : MonoBehaviour {
    [SerializeField] TextMeshProUGUI _text;
    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg) {
        _text.text = msg;
    }
    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success) {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
}