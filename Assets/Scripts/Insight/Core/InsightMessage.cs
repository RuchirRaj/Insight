﻿using Mirror;

namespace Insight{
    public class EmptyReply : MessageBase
    {

    }

    //Test msgs for Demo only
    public class ClientToZoneTestMsg : MessageBase
    {
        public static short MsgId = 1000;
        public string Source;
        public string Desintation;
        public string Data;
    }

    //Test msgs for Demo only
    public class ClientToMasterTestMsg : MessageBase
    {
        public static short MsgId = 1001;
        public string Source;
        public string Desintation;
        public string Data;
    }

    //Test msgs for Demo only
    public class ZoneToMasterTestMsg : MessageBase
    {
        public static short MsgId = 1002;
        public string Source;
        public string Desintation;
        public string Data;
    }

    //Test msg for ZoneModule
    public class RegisterZoneMsg : MessageBase
    {
        public static short MsgId = 9090;
        public string UniqueID;
        public string ScenePath;
        public string NetworkAddress;
        public int NetworkPort;
        public int MaxPlayers;
        public int CurentPlayers;
    }

    //Test msg for ZoneModule
    public class UnregisterZoneMsg : MessageBase
    {
        public static short MsgId = 9091;
        public string UniqueID;
    }

    //Test msg for ZoneModule
    public class GetZonesMsg : MessageBase
    {
        public static short MsgId = 9092;
        public ZoneContainer[] zonesList;
    }
}