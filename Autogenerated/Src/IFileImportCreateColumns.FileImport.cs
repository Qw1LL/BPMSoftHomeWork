namespace BPMSoft.Configuration.FileImport
{
	using BPMSoft.Core.Entities;

	public interface IFileImportCreateColumns
	{
		ImportColumn CreateColumn(EntitySchema rootSchema, EntitySchemaColumn entitySchemaColumn, ImportColumnValue columnValue);
	}
}
