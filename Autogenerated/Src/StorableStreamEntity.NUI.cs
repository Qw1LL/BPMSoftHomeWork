namespace BPMSoft.Configuration
{
	using System;
	using System.IO;

	#region Class: StorableStream

	/// <summary>
	/// Wrapper for stream to be stored.
	/// </summary>
	[Serializable]
	public class StorableStreamEntity : BaseStorableEntity
	{
		#if !NETSTANDARD2_0

		[Obsolete("Will be removed after 7.15.0. Use Data property.")]
		public Stream Stream { get; set; }

		#endif

		public byte[] Data { get; set; }

	}

	#endregion

}
