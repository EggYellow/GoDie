using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.GlobeDefine
{
    public partial class GlobeVar
    {
        // 采矿音效Id
        public const int SOUND_MINE_ID = -1;
        // 捕猎音效Id
        public const int SOUND_HUNT_ID = -1;
        // 垂钓音效Id
        public const int SOUND_FISH_ID = -1;
        // 砍树音效Id
        public const int SOUND_CUT_ID = -1;
    }

    // 采集物类型
    public enum ECollectType
    {
        ECOLLECT_NONE = -1,
        ECOLLECT_MINING,        // 采矿
        ECOLLECT_HUNTING,       // 捕猎
        ECOLLECT_FISHING,       // 钓鱼
        ECOLLECT_CUTTING,       // 砍树

        ECOLLECT_MAX
    }
}
