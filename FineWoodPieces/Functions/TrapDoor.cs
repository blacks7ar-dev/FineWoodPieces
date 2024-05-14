using UnityEngine;

namespace FineWoodPieces.Functions;

public class TrapDoor : MonoBehaviour, Hoverable, Interactable
{
    public string m_name = "door";
    public bool m_checkGuardStone = true;
    public EffectList m_openEffects = new();
    public EffectList m_closeEffects = new();
    public ZNetView m_nview;
    public Animator m_animator;

    public void Awake()
    {
        m_nview = GetComponent<ZNetView>();
        if (m_nview.GetZDO() == null) return;
        m_animator = GetComponentInChildren<Animator>();
        if (m_nview)
        {
            m_nview.Register<bool>("UseTrapDoor", RPC_UseTrapDoor);
        }

        InvokeRepeating(nameof(UpdateState), 0f, 0.2f);
    }

    public void UpdateState()
    {
        if (!m_nview.IsValid()) return;
        var @int = m_nview.GetZDO().GetInt(ZDOVars.s_state);
        SetState(@int);
    }

    public void SetState(int state)
    {
        if (m_animator.GetInteger("state") == state) return;
        if (state != 0)
        {
            m_openEffects.Create(transform.position, transform.rotation);
        }
        else
        {
            m_closeEffects.Create(transform.position, transform.rotation);
        }

        m_animator.SetInteger("state", state);
    }

    public string GetHoverText()
    {
        if (!m_nview.IsValid()) return "";
        if (Plugin._hideTrapDoorHoverText.Value == Toggle.On) return "";
        if (m_checkGuardStone && !PrivateArea.CheckAccess(transform.position, 0f, false))
        {
            return Localization.instance.Localize(m_name + "\n$piece_noaccess");
        }
        if (m_nview.GetZDO().GetInt(ZDOVars.s_state) != 0)
        {
            return Localization.instance.Localize(m_name + "\n[<color=yellow><b>$KEY_Use</b></color>] " +
                                                  "$piece_door_close");
        }

        return Localization.instance.Localize(m_name + "\n[<color=yellow><b>$KEY_Use</b></color>] " +
                                              "$piece_door_open");
    }

    public string GetHoverName()
    {
        return m_name;
    }

    public bool Interact(Humanoid character, bool hold, bool alt)
    {
        if (hold) return false;
        if (m_checkGuardStone && !PrivateArea.CheckAccess(transform.position)) return true;
        var val = character.transform.position - transform.position;
        var normalized = val.normalized;
        Game.instance.IncrementPlayerStat((m_nview.GetZDO().GetInt(ZDOVars.s_state) == 0)
            ? PlayerStatType.DoorsOpened
            : PlayerStatType.DoorsClosed);
        Open(normalized);
        return true;
    }

    public void Open(Vector3 userDir)
    {
        var flag = Vector3.Dot(transform.up, userDir) < 0f;
        m_nview.InvokeRPC("UseTrapDoor", flag);
    }

    public bool UseItem(Humanoid user, ItemDrop.ItemData item)
    {
        return false;
    }

    public void RPC_UseTrapDoor(long uid, bool forward)
    {
        if (m_nview.GetZDO().GetInt(ZDOVars.s_state) == 0)
        {
            if (forward)
            {
                m_nview.GetZDO().Set(ZDOVars.s_state, 1);
            }
            else
            {
                m_nview.GetZDO().Set(ZDOVars.s_state, -1);
            }
        }
        else
        {
            m_nview.GetZDO().Set(ZDOVars.s_state, 0);
        }
        UpdateState();
    }
}