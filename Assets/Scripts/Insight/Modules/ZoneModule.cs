﻿using Insight;
using Mirror;
using System;
using System.Collections.Generic;

public class ZoneModule : InsightModule
{
    InsightServer insightServer;

    public List<ZoneContainer> ZoneList = new List<ZoneContainer>();

    public override void Initialize(InsightServer server)
    {
        insightServer = server;
    }

    public override void RegisterHandlers()
    {
        insightServer.RegisterHandler(RegisterZoneMsg.MsgId, HandleRegisterZoneMsg);
        insightServer.RegisterHandler(UnregisterZoneMsg.MsgId, HandleUnregisterZoneMsg);
        insightServer.RegisterHandler(GetZonesMsg.MsgId, HandleGetZonesMsg);
    }

    private void HandleRegisterZoneMsg(InsightNetworkMessage netMsg)
    {
        print("HandleRegisterZoneMsg");

        RegisterZoneMsg message = netMsg.ReadMessage<RegisterZoneMsg>();

        ZoneList.Add(new ZoneContainer()
        {
            UniqueID = message.UniqueID,
            ScenePath = message.ScenePath,
            NetworkAddress = message.NetworkAddress,
            NetworkPort = message.NetworkPort,
            MaxPlayers = message.MaxPlayers,
            CurentPlayers = message.CurentPlayers
        });
    }

    private void HandleUnregisterZoneMsg(InsightNetworkMessage netMsg)
    {
        print("HandleUnregisterZoneMsg");

        UnregisterZoneMsg message = netMsg.ReadMessage<UnregisterZoneMsg>();

        foreach(ZoneContainer zone in ZoneList)
        {
            if(zone.UniqueID.Equals(message.UniqueID))
            {
                ZoneList.Remove(zone);
            }
        }
    }

    private void HandleGetZonesMsg(InsightNetworkMessage netMsg)
    {
        //Request from Server for a list of all active Zones

        netMsg.conn.Send(GetZonesMsg.MsgId, new GetZonesMsg() { zonesList = ZoneList.ToArray() });
    }
}

[Serializable]
public struct ZoneContainer
{
    public string UniqueID;
    public string ScenePath;
    public string NetworkAddress;
    public int NetworkPort;
    public int MaxPlayers; //Distated by the current zone
    public int CurentPlayers;
}