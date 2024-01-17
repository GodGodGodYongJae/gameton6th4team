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
        [JsonProperty("ConditionList")]
        public List<JObject> ConditionListRaw;

        [JsonIgnore]
        public List<ConditionData> ConditionList { get; private set; }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            // ConditionListRaw can be null, handle it appropriately
            ConditionList = ConditionListRaw?.Select(ConvertJObjectToConditionData).ToList() ?? new List<ConditionData>();
        }


        private ConditionData ConvertJObjectToConditionData(JObject jObject)
        {
            var typeName = jObject["type"].ToObject<string>();
            var conditionType = typeof(ConditionData).Assembly.GetTypes().FirstOrDefault(t => t.Name == typeName);

            if (conditionType == null || !typeof(ConditionData).IsAssignableFrom(conditionType))
            {
                throw new NotSupportedException($"Condition type '{typeName}' is not supported.");
            }

            var condition = (ConditionData)Activator.CreateInstance(conditionType);
        
            // Use the JsonReader directly
            using (var jObjectReader = jObject.CreateReader())
            {
                // Populate the object
                JsonSerializer.CreateDefault().Populate(jObjectReader, condition);
            }

            return condition;
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
    
    #region Condtions
    [Serializable]
    public abstract class ConditionData
    {  
        public string Type { get; set; }
        public abstract void Init();
    }
    [Serializable]
    public class DayConditionData : ConditionData
    {
        public int startDay;
        public int endDay;
        public override void Init()
        {
            
        }
    }
    [Serializable]
    public class FlagConditionData : ConditionData
    {
        public string name;
        public int flag;
        public override void Init()
        {
            
        }
    }

    #endregion
}