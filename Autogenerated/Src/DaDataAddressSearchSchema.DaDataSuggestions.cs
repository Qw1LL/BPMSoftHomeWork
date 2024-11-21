namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.UI.WebControls.Controls;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DaDataAddressSearch

	[DesignModeProperty(Name = "Address", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.Address.Caption", DescriptionResourceItem = "Parameters.Address.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "UnrestrictedValue", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.UnrestrictedValue.Caption", DescriptionResourceItem = "Parameters.UnrestrictedValue.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "PostalCode", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.PostalCode.Caption", DescriptionResourceItem = "Parameters.PostalCode.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Country", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.Country.Caption", DescriptionResourceItem = "Parameters.Country.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CountryIsoCode", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.CountryIsoCode.Caption", DescriptionResourceItem = "Parameters.CountryIsoCode.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "FederalDistrict", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.FederalDistrict.Caption", DescriptionResourceItem = "Parameters.FederalDistrict.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Region", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.Region.Caption", DescriptionResourceItem = "Parameters.Region.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RegionFiasId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.RegionFiasId.Caption", DescriptionResourceItem = "Parameters.RegionFiasId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Area", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.Area.Caption", DescriptionResourceItem = "Parameters.Area.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AreaFiasId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.AreaFiasId.Caption", DescriptionResourceItem = "Parameters.AreaFiasId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "City", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.City.Caption", DescriptionResourceItem = "Parameters.City.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CityFiasId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.CityFiasId.Caption", DescriptionResourceItem = "Parameters.CityFiasId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CityDistrict", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.CityDistrict.Caption", DescriptionResourceItem = "Parameters.CityDistrict.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CityDistrictFiasId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.CityDistrictFiasId.Caption", DescriptionResourceItem = "Parameters.CityDistrictFiasId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Street", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.Street.Caption", DescriptionResourceItem = "Parameters.Street.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "StreetFiasId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.StreetFiasId.Caption", DescriptionResourceItem = "Parameters.StreetFiasId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "House", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.House.Caption", DescriptionResourceItem = "Parameters.House.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "HouseFiasId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.HouseFiasId.Caption", DescriptionResourceItem = "Parameters.HouseFiasId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Block", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.Block.Caption", DescriptionResourceItem = "Parameters.Block.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Flat", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.Flat.Caption", DescriptionResourceItem = "Parameters.Flat.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Okato", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.Okato.Caption", DescriptionResourceItem = "Parameters.Okato.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Oktmo", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.Oktmo.Caption", DescriptionResourceItem = "Parameters.Oktmo.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "GeoLat", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.GeoLat.Caption", DescriptionResourceItem = "Parameters.GeoLat.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "GeoLon", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.GeoLon.Caption", DescriptionResourceItem = "Parameters.GeoLon.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressFound", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.AddressFound.Caption", DescriptionResourceItem = "Parameters.AddressFound.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Settlement", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.Settlement.Caption", DescriptionResourceItem = "Parameters.Settlement.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SettlementFiasId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.SettlementFiasId.Caption", DescriptionResourceItem = "Parameters.SettlementFiasId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ErrorText", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.ErrorText.Caption", DescriptionResourceItem = "Parameters.ErrorText.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CountryId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.CountryId.Caption", DescriptionResourceItem = "Parameters.CountryId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RegionId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.RegionId.Caption", DescriptionResourceItem = "Parameters.RegionId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CityId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7a7c7a9f316e4a65bd0ac036c3e1f995", CaptionResourceItem = "Parameters.CityId.Caption", DescriptionResourceItem = "Parameters.CityId.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class DaDataAddressSearch : ProcessUserTask
	{

		#region Constructors: Public

		public DaDataAddressSearch(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("7a7c7a9f-316e-4a65-bd0a-c036c3e1f995");
		}

		#endregion

		#region Properties: Public

		public virtual string Address {
			get;
			set;
		}

		public virtual string UnrestrictedValue {
			get;
			set;
		}

		public virtual string PostalCode {
			get;
			set;
		}

		public virtual string Country {
			get;
			set;
		}

		public virtual string CountryIsoCode {
			get;
			set;
		}

		public virtual string FederalDistrict {
			get;
			set;
		}

		public virtual string Region {
			get;
			set;
		}

		public virtual string RegionFiasId {
			get;
			set;
		}

		public virtual string Area {
			get;
			set;
		}

		public virtual string AreaFiasId {
			get;
			set;
		}

		public virtual string City {
			get;
			set;
		}

		public virtual string CityFiasId {
			get;
			set;
		}

		public virtual string CityDistrict {
			get;
			set;
		}

		public virtual string CityDistrictFiasId {
			get;
			set;
		}

		public virtual string Street {
			get;
			set;
		}

		public virtual string StreetFiasId {
			get;
			set;
		}

		public virtual string House {
			get;
			set;
		}

		public virtual string HouseFiasId {
			get;
			set;
		}

		public virtual string Block {
			get;
			set;
		}

		public virtual string Flat {
			get;
			set;
		}

		public virtual string Okato {
			get;
			set;
		}

		public virtual string Oktmo {
			get;
			set;
		}

		public virtual string GeoLat {
			get;
			set;
		}

		public virtual string GeoLon {
			get;
			set;
		}

		public virtual bool AddressFound {
			get;
			set;
		}

		public virtual string Settlement {
			get;
			set;
		}

		public virtual string SettlementFiasId {
			get;
			set;
		}

		public virtual string ErrorText {
			get;
			set;
		}

		public virtual Guid CountryId {
			get;
			set;
		}

		public virtual Guid RegionId {
			get;
			set;
		}

		public virtual Guid CityId {
			get;
			set;
		}

		#endregion

		#region Methods: Public

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("Address")) {
					writer.WriteValue("Address", Address, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("UnrestrictedValue")) {
					writer.WriteValue("UnrestrictedValue", UnrestrictedValue, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("PostalCode")) {
					writer.WriteValue("PostalCode", PostalCode, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("Country")) {
					writer.WriteValue("Country", Country, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("CountryIsoCode")) {
					writer.WriteValue("CountryIsoCode", CountryIsoCode, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("FederalDistrict")) {
					writer.WriteValue("FederalDistrict", FederalDistrict, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("Region")) {
					writer.WriteValue("Region", Region, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("RegionFiasId")) {
					writer.WriteValue("RegionFiasId", RegionFiasId, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("Area")) {
					writer.WriteValue("Area", Area, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AreaFiasId")) {
					writer.WriteValue("AreaFiasId", AreaFiasId, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("City")) {
					writer.WriteValue("City", City, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("CityFiasId")) {
					writer.WriteValue("CityFiasId", CityFiasId, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("CityDistrict")) {
					writer.WriteValue("CityDistrict", CityDistrict, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("CityDistrictFiasId")) {
					writer.WriteValue("CityDistrictFiasId", CityDistrictFiasId, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("Street")) {
					writer.WriteValue("Street", Street, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("StreetFiasId")) {
					writer.WriteValue("StreetFiasId", StreetFiasId, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("House")) {
					writer.WriteValue("House", House, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("HouseFiasId")) {
					writer.WriteValue("HouseFiasId", HouseFiasId, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("Block")) {
					writer.WriteValue("Block", Block, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("Flat")) {
					writer.WriteValue("Flat", Flat, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("Okato")) {
					writer.WriteValue("Okato", Okato, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("Oktmo")) {
					writer.WriteValue("Oktmo", Oktmo, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("GeoLat")) {
					writer.WriteValue("GeoLat", GeoLat, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("GeoLon")) {
					writer.WriteValue("GeoLon", GeoLon, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressFound")) {
					writer.WriteValue("AddressFound", AddressFound, false);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("Settlement")) {
					writer.WriteValue("Settlement", Settlement, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("SettlementFiasId")) {
					writer.WriteValue("SettlementFiasId", SettlementFiasId, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("ErrorText")) {
					writer.WriteValue("ErrorText", ErrorText, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("CountryId")) {
					writer.WriteValue("CountryId", CountryId, Guid.Empty);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("RegionId")) {
					writer.WriteValue("RegionId", RegionId, Guid.Empty);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("CityId")) {
					writer.WriteValue("CityId", CityId, Guid.Empty);
				}
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "Address":
					if (!UseFlowEngineMode) {
						break;
					}
					Address = reader.GetStringValue();
				break;
				case "UnrestrictedValue":
					if (!UseFlowEngineMode) {
						break;
					}
					UnrestrictedValue = reader.GetStringValue();
				break;
				case "PostalCode":
					if (!UseFlowEngineMode) {
						break;
					}
					PostalCode = reader.GetStringValue();
				break;
				case "Country":
					if (!UseFlowEngineMode) {
						break;
					}
					Country = reader.GetStringValue();
				break;
				case "CountryIsoCode":
					if (!UseFlowEngineMode) {
						break;
					}
					CountryIsoCode = reader.GetStringValue();
				break;
				case "FederalDistrict":
					if (!UseFlowEngineMode) {
						break;
					}
					FederalDistrict = reader.GetStringValue();
				break;
				case "Region":
					if (!UseFlowEngineMode) {
						break;
					}
					Region = reader.GetStringValue();
				break;
				case "RegionFiasId":
					if (!UseFlowEngineMode) {
						break;
					}
					RegionFiasId = reader.GetStringValue();
				break;
				case "Area":
					if (!UseFlowEngineMode) {
						break;
					}
					Area = reader.GetStringValue();
				break;
				case "AreaFiasId":
					if (!UseFlowEngineMode) {
						break;
					}
					AreaFiasId = reader.GetStringValue();
				break;
				case "City":
					if (!UseFlowEngineMode) {
						break;
					}
					City = reader.GetStringValue();
				break;
				case "CityFiasId":
					if (!UseFlowEngineMode) {
						break;
					}
					CityFiasId = reader.GetStringValue();
				break;
				case "CityDistrict":
					if (!UseFlowEngineMode) {
						break;
					}
					CityDistrict = reader.GetStringValue();
				break;
				case "CityDistrictFiasId":
					if (!UseFlowEngineMode) {
						break;
					}
					CityDistrictFiasId = reader.GetStringValue();
				break;
				case "Street":
					if (!UseFlowEngineMode) {
						break;
					}
					Street = reader.GetStringValue();
				break;
				case "StreetFiasId":
					if (!UseFlowEngineMode) {
						break;
					}
					StreetFiasId = reader.GetStringValue();
				break;
				case "House":
					if (!UseFlowEngineMode) {
						break;
					}
					House = reader.GetStringValue();
				break;
				case "HouseFiasId":
					if (!UseFlowEngineMode) {
						break;
					}
					HouseFiasId = reader.GetStringValue();
				break;
				case "Block":
					if (!UseFlowEngineMode) {
						break;
					}
					Block = reader.GetStringValue();
				break;
				case "Flat":
					if (!UseFlowEngineMode) {
						break;
					}
					Flat = reader.GetStringValue();
				break;
				case "Okato":
					if (!UseFlowEngineMode) {
						break;
					}
					Okato = reader.GetStringValue();
				break;
				case "Oktmo":
					if (!UseFlowEngineMode) {
						break;
					}
					Oktmo = reader.GetStringValue();
				break;
				case "GeoLat":
					if (!UseFlowEngineMode) {
						break;
					}
					GeoLat = reader.GetStringValue();
				break;
				case "GeoLon":
					if (!UseFlowEngineMode) {
						break;
					}
					GeoLon = reader.GetStringValue();
				break;
				case "AddressFound":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressFound = reader.GetBoolValue();
				break;
				case "Settlement":
					if (!UseFlowEngineMode) {
						break;
					}
					Settlement = reader.GetStringValue();
				break;
				case "SettlementFiasId":
					if (!UseFlowEngineMode) {
						break;
					}
					SettlementFiasId = reader.GetStringValue();
				break;
				case "ErrorText":
					if (!UseFlowEngineMode) {
						break;
					}
					ErrorText = reader.GetStringValue();
				break;
				case "CountryId":
					if (!UseFlowEngineMode) {
						break;
					}
					CountryId = reader.GetGuidValue();
				break;
				case "RegionId":
					if (!UseFlowEngineMode) {
						break;
					}
					RegionId = reader.GetGuidValue();
				break;
				case "CityId":
					if (!UseFlowEngineMode) {
						break;
					}
					CityId = reader.GetGuidValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

