using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Script.Manager.Core;

namespace Script.Data
{
    #region TextData

    [Serializable]
    public class TextData
    {
        public int id;
        public string text;
    }

    [Serializable]
    public class TextDataLoader : ILoader<int, TextData>
    {
        public List<TextData> TextDatas = new List<TextData>();
        public Dictionary<int, TextData> MakeDict()
        {
            return TextDatas.GroupBy(data => data.id).ToDictionary(group => group.Key, group => group.First());
        }
    }
    #endregion

    #region Trigger

    [Serializable]
    public class TriggerData
    {
        public int id;
        [JsonProperty("ConditionList")] public List<JObject> ConditionListRaw;

        [JsonProperty("ActionList")] public List<JObject> ActionListRaw;

        [JsonIgnore] public List<Condition> ConditionList { get; private set; }

        [JsonIgnore] public List<TriggerAction> ActionList { get; private set; }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            // ConditionListRaw can be null, handle it appropriately
            // ConditionList = ConditionListRaw?.Select(ConvertJObjectToConditionData).ToList() ?? new List<Condition>();
            ConditionList =
                ConditionListRaw?.Select(new ConvertJObject<Condition>().ConvertJObjectToConditionData).ToList() ??
                new List<Condition>();
            ActionList =
                ActionListRaw?.Select(new ConvertJObject<TriggerAction>().ConvertJObjectToConditionData).ToList() ??
                new List<TriggerAction>();
        }
    }

    [Serializable]
    public class TriggerDataLoader : ILoader<int, TriggerData>
    {
        public List<TriggerData> TriggerDatas = new List<TriggerData>();
        public Dictionary<int, TriggerData> MakeDict()
        {
            return TriggerDatas.GroupBy(data => data.id).ToDictionary(group => group.Key, group => group.First());
        }
    }
    #endregion
    

}