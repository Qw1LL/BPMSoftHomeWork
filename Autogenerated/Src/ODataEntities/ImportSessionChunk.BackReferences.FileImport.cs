namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ImportSessionChunk

	/// <exclude/>
	public class ImportSessionChunk : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ImportSessionChunk(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ImportSessionChunk";
		}

		public ImportSessionChunk(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ImportSessionChunk";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<ChunkProcessResult> ChunkProcessResultCollectionByImportSessionChunk {
			get;
			set;
		}

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// Created on.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <exclude/>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
				_createdBy = null;
			}
		}

		/// <exclude/>
		public string CreatedByName {
			get {
				return GetTypedColumnValue<string>("CreatedByName");
			}
			set {
				SetColumnValue("CreatedByName", value);
				if (_createdBy != null) {
					_createdBy.Name = value;
				}
			}
		}

		private Contact _createdBy;
		/// <summary>
		/// Created by.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Modified on.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <exclude/>
		public Guid ModifiedById {
			get {
				return GetTypedColumnValue<Guid>("ModifiedById");
			}
			set {
				SetColumnValue("ModifiedById", value);
				_modifiedBy = null;
			}
		}

		/// <exclude/>
		public string ModifiedByName {
			get {
				return GetTypedColumnValue<string>("ModifiedByName");
			}
			set {
				SetColumnValue("ModifiedByName", value);
				if (_modifiedBy != null) {
					_modifiedBy.Name = value;
				}
			}
		}

		private Contact _modifiedBy;
		/// <summary>
		/// Modified by.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <summary>
		/// Active processes.
		/// </summary>
		public int ProcessListeners {
			get {
				return GetTypedColumnValue<int>("ProcessListeners");
			}
			set {
				SetColumnValue("ProcessListeners", value);
			}
		}

		/// <summary>
		/// Type.
		/// </summary>
		/// <remarks>
		/// Chunk data type.
		/// </remarks>
		public int Type {
			get {
				return GetTypedColumnValue<int>("Type");
			}
			set {
				SetColumnValue("Type", value);
			}
		}

		/// <summary>
		/// State.
		/// </summary>
		/// <remarks>
		/// Chunk state.
		/// </remarks>
		public int State {
			get {
				return GetTypedColumnValue<int>("State");
			}
			set {
				SetColumnValue("State", value);
			}
		}

		/// <exclude/>
		public Guid ImportParametersId {
			get {
				return GetTypedColumnValue<Guid>("ImportParametersId");
			}
			set {
				SetColumnValue("ImportParametersId", value);
				_importParameters = null;
			}
		}

		private FileImportParameters _importParameters;
		/// <summary>
		/// ImportParameters.
		/// </summary>
		public FileImportParameters ImportParameters {
			get {
				return _importParameters ??
					(_importParameters = new FileImportParameters(LookupColumnEntities.GetEntity("ImportParameters")));
			}
		}

		#endregion

	}

	#endregion

}

