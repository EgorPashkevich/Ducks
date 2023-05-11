using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PistolFire : MonoBehaviour
{
    private Interactable interactable;

    public AudioSource AudioSource;
    public SteamVR_Action_Boolean fireAction;
    public Transform Barol;
    public ParticleSystem HitEffects;

    public int Damage = 1;

    private void Start() {
        interactable = GetComponent<Interactable>();
    }

    private void Update() {
        if (interactable.attachedToHand != null) {
            SteamVR_Input_Sources hand = interactable.attachedToHand.handType;

            if (fireAction[hand].stateDown) {
                Fire();
            }
        }
    }

    private void Fire() {

        HitEffects.Play();
        AudioSource.Play();

        RaycastHit hit;
        if (Physics.Raycast(Barol.position, Barol.forward, out hit, 300)) {
            if (hit.transform.GetComponent<Enemy>()) {
                hit.transform.GetComponent<Enemy>().TakeDamage(Damage);
            }
            
        }
    }

}
