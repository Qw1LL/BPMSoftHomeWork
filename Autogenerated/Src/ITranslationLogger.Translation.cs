namespace BPMSoft.Configuration.Translation
{
	using System;
	using BPMSoft.Core.Translation;

	#region Interface: ITranslationLogger

	public interface ITranslationLogger
	{

		#region Methods: Public

		void Error(Exception e);
		void Error(IActionResult result);
		void Info(object message);

		#endregion

	}

	#endregion

}

