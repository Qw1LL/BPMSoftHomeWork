namespace BPMSoft.Configuration.ExportToExcel
{
	using System;

	public class ExportToExcelException : Exception
	{
		public const string MessageFormat = "Exception during export to excel. Inner exception {0}";

		public ExportToExcelException(Exception ex) : base(string.Format(MessageFormat, ex.Message),
			ex) {
		}
	}

}
