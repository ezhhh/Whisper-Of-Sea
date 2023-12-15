using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Volume))]
public class SpawnEffect : MonoBehaviour
{
    private Volume _volume;
    private ColorAdjustments _colorAdjustments;

    [SerializeField] private float _targetExposure = 0;
    [SerializeField] private float _startExposure = 10;
    [SerializeField] private float _speed = 0.25f;

    private void Start()
    {
        _volume = GetComponent<Volume>();

        if (_volume.profile.TryGet(out ColorAdjustments colorAdjustments))
        {
            _colorAdjustments = colorAdjustments;
            _colorAdjustments.postExposure.value = _startExposure;
        }
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        while (_colorAdjustments.postExposure.value > _targetExposure)
        {
            _colorAdjustments.postExposure.value = Mathf.Lerp(_colorAdjustments.postExposure.value, _targetExposure, _speed);
            yield return new WaitForSeconds(0.02f);
        }
    }
}
