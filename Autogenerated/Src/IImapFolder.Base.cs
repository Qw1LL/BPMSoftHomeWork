namespace BPMSoft.Mail
{

	#region Interface: IImapFolder

	public interface IImapFolder
	{

		#region Fields: Public

		string Name { get; }
		string ShortName { get; }
		string Delimiter { get; }
		string RawName { get; }
		int NestingLevel { get; }

		#endregion

	}

	#endregion

}
