using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour {

    [SerializeField] Camera _camera;
    [SerializeField] PlayerInput _input;
    [SerializeField] GameObject _object;
    [SerializeField] float _cameraRotationSpeed;
    InputAction _leftClickAction => _input.actions["LeftClick"];
    InputAction _rightClickAction => _input.actions["RightClick"];
    InputAction _mouseDeltaAction => _input.actions["mouseDelta"];
    InputAction _mousePositionAction => _input.actions["mousePosition"];

    bool _lmbClick => _leftClickAction.ReadValue<float>() > 0f;
    bool _rmbClick => _rightClickAction.ReadValue<float>() > 0f;
    Vector2 _mouseDelta => _mouseDeltaAction.ReadValue<Vector2>();
    Vector2 _mousePosition => _mousePositionAction.ReadValue<Vector2>();

    bool _holdingRMB;
    // Update is called once per frame
    void Update() {
        if(_rmbClick && !_holdingRMB) {
            _holdingRMB = true;
            StartCoroutine(MoveCamera());
        }
        else if(!_rmbClick)
            _holdingRMB = false;

        if(_lmbClick) {
            Ray ray = _camera.ViewportPointToRay(new Vector3(_mousePosition.x / Screen.width, _mousePosition.y / Screen.height, 0f));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
                Debug.Log("Action: " + hit.transform.name);
        }
    }

    IEnumerator MoveCamera() {
        while(_holdingRMB) {
            _object.transform.RotateAround(_object.transform.position, Vector3.up, -_cameraRotationSpeed * _mouseDelta.x);
            _object.transform.RotateAround(_object.transform.position, Vector3.right, _cameraRotationSpeed * _mouseDelta.y);
            yield return new WaitForEndOfFrame();
        }
    }
}
