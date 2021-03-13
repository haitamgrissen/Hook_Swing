using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookAnchor : MonoBehaviour
{
    [SerializeField] GameObject indicator;
    [SerializeField] GameObject knob;

    public void isnothookedtothis() { knob.SetActive(false); }

    public void ishookedinthis() { knob.SetActive(true); }

    public void isclosetothis() { indicator.SetActive(true); }

    public void isnotclosetothis() { indicator.SetActive(false); }
}
