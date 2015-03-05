﻿using UnityEngine;
using System.Collections;

public class AnimationHandler : MonoBehaviour {

    public LayerMask raycastLayerMask;
    public Transform rightHandHandle = null;
    public AudioClip[] rightFootSteps;
    public AudioClip[] leftFootSteps;
    public AudioClip fallingSound;

    public bool activateIK { get; set; }

    private Animator _animator;
    private Quaternion _targetRotation;
    private float _targetAngle;
    private float previousInput;
    private Transform _transform;
    private CharacterController _charController;
    private AnimatorStateInfo _currentAnimState;
    private bool _wasInAir;

    private const float HEIGHT_EVALUATION_RATE = 1.0f / 2.0f;

    static int jumpState = Animator.StringToHash("Base Layer.Jump");

	void Start()
    {
        _transform = transform;
        _animator = GetComponent<Animator>();
        _targetAngle = 0.0f;
        _targetRotation = Quaternion.Euler(new Vector3(0.0f, _targetAngle, 0.0f));
        _charController = GetComponentInParent<CharacterController>();
        _wasInAir = _charController.isGrounded;
    }

    void OnAnimatorIK()
    {
        if (!activateIK)
            return;

        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
        _animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandHandle.position);

        _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
        _animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandHandle.rotation);
    }
    
    void Update () {
        _currentAnimState = _animator.GetCurrentAnimatorStateInfo(0);

        _transform.localRotation = Quaternion.Slerp(_transform.localRotation, _targetRotation, 5.0f * Time.deltaTime);

        float input = Mathf.Abs(Input.GetAxis("Horizontal"));
        _animator.SetFloat("Speed", input);

        if (_currentAnimState.nameHash == jumpState)
        {
            _animator.SetBool("Jump", false);
        }

        if (!_wasInAir && !_charController.isGrounded)
        {
            _animator.SetBool("IsInAir", true);
            _wasInAir = true;
        }

        if (_wasInAir && _charController.isGrounded)
        {
            _animator.SetBool("IsInAir", false);
            _wasInAir = false;
        }

        if (Input.GetButtonDown("Jump") && _charController.isGrounded)
        {
            _animator.SetBool("Jump", true);
            _animator.SetBool("IsInAir", true);
            _wasInAir = true;
        }

        if (Input.GetAxis("Horizontal") > 0.0f)
        {
            _targetAngle = 0.0f;
            _targetRotation = Quaternion.Euler(new Vector3(0.0f, _targetAngle, 0.0f));
        }
        else if (Input.GetAxis("Horizontal") < 0.0f)
        {
            _targetAngle = 180.0f;
            _targetRotation = Quaternion.Euler(new Vector3(0.0f, _targetAngle, 0.0f));
        }

        if (Input.GetButtonDown("Sprint"))
            _animator.SetBool("IsSprinting", true);
        if (Input.GetButtonUp("Sprint"))
            _animator.SetBool("IsSprinting", false);
	}

    public void OnSteppedRight()
    {
        audio.clip = rightFootSteps[Random.Range(0, rightFootSteps.Length)];
        audio.Play();
    }

    public void OnSteppedLeft()
    {
        audio.clip = leftFootSteps[Random.Range(0, leftFootSteps.Length)];
        audio.Play();
    }

    public void OnFell()
    {
        audio.clip = fallingSound;
        audio.Play();
    }
    
}
