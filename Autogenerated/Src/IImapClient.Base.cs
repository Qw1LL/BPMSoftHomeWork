namespace BPMSoft.Mail
{
	using System;
	using System.Collections.Generic;

	#region Interface: IImapClient
	
	public interface IImapClient: IDisposable
	{
		#region Methods: Public

		bool TryDeleteFolder(string folderName);
		bool CreateFolder(string newFolderPath);
		void MoveMessageToFolder(string folderName, string messageTitle, string destenationFolder);
		bool EnsureFolderExists(string folderName);
		List<IImapFolder> GetFolders();

		#endregion
		
	}

	#endregion
}
