namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	#region Class: EnrichSaveEntityData

	/// <summary>
	/// Provides data contact properites binding for enriched entities saving.
	/// </summary>
	[DataContract]
	public class EnrichSaveEntityData
	{

		#region Properties: Public

		/// <summary>
		/// <see cref="EntitySchemaExtensionSchema"/> name.
		/// </summary>
		[DataMember(Name = "entityName")]
		public string EntityName {
			get;
			set;
		}

		/// <summary>
		/// Item saving order.
		/// </summary>
		[DataMember(Name = "order")]
		public int Order {
			get;
			set;
		}

		/// <summary>
		/// Item column values.
		/// </summary>
		[DataMember(Name = "values")]
		public Dictionary<string, string> Values {
			get;
			set;
		}

		/// <summary>
		/// Existing items search columns.
		/// </summary>
		[DataMember(Name = "keyColumns")]
		public string[] KeyColumns {
			get;
			set;
		}

		#endregion

	}

	#endregion

}

