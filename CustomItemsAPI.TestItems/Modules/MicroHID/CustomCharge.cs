using Interactables;
using Interactables.Interobjects;
using InventorySystem.Items.MicroHID.Modules;
using PlayerRoles;
using UnityEngine;

namespace CustomItemsAPI.TestItems.Modules.MicroHID;

public class CustomCharge : CustomFiringModeControllerModule
{
    public CustomCharge() : base(MicroHidFiringMode.ChargeFire)
    {
        CL.Info("CustomCharge.ctor");
    }

    public override bool VirtualValidateEnterFire()
    {
        return InputSync.Primary;
    }

    public override bool VirtualValidateUpdate()
    {
        if ((InputSync.Primary || InputSync.Secondary) && Energy > 0f)
        {
            return !Broken;
        }

        return false;
    }

    public override bool VirtualValidateStart()
    {
        if (InputSync.Secondary)
        {
            return !Broken;
        }

        return false;
    }

    public float raycastThickness = 0.65f;
    public float damage = 1000f;

    public override void ServerUpdateSelected(MicroHidPhase status)
    {
        switch (status)
        {
            case MicroHidPhase.Firing:
                ServerRequestBacktrack(BacktrackServerFire);
                break;
        }
    }
    public virtual void BacktrackServerFire()
    {
        try
        {
            Transform playerCameraReference = Item.Owner.PlayerCameraReference;
            HitregUtils.Raycast(playerCameraReference, raycastThickness, FiringRange, out var detections);
            foreach (IDestructible detectedDestructible in HitregUtils.DetectedDestructibles)
            {
                detectedDestructible.ServerDealDamage(this, 1000f * Time.deltaTime);
            }

            for (int i = 0; i < detections; i++)
            {
                if (HitregUtils.DetectionsNonAlloc[i].TryGetComponent<InteractableCollider>(out var component) && CheckIntercolLineOfSight(playerCameraReference.position, component))
                {
                    HandlePotentialDoor(component);
                }
            }
        }
        catch (Exception ex)
        {
            CL.Error(ex);
        }
    }

    public void HandlePotentialDoor(InteractableCollider interactable)
    {
        if (interactable.Target is BreakableDoor breakableDoor && !breakableDoor.TargetState && breakableDoor.AllowInteracting(Item.Owner, interactable.ColliderId) && (breakableDoor.ActiveLocks & (ushort)~(int)ChargeFireModeModule.BypassableLocks) == 0)
        {
            breakableDoor.NetworkTargetState = true;
        }
    }

    public bool CheckIntercolLineOfSight(Vector3 originPoint, InteractableCollider collider)
    {
        Transform transform = collider.transform;
        Vector3 end = transform.position + transform.TransformDirection(collider.VerificationOffset);
        if (Physics.Linecast(originPoint, end, out var hitInfo, PlayerRolesUtils.AttackMask))
        {
            return hitInfo.collider.transform == transform;
        }

        return true;
    }
}
