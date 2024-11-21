namespace BPMSoft.Configuration.DynamicContent
{
	using System;

	#region Enum: DCTemplateReadOption

	/// <summary>
	/// Options enum for reads template. Uses as flags.
	/// </summary>
	[Flags]
	public enum DCTemplateReadOption
	{

		None = 0,
		ExcludeAttributes = 1,
		ExcludeReplicaHtmlContent = 2

	}

	#endregion

}
