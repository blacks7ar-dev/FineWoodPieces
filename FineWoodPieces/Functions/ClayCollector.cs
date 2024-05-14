using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FineWoodPieces.Functions;

public class ClayCollector : MonoBehaviour, Hoverable, Interactable
{
    public string m_name;
    public Transform m_spawnPoint;
    public float m_secPerUnit = 10f;
    public int m_maxClay = 4;
    public ItemDrop m_clayItem;
    public EffectList m_spawnEffect = new();
    public GameObject m_enabledObject;

    public Heightmap.Biome m_biome;

    [Header("Texts")]
    public string m_extractText = "$bcp_claycollector_extract";
    public string m_collectingText = "$bcp_claycollector_collecting";
    public string m_notConnectedText = "$bcp_claycollector_notconnected";
    public string m_fullText = "$bcp_claycollector_full";

    public ZNetView m_nview;
    private Collider m_collider;
    private Piece m_piece;
    private bool m_connected;

    public void Awake()
    {
        m_nview = GetComponent<ZNetView>();
        m_collider = GetComponentInChildren<Collider>();
        m_piece = GetComponent<Piece>();
        if (m_nview.GetZDO() == null) return;
        if (m_nview.IsOwner() && m_nview.GetZDO().GetLong(ZDOVars.s_lastTime, 0L) == 0L)
        {
            m_nview.GetZDO().Set(ZDOVars.s_lastTime, ZNet.instance.GetTime().Ticks);
        }
        m_nview.Register("RPC_Extract", RPC_Extract);
        m_nview.Register("RPC_UpdateEffects", RPC_UpdateEffects);
        InvokeRepeating(nameof(UpdateTicks), Random.Range(0f, 2f), 5f);
    }

    public string GetHoverText()
    {
        if (!PrivateArea.CheckAccess(transform.position, 0f, false))
        {
            return Localization.instance.Localize(m_name + "\n$bcp_noaccess");
        }
        var level = GetTarLevel();
        var statusText = GetStatusText();
        string text;
                   
        if (m_connected)
        {
            text = m_name + "\n( " + statusText + ", " + level + " / " + m_maxClay + " ) " + $"<color=orange>{TimeLeft()}</color>";
        }
        else
        {
            text = m_name + "\n( " + statusText + ", " + level + " / " + m_maxClay + " ) ";
        }
        
        if (level > 0)
        {
            text = text + "\n[<color=yellow><b>$KEY_Use</b></color>] " + m_extractText;
        }

        return Localization.instance.Localize(text);
    }

    public string GetHoverName()
    {
        return m_name;
    }

    public bool Interact(Humanoid character, bool repeat, bool alt)
    {
        if (repeat) return false;
        if (!PrivateArea.CheckAccess(transform.position)) return true;
        if (GetTarLevel() <= 0) return false;
        Extract();
        return true;
    }

    public string GetStatusText()
    {
        if (GetTarLevel() >= m_maxClay)
        {
            return m_fullText;
        }

        if (!m_connected)
        {
            return m_notConnectedText;
        }
        
        return m_collectingText;
    }

    public bool UseItem(Humanoid user, ItemDrop.ItemData item)
    {
        return false;
    }

    public void Extract()
    {
        m_nview.InvokeRPC("RPC_Extract");
    }

    public void RPC_Extract(long caller)
    {
        var tarLevel = GetTarLevel();
        if (tarLevel <= 0) return;
        m_spawnEffect.Create(m_spawnPoint.position, Quaternion.identity);
        for (var i = 0; i < tarLevel; i++)
        {
            var val = Random.insideUnitCircle * 0.5f;
            var val2 = m_spawnPoint.position + new Vector3(val.x, 0.25f * i, val.y);
            Instantiate(m_clayItem, val2, Quaternion.identity);
        }

        ResetLevel();
        m_nview.InvokeRPC(ZNetView.Everybody, "RPC_UpdateEffects");
    }

    private float GetTimeSinceLastUpdate()
    {
        var dateTime = new DateTime(m_nview.GetZDO().GetLong(ZDOVars.s_lastTime, ZNet.instance.GetTime().Ticks));
        var time = ZNet.instance.GetTime();
        var timeSpan = time - dateTime;
        m_nview.GetZDO().Set(ZDOVars.s_lastTime, time.Ticks);
        var num = timeSpan.TotalSeconds;
        if (num < 0.0)
        {
            num = 0.0;
        }

        return (float)num;
    }

    public void ResetLevel()
    {
        m_nview.GetZDO().Set(ZDOVars.s_level, 0);
    }

    public void IncreaseLevel(int i)
    {
        var tarLevel = GetTarLevel();
        tarLevel += i;
        tarLevel = Mathf.Clamp(tarLevel, 0, m_maxClay);
        m_nview.GetZDO().Set(ZDOVars.s_level, tarLevel);
    }

    private int GetTarLevel()
    {
        return m_nview.GetZDO() == null ? 0 : m_nview.GetZDO().GetInt(ZDOVars.s_level);
    }

    public void UpdateTicks()
    {
        if (CheckBiome() && !m_connected)
        {
            var array = Physics.OverlapSphere(transform.position, 0.2f);
            foreach (var t in array)
            {
                var component = t.GetComponentInParent<LiquidVolume>();
                if (component == null) continue;
                if (component.m_liquidType != LiquidType.Water) continue;
                m_connected = true;
                break;
            }
        }
        
        var flag = CheckBiome() && m_connected;
        if (m_nview.IsOwner() && flag)
        {
            var timeSinceLastUpdate = GetTimeSinceLastUpdate();
            if (GetTarLevel() < m_maxClay)
            {
                var @float = m_nview.GetZDO().GetFloat(ZDOVars.s_product);
                @float += timeSinceLastUpdate;
                if (@float > m_secPerUnit)
                {
                    var i = (int)(@float / m_secPerUnit);
                    IncreaseLevel(i);
                    @float = 0f;
                }
                m_nview.GetZDO().Set(ZDOVars.s_product, @float);
            }
        }

        UpdateEffects();
    }

    public void RPC_UpdateEffects(long caller)
    {
        UpdateEffects();
    }

    public void UpdateEffects()
    {
        var level = GetTarLevel();
        var active = level < m_maxClay && m_connected && GetStatusText() == m_collectingText;
        m_enabledObject.SetActive(active);
    }

    private bool CheckBiome()
    {
        return (Heightmap.FindBiome(transform.position) & m_biome) != 0;
    }

    private string TimeLeft()
    {
        var result = "";
        if (GetTarLevel() == m_maxClay) return result;
        if (!m_nview.IsValid() || !m_nview.IsOwner()) return result;
        var @float = m_nview.GetZDO().GetFloat(ZDOVars.s_product);
        var num = m_secPerUnit - @float;
        var mins = Mathf.FloorToInt((int)num / 60);
        var secs = Mathf.FloorToInt((int)num % 60);
        result = $"[ {mins:00}:{secs:00} ]";
        return result;
    }
}