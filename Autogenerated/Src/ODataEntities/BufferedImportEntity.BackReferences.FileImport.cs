namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: BufferedImportEntity

	/// <exclude/>
	public class BufferedImportEntity : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public BufferedImportEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BufferedImportEntity";
		}

		public BufferedImportEntity(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "BufferedImportEntity";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

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
		/// Column1.
		/// </summary>
		public string Column1 {
			get {
				return GetTypedColumnValue<string>("Column1");
			}
			set {
				SetColumnValue("Column1", value);
			}
		}

		/// <summary>
		/// Column2.
		/// </summary>
		public string Column2 {
			get {
				return GetTypedColumnValue<string>("Column2");
			}
			set {
				SetColumnValue("Column2", value);
			}
		}

		/// <summary>
		/// Column3.
		/// </summary>
		public string Column3 {
			get {
				return GetTypedColumnValue<string>("Column3");
			}
			set {
				SetColumnValue("Column3", value);
			}
		}

		/// <summary>
		/// Column4.
		/// </summary>
		public string Column4 {
			get {
				return GetTypedColumnValue<string>("Column4");
			}
			set {
				SetColumnValue("Column4", value);
			}
		}

		/// <summary>
		/// Column5.
		/// </summary>
		public string Column5 {
			get {
				return GetTypedColumnValue<string>("Column5");
			}
			set {
				SetColumnValue("Column5", value);
			}
		}

		/// <summary>
		/// Column6.
		/// </summary>
		public string Column6 {
			get {
				return GetTypedColumnValue<string>("Column6");
			}
			set {
				SetColumnValue("Column6", value);
			}
		}

		/// <summary>
		/// Column7.
		/// </summary>
		public string Column7 {
			get {
				return GetTypedColumnValue<string>("Column7");
			}
			set {
				SetColumnValue("Column7", value);
			}
		}

		/// <summary>
		/// Column8.
		/// </summary>
		public string Column8 {
			get {
				return GetTypedColumnValue<string>("Column8");
			}
			set {
				SetColumnValue("Column8", value);
			}
		}

		/// <summary>
		/// Column9.
		/// </summary>
		public string Column9 {
			get {
				return GetTypedColumnValue<string>("Column9");
			}
			set {
				SetColumnValue("Column9", value);
			}
		}

		/// <summary>
		/// Column10.
		/// </summary>
		public string Column10 {
			get {
				return GetTypedColumnValue<string>("Column10");
			}
			set {
				SetColumnValue("Column10", value);
			}
		}

		/// <summary>
		/// Column11.
		/// </summary>
		public string Column11 {
			get {
				return GetTypedColumnValue<string>("Column11");
			}
			set {
				SetColumnValue("Column11", value);
			}
		}

		/// <summary>
		/// Column12.
		/// </summary>
		public string Column12 {
			get {
				return GetTypedColumnValue<string>("Column12");
			}
			set {
				SetColumnValue("Column12", value);
			}
		}

		/// <summary>
		/// Column13.
		/// </summary>
		public string Column13 {
			get {
				return GetTypedColumnValue<string>("Column13");
			}
			set {
				SetColumnValue("Column13", value);
			}
		}

		/// <summary>
		/// Column14.
		/// </summary>
		public string Column14 {
			get {
				return GetTypedColumnValue<string>("Column14");
			}
			set {
				SetColumnValue("Column14", value);
			}
		}

		/// <summary>
		/// Column15.
		/// </summary>
		public string Column15 {
			get {
				return GetTypedColumnValue<string>("Column15");
			}
			set {
				SetColumnValue("Column15", value);
			}
		}

		/// <summary>
		/// Column16.
		/// </summary>
		public string Column16 {
			get {
				return GetTypedColumnValue<string>("Column16");
			}
			set {
				SetColumnValue("Column16", value);
			}
		}

		/// <summary>
		/// Column17.
		/// </summary>
		public string Column17 {
			get {
				return GetTypedColumnValue<string>("Column17");
			}
			set {
				SetColumnValue("Column17", value);
			}
		}

		/// <summary>
		/// Column18.
		/// </summary>
		public string Column18 {
			get {
				return GetTypedColumnValue<string>("Column18");
			}
			set {
				SetColumnValue("Column18", value);
			}
		}

		/// <summary>
		/// Column19.
		/// </summary>
		public string Column19 {
			get {
				return GetTypedColumnValue<string>("Column19");
			}
			set {
				SetColumnValue("Column19", value);
			}
		}

		/// <summary>
		/// Column20.
		/// </summary>
		public string Column20 {
			get {
				return GetTypedColumnValue<string>("Column20");
			}
			set {
				SetColumnValue("Column20", value);
			}
		}

		/// <summary>
		/// Column21.
		/// </summary>
		public string Column21 {
			get {
				return GetTypedColumnValue<string>("Column21");
			}
			set {
				SetColumnValue("Column21", value);
			}
		}

		/// <summary>
		/// Column22.
		/// </summary>
		public string Column22 {
			get {
				return GetTypedColumnValue<string>("Column22");
			}
			set {
				SetColumnValue("Column22", value);
			}
		}

		/// <summary>
		/// Column23.
		/// </summary>
		public string Column23 {
			get {
				return GetTypedColumnValue<string>("Column23");
			}
			set {
				SetColumnValue("Column23", value);
			}
		}

		/// <summary>
		/// Column24.
		/// </summary>
		public string Column24 {
			get {
				return GetTypedColumnValue<string>("Column24");
			}
			set {
				SetColumnValue("Column24", value);
			}
		}

		/// <summary>
		/// Column25.
		/// </summary>
		public string Column25 {
			get {
				return GetTypedColumnValue<string>("Column25");
			}
			set {
				SetColumnValue("Column25", value);
			}
		}

		/// <summary>
		/// Column26.
		/// </summary>
		public string Column26 {
			get {
				return GetTypedColumnValue<string>("Column26");
			}
			set {
				SetColumnValue("Column26", value);
			}
		}

		/// <summary>
		/// Column27.
		/// </summary>
		public string Column27 {
			get {
				return GetTypedColumnValue<string>("Column27");
			}
			set {
				SetColumnValue("Column27", value);
			}
		}

		/// <summary>
		/// Column28.
		/// </summary>
		public string Column28 {
			get {
				return GetTypedColumnValue<string>("Column28");
			}
			set {
				SetColumnValue("Column28", value);
			}
		}

		/// <summary>
		/// Column29.
		/// </summary>
		public string Column29 {
			get {
				return GetTypedColumnValue<string>("Column29");
			}
			set {
				SetColumnValue("Column29", value);
			}
		}

		/// <summary>
		/// Column30.
		/// </summary>
		public string Column30 {
			get {
				return GetTypedColumnValue<string>("Column30");
			}
			set {
				SetColumnValue("Column30", value);
			}
		}

		/// <summary>
		/// ImportSessionId.
		/// </summary>
		public Guid ImportSessionId {
			get {
				return GetTypedColumnValue<Guid>("ImportSessionId");
			}
			set {
				SetColumnValue("ImportSessionId", value);
			}
		}

		/// <summary>
		/// Column31.
		/// </summary>
		public string Column31 {
			get {
				return GetTypedColumnValue<string>("Column31");
			}
			set {
				SetColumnValue("Column31", value);
			}
		}

		/// <summary>
		/// Column32.
		/// </summary>
		public string Column32 {
			get {
				return GetTypedColumnValue<string>("Column32");
			}
			set {
				SetColumnValue("Column32", value);
			}
		}

		/// <summary>
		/// Column33.
		/// </summary>
		public string Column33 {
			get {
				return GetTypedColumnValue<string>("Column33");
			}
			set {
				SetColumnValue("Column33", value);
			}
		}

		/// <summary>
		/// Column34.
		/// </summary>
		public string Column34 {
			get {
				return GetTypedColumnValue<string>("Column34");
			}
			set {
				SetColumnValue("Column34", value);
			}
		}

		/// <summary>
		/// Column35.
		/// </summary>
		public string Column35 {
			get {
				return GetTypedColumnValue<string>("Column35");
			}
			set {
				SetColumnValue("Column35", value);
			}
		}

		/// <summary>
		/// Column36.
		/// </summary>
		public string Column36 {
			get {
				return GetTypedColumnValue<string>("Column36");
			}
			set {
				SetColumnValue("Column36", value);
			}
		}

		/// <summary>
		/// Column37.
		/// </summary>
		public string Column37 {
			get {
				return GetTypedColumnValue<string>("Column37");
			}
			set {
				SetColumnValue("Column37", value);
			}
		}

		/// <summary>
		/// Column38.
		/// </summary>
		public string Column38 {
			get {
				return GetTypedColumnValue<string>("Column38");
			}
			set {
				SetColumnValue("Column38", value);
			}
		}

		/// <summary>
		/// Column39.
		/// </summary>
		public string Column39 {
			get {
				return GetTypedColumnValue<string>("Column39");
			}
			set {
				SetColumnValue("Column39", value);
			}
		}

		/// <summary>
		/// Column40.
		/// </summary>
		public string Column40 {
			get {
				return GetTypedColumnValue<string>("Column40");
			}
			set {
				SetColumnValue("Column40", value);
			}
		}

		/// <summary>
		/// Column41.
		/// </summary>
		public string Column41 {
			get {
				return GetTypedColumnValue<string>("Column41");
			}
			set {
				SetColumnValue("Column41", value);
			}
		}

		/// <summary>
		/// Column42.
		/// </summary>
		public string Column42 {
			get {
				return GetTypedColumnValue<string>("Column42");
			}
			set {
				SetColumnValue("Column42", value);
			}
		}

		/// <summary>
		/// Column43.
		/// </summary>
		public string Column43 {
			get {
				return GetTypedColumnValue<string>("Column43");
			}
			set {
				SetColumnValue("Column43", value);
			}
		}

		/// <summary>
		/// Column44.
		/// </summary>
		public string Column44 {
			get {
				return GetTypedColumnValue<string>("Column44");
			}
			set {
				SetColumnValue("Column44", value);
			}
		}

		/// <summary>
		/// Column45.
		/// </summary>
		public string Column45 {
			get {
				return GetTypedColumnValue<string>("Column45");
			}
			set {
				SetColumnValue("Column45", value);
			}
		}

		/// <summary>
		/// Column46.
		/// </summary>
		public string Column46 {
			get {
				return GetTypedColumnValue<string>("Column46");
			}
			set {
				SetColumnValue("Column46", value);
			}
		}

		/// <summary>
		/// Column47.
		/// </summary>
		public string Column47 {
			get {
				return GetTypedColumnValue<string>("Column47");
			}
			set {
				SetColumnValue("Column47", value);
			}
		}

		/// <summary>
		/// Column48.
		/// </summary>
		public string Column48 {
			get {
				return GetTypedColumnValue<string>("Column48");
			}
			set {
				SetColumnValue("Column48", value);
			}
		}

		/// <summary>
		/// Column49.
		/// </summary>
		public string Column49 {
			get {
				return GetTypedColumnValue<string>("Column49");
			}
			set {
				SetColumnValue("Column49", value);
			}
		}

		/// <summary>
		/// Column50.
		/// </summary>
		public string Column50 {
			get {
				return GetTypedColumnValue<string>("Column50");
			}
			set {
				SetColumnValue("Column50", value);
			}
		}

		/// <summary>
		/// ImportExcelRowIndex.
		/// </summary>
		public int ImportExcelRowIndex {
			get {
				return GetTypedColumnValue<int>("ImportExcelRowIndex");
			}
			set {
				SetColumnValue("ImportExcelRowIndex", value);
			}
		}

		#endregion

	}

	#endregion

}

