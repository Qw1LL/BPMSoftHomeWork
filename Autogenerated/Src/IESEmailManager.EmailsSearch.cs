namespace BPMSoft.Configuration.EmailsSearch
{

	using System.Collections.Generic;
	using BPMSoft.Configuration.GlobalSearch;

	#region Interface: IESEmailManager

	public interface IESEmailManager
	{
		
		#region Methods: Public

		IEnumerable<Dictionary<string, string>> SearchEmails(List<string> request);

		#endregion

	}

	#endregion

}
