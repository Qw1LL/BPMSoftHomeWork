namespace BPMSoft.Configuration.ForecastV2
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    #region Class: BaseColumnSetting

    /// <summary>
    /// Base class for all column setting.
    /// </summary>
    public class BaseColumnSetting
    {
        /// <summary>
        /// Defines visibility of fractional part of column value.
        /// </summary>
        [JsonProperty("isFractionalPartHidden")]
        public bool IsFractionalPartHidden { get; set; }
    }

    #endregion

    #region Class: ColumnSetting

    /// <summary>
    /// Represents column settings.
    /// </summary>
    public partial class ColumnSetting: BaseColumnSetting
    {
        /// <summary>
        /// Unique identifier of calculated entity.
        /// </summary>
        [JsonProperty("sourceUId")]
        public Guid SourceUId { get; set; }

        /// <summary>
        /// Unique identifier of reference column.
        /// </summary>
        [JsonProperty("refColumnId")]
        public Guid RefColumnId { get; set; }

        /// <summary>
        /// Gets or sets the reference column path.
        /// </summary>
        [JsonProperty("refColumnPath")]
        public string RefColumnPath { get; set; }

        /// <summary>
        /// Unique identifier of period column.
        /// </summary>
        [JsonProperty("periodColumnId")]
        public Guid PeriodColumnId { get; set; }

        /// <summary>
        /// Path of period column.
        /// </summary>
        [JsonProperty("periodColumnPath")]
        public string PeriodColumnPath { get; set; }

        /// <summary>
        /// Filter data json string.
        /// </summary>
        [JsonProperty("filter")]
        public string FilterData { get; set; }

        /// <summary>
        /// Unique identifier of calculated function column.
        /// </summary>
        [JsonProperty("funcColumnId")]
        public Guid FuncColumnId { get; set; }

        /// <summary>
        /// Gets or sets the function column path.
        /// </summary>
        [JsonProperty("funcColumnPath")]
        public string FuncColumnPath { get; set; }

        /// <summary>
        /// Calculation function code.
        /// </summary>
        [JsonProperty("funcCode")]
        public string FuncCode { get; set; }

        /// <summary>
        /// Gets or sets the percent operation operand.
        /// </summary>
        [JsonProperty("percentOperand")]
        public string PercentOperand { get; set; }
    }

    #endregion

    #region Class: FormulaSetting

    /// <summary>
    /// Formula setting.
    /// </summary>
    public class FormulaSetting: BaseColumnSetting
    {
        /// <summary>
        /// Gets or sets the formula value.
        /// </summary>
        [JsonProperty("value")]
        public IEnumerable<FormulaItem> Value { get; set; }

        /// <summary>
        /// Gets or sets summary formula value.
        /// </summary>
        [JsonProperty("summaryValue")]
        public  IEnumerable<FormulaItem> SummaryValue { get; set; }

        /// <summary>
        /// Gets or sets the use formula in summary flag.
        /// </summary>
        [JsonProperty("useInSummary")]
        public bool UseInSummary { get; set; }
    }

    #endregion

    #region Class: EditableSetting

    /// <summary>
    /// Editable column settings.
    /// </summary>
    public class EditableSetting: BaseColumnSetting
    {
        /// <summary>
        /// Gets or sets is group edit flag.
        /// </summary>
        [JsonProperty("isGroupEdit")]
        public bool IsGroupEdit { get; set; }
    }

    #endregion
}
