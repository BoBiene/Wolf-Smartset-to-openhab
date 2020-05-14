using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSmartsetCollector.JSON
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class GuiDescriptionForGatewayResponse
    {
        [JsonProperty("MenuItems")]
        public List<MenuItem> MenuItems { get; set; }

        [JsonProperty("DynFaultMessageDevices")]
        public List<object> DynFaultMessageDevices { get; set; }

        [JsonProperty("SystemHasWRSClassicDevices")]
        public bool SystemHasWrsClassicDevices { get; set; }
    }

    [DebuggerDisplay("{Name}")]
    public partial class MenuItem
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("SortId")]
        public string SortId { get; set; }

        [JsonProperty("SubMenuEntries")]
        public List<SubMenuEntry> SubMenuEntries { get; set; }

        [JsonProperty("ParameterNode")]
        public bool ParameterNode { get; set; }

        [JsonProperty("ImageName")]
        public string ImageName { get; set; }

        [JsonProperty("TabViews")]
        public List<MenuItemTabView> TabViews { get; set; }
    }

    [DebuggerDisplay("{Name}")]
    public partial class SubMenuEntry
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("SortId")]
        public string SortId { get; set; }

        [JsonProperty("SubMenuEntries")]
        public List<object> SubMenuEntries { get; set; }

        [JsonProperty("ParameterNode")]
        public bool ParameterNode { get; set; }

        [JsonProperty("ImageName")]
        public string ImageName { get; set; }

        [JsonProperty("TabViews")]
        public List<MenuItemTabView> TabViews { get; set; }
    }

   

    public partial class ConfigComboBoxParameterDescDto
    {
        [JsonProperty("ValueId")]
        public long ValueId { get; set; }

        [JsonProperty("SortId")]
        public long SortId { get; set; }

        [JsonProperty("SubBundleId")]
        public long SubBundleId { get; set; }

        [JsonProperty("ParameterId")]
        public long ParameterId { get; set; }

        [JsonProperty("IsReadOnly")]
        public bool IsReadOnly { get; set; }

        [JsonProperty("NoDataPoint")]
        public bool NoDataPoint { get; set; }

        [JsonProperty("IsExpertProtectable")]
        public bool IsExpertProtectable { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ControlType")]
        public long ControlType { get; set; }

        [JsonProperty("ValueState")]
        public long ValueState { get; set; }

        [JsonProperty("HasDependentParameter")]
        public bool HasDependentParameter { get; set; }

        [JsonProperty("ChildParameterDescriptors", NullValueHandling = NullValueHandling.Ignore)]
        public List<ParameterDescriptor> ChildParameterDescriptors { get; set; }

        [JsonProperty("Value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }
    [DebuggerDisplay("{Name}")]
    public partial class ParameterDescriptor:IParameter
    {
        [JsonProperty("ValueId")]
        public long ValueId { get; set; }

        [JsonProperty("SortId")]
        public long SortId { get; set; }

        [JsonProperty("SubBundleId")]
        public long SubBundleId { get; set; }

        [JsonProperty("ParameterId")]
        public long ParameterId { get; set; }

        [JsonProperty("IsReadOnly")]
        public bool IsReadOnly { get; set; }

        [JsonProperty("NoDataPoint")]
        public bool NoDataPoint { get; set; }

        [JsonProperty("IsExpertProtectable")]
        public bool IsExpertProtectable { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Group")]
        public string Group { get; set; }

        [JsonProperty("ControlType")]
        public long ControlType { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("ValueState")]
        public long ValueState { get; set; }

        [JsonProperty("HasDependentParameter")]
        public bool HasDependentParameter { get; set; }

        [JsonProperty("ListItems", NullValueHandling = NullValueHandling.Ignore)]
        public List<ListItem> ListItems { get; set; }

        [JsonProperty("ProtGrp", NullValueHandling = NullValueHandling.Ignore)]
        public string ProtGrp { get; set; }

        [JsonProperty("Unit", NullValueHandling = NullValueHandling.Ignore)]
        public string Unit { get; set; }

        [JsonProperty("Decimals", NullValueHandling = NullValueHandling.Ignore)]
        public long? Decimals { get; set; }

        [JsonProperty("MinValueCondition", NullValueHandling = NullValueHandling.Ignore)]
        public string MinValueCondition { get; set; }

        [JsonProperty("MaxValueCondition", NullValueHandling = NullValueHandling.Ignore)]
        public string MaxValueCondition { get; set; }

        [JsonProperty("MinValue", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinValue { get; set; }

        [JsonProperty("MaxValue", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxValue { get; set; }

        [JsonProperty("StepWidth", NullValueHandling = NullValueHandling.Ignore)]
        public double? StepWidth { get; set; }

        [JsonProperty("ChildParameterDescriptors", NullValueHandling = NullValueHandling.Ignore)]
        public List<ConfigComboBoxParameterDescDto> ChildParameterDescriptors { get; set; }

        [JsonProperty("NamePrefix", NullValueHandling = NullValueHandling.Ignore)]
        public string NamePrefix { get; set; }

        [JsonProperty("TurnOffValue", NullValueHandling = NullValueHandling.Ignore)]
        public long? TurnOffValue { get; set; }
    }

    public partial class ListItem
    {
        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("DisplayText")]
        public string DisplayText { get; set; }

        [JsonProperty("ImageName", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageName { get; set; }

        [JsonProperty("IsSelectable")]
        public bool IsSelectable { get; set; }

        [JsonProperty("HighlightIfSelected")]
        public bool HighlightIfSelected { get; set; }
    }

    public partial class SchemaTabViewConfigDto
    {
        [JsonProperty("Configs")]
        public List<Config> Configs { get; set; }

        [JsonProperty("ConfigComboBoxParameterDescDTO")]
        public ConfigComboBoxParameterDescDto ConfigComboBoxParameterDescDto { get; set; }
    }

    public partial class Config
    {
        [JsonProperty("ConfigIndex")]
        public long ConfigIndex { get; set; }

        [JsonProperty("ConfigName")]
        public string ConfigName { get; set; }

        [JsonProperty("ConfigDesc")]
        public string ConfigDesc { get; set; }

        [JsonProperty("ImageName")]
        public string ImageName { get; set; }

        [JsonProperty("Parameters")]
        public List<Parameter> Parameters { get; set; }
    }

    public interface IParameter
    {
        long ControlType { get; set; }
        long? Decimals { get; set; }
        List<ListItem> ListItems { get; set; }
        string Name { get; set; }
        long ParameterId { get; set; }
        long ValueId { get; }
        string Unit { get; set; }
        string Value { get; set; }
    }

    public partial class Parameter : IParameter
    {
        [JsonProperty("PortName")]
        public string PortName { get; set; }

        [JsonProperty("PortDesc")]
        public string PortDesc { get; set; }

        [JsonProperty("ValueId")]
        public long ValueId { get; set; }

        [JsonProperty("ParameterId")]
        public long ParameterId { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("ControlType")]
        public long ControlType { get; set; }

        [JsonProperty("ValueState")]
        public long ValueState { get; set; }

        [JsonProperty("ProtGrp")]
        public string ProtGrp { get; set; }

        [JsonProperty("Unit", NullValueHandling = NullValueHandling.Ignore)]
        public string Unit { get; set; }

        [JsonProperty("Decimals", NullValueHandling = NullValueHandling.Ignore)]
        public long? Decimals { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ListItems", NullValueHandling = NullValueHandling.Ignore)]
        public List<ListItem> ListItems { get; set; }
    }
    [DebuggerDisplay("{GroupName}")]
    public partial class TabViewGroup
    {
        [JsonProperty("GroupName")]
        public string GroupName { get; set; }

        [JsonProperty("IsTitleEditable")]
        public bool IsTitleEditable { get; set; }
    }
    [DebuggerDisplay("{TabName}")]
    public partial class MenuItemTabView
    {
        [JsonProperty("IsExpertView")]
        public bool IsExpertView { get; set; }

        [JsonProperty("TabName")]
        public string TabName { get; set; }

        [JsonProperty("GuiId")]
        public long GuiId { get; set; }

        [JsonProperty("BundleId")]
        public long BundleId { get; set; }

        [JsonProperty("ParameterDescriptors")]
        public List<ParameterDescriptor> ParameterDescriptors { get; set; }

        [JsonProperty("ViewType")]
        public long ViewType { get; set; }

        [JsonProperty("SvgSchemaDeviceId")]
        public long SvgSchemaDeviceId { get; set; }

        [JsonProperty("GetValueLastAccess")]
        public DateTimeOffset GetValueLastAccess { get; set; }

        [JsonProperty("TabViewGroups")]
        public List<TabViewGroup> TabViewGroups { get; set; }

        [JsonProperty("SchemaTabViewConfigDTO", NullValueHandling = NullValueHandling.Ignore)]
        public SchemaTabViewConfigDto SchemaTabViewConfigDto { get; set; }
    }



    



    internal static class GuiDescriptionForGatewayResponseConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

   
  
}
