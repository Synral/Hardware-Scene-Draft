using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour {

    [SerializeField] Camera _camera;
    [SerializeField] PlayerInput _input;
    [SerializeField] GameObject _object;
    [SerializeField] GameObject inputList;
    [SerializeField] GameObject textList;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject loseText;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] TextMeshProUGUI _list;
    [SerializeField] TextMeshProUGUI _inputs;
    [SerializeField] float _cameraRotationSpeed;
    InputAction _leftClickAction => _input.actions["LeftClick"];
    InputAction _rightClickAction => _input.actions["RightClick"];
    InputAction _mouseDeltaAction => _input.actions["mouseDelta"];
    InputAction _mousePositionAction => _input.actions["mousePosition"];
    string[] _buttons = { "Left Joystick", "Right Joystick", "A Button", "B Button", "X Button", "Y Button", "Left Trigger", "Right Trigger", "Left Bumper", "Right Bumper", "Home Button", "Start Button", "Select Button", "D-pad Up", "D-pad Right", "D-pad Left", "D-pad Down" };
    List<string> _inputList = new List<string>();
    bool _lmbClick => _leftClickAction.ReadValue<float>() > 0f;
    bool _rmbClick => _rightClickAction.ReadValue<float>() > 0f;
    Vector2 _mouseDelta => _mouseDeltaAction.ReadValue<Vector2>();
    Vector2 _mousePosition => _mousePositionAction.ReadValue<Vector2>();
    bool _start = false;

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
            if(Physics.Raycast(ray, out hit, 2000f)) {
                if(_buttons.Contains(hit.transform.name) && _text.text != hit.transform.name) {
                    _text.text = hit.transform.name;
                    if(_start) {
                        _inputList.Add(_text.text);
                        _inputs.text = String.Join(", ", _inputList);
                    }
                }
            }
        }
    }

    IEnumerator MoveCamera() {
        while(_holdingRMB) {
            _object.transform.RotateAround(_object.transform.position, Vector3.up, -_cameraRotationSpeed * _mouseDelta.x);
            _object.transform.RotateAround(_object.transform.position, Vector3.right, _cameraRotationSpeed * _mouseDelta.y);
            yield return new WaitForEndOfFrame();
        }
    }

    public void ToggleGame() {
        _start = !_start;
        if(_start) {
            textList.SetActive(true);
            inputList.SetActive(true);
        }
        else {
            textList.SetActive(false);
            inputList.SetActive(false);
            _inputList.Clear();
            if (_list.text == _inputs.text)
                StartCoroutine(Results(true));
            else
                StartCoroutine(Results(false));
            _inputs.text = "";
        }
    }

    IEnumerator Results(bool yn) {
        if (yn) {
            winText.SetActive(true);
            yield return new WaitForSeconds(5f);
            winText.SetActive(false);
        }
        else {
            loseText.SetActive(true);
            yield return new WaitForSeconds(5f);
            loseText.SetActive(false);
        }
        yield break;
    }
}
