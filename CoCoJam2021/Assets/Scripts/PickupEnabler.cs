using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupEnabler : PickupableObj
{
    // Start is called before the first frame update
    override protected void TriggerEffect()
    {
        base.TriggerEffect();

        lockedInteractable.gameObject.SetActive(true);
    }
}
