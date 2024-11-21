namespace BPMSoft.Configuration.FileImport
{
	using BPMSoft.Core.Entities;

	public interface IFileImportCanProcess
	{
		bool CanProcess(EntitySchemaColumn entitySchemaColumn);

		bool CanProcess(ImportColumnDestination destination);

	}
}

