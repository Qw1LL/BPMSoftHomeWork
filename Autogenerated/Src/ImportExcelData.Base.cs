namespace BPMSoft.Configuration.ImportExcelData
{
	using System;
	using global::Common.Logging;

	#region Class: ImportColumnSeting

	/// <summary>
	/// ######## ############ ####### ###### ## ####### Excel.
	/// </summary>
	public class ExcelColumnConfig
	{
		public int Index { get; set; }
		public string Caption { get; set; }
		public string EntityColumnName { get; set; }
		public bool IsLookupType { get; set; }
		public bool NeedImport { get; set; }
	}

	#endregion Class: ImportColumnSeting

	#region Class: ExcelUtilities

	public static class ExcelUtilities 
	{
		#region Properties: Public

		private static readonly ILog _log = LogManager.GetLogger("Excel");

		public static ILog Log {
			get {
				return _log;
			}
		}

		#endregion
	}

	#endregion Class: ExcelUtilities
}
