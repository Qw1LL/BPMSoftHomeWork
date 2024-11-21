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

	#region Class: DaDataAccountSearch

	[DesignModeProperty(Name = "Kpp", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.Kpp.Caption", DescriptionResourceItem = "Parameters.Kpp.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Inn", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.Inn.Caption", DescriptionResourceItem = "Parameters.Inn.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsMain", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.IsMain.Caption", DescriptionResourceItem = "Parameters.IsMain.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DaDataAccountTypeId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.DaDataAccountTypeId.Caption", DescriptionResourceItem = "Parameters.DaDataAccountTypeId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "UnrestrictedValue", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.UnrestrictedValue.Caption", DescriptionResourceItem = "Parameters.UnrestrictedValue.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Ogrn", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.Ogrn.Caption", DescriptionResourceItem = "Parameters.Ogrn.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "OgrnDate", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.OgrnDate.Caption", DescriptionResourceItem = "Parameters.OgrnDate.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "NameFullWithOpf", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.NameFullWithOpf.Caption", DescriptionResourceItem = "Parameters.NameFullWithOpf.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "NameShortWithOpf", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.NameShortWithOpf.Caption", DescriptionResourceItem = "Parameters.NameShortWithOpf.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "NameFull", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.NameFull.Caption", DescriptionResourceItem = "Parameters.NameFull.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "NameShort", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.NameShort.Caption", DescriptionResourceItem = "Parameters.NameShort.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Okato", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.Okato.Caption", DescriptionResourceItem = "Parameters.Okato.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Oktmo", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.Oktmo.Caption", DescriptionResourceItem = "Parameters.Oktmo.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Okpo", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.Okpo.Caption", DescriptionResourceItem = "Parameters.Okpo.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Okogu", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.Okogu.Caption", DescriptionResourceItem = "Parameters.Okogu.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Okfs", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.Okfs.Caption", DescriptionResourceItem = "Parameters.Okfs.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Okved", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.Okved.Caption", DescriptionResourceItem = "Parameters.Okved.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "OpfFull", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.OpfFull.Caption", DescriptionResourceItem = "Parameters.OpfFull.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "OpfShort", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.OpfShort.Caption", DescriptionResourceItem = "Parameters.OpfShort.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "OpfCode", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.OpfCode.Caption", DescriptionResourceItem = "Parameters.OpfCode.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ManagementName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.ManagementName.Caption", DescriptionResourceItem = "Parameters.ManagementName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ManagementPost", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.ManagementPost.Caption", DescriptionResourceItem = "Parameters.ManagementPost.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Address", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.Address.Caption", DescriptionResourceItem = "Parameters.Address.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DaDataAccountStatusId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.DaDataAccountStatusId.Caption", DescriptionResourceItem = "Parameters.DaDataAccountStatusId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RegistrationDate", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.RegistrationDate.Caption", DescriptionResourceItem = "Parameters.RegistrationDate.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "LiquidationDate", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.LiquidationDate.Caption", DescriptionResourceItem = "Parameters.LiquidationDate.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ActualityDate", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.ActualityDate.Caption", DescriptionResourceItem = "Parameters.ActualityDate.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AccountFound", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AccountFound.Caption", DescriptionResourceItem = "Parameters.AccountFound.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ErrorText", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.ErrorText.Caption", DescriptionResourceItem = "Parameters.ErrorText.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "BranchCount", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.BranchCount.Caption", DescriptionResourceItem = "Parameters.BranchCount.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DaDataBranchTypeId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.DaDataBranchTypeId.Caption", DescriptionResourceItem = "Parameters.DaDataBranchTypeId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AccountOwnershipId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AccountOwnershipId.Caption", DescriptionResourceItem = "Parameters.AccountOwnershipId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressPostalCode", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressPostalCode.Caption", DescriptionResourceItem = "Parameters.AddressPostalCode.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressCountry", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressCountry.Caption", DescriptionResourceItem = "Parameters.AddressCountry.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressCountryIsoCode", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressCountryIsoCode.Caption", DescriptionResourceItem = "Parameters.AddressCountryIsoCode.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressFederalDistrict", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressFederalDistrict.Caption", DescriptionResourceItem = "Parameters.AddressFederalDistrict.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressRegion", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressRegion.Caption", DescriptionResourceItem = "Parameters.AddressRegion.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressRegionFiasId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressRegionFiasId.Caption", DescriptionResourceItem = "Parameters.AddressRegionFiasId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressArea", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressArea.Caption", DescriptionResourceItem = "Parameters.AddressArea.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressAreaFiasId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressAreaFiasId.Caption", DescriptionResourceItem = "Parameters.AddressAreaFiasId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressCity", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressCity.Caption", DescriptionResourceItem = "Parameters.AddressCity.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressCityFiasId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressCityFiasId.Caption", DescriptionResourceItem = "Parameters.AddressCityFiasId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressCityDistrict", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressCityDistrict.Caption", DescriptionResourceItem = "Parameters.AddressCityDistrict.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressCityDistrictFiasId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressCityDistrictFiasId.Caption", DescriptionResourceItem = "Parameters.AddressCityDistrictFiasId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressSettlement", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressSettlement.Caption", DescriptionResourceItem = "Parameters.AddressSettlement.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressSettlementFiasId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressSettlementFiasId.Caption", DescriptionResourceItem = "Parameters.AddressSettlementFiasId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressStreet", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressStreet.Caption", DescriptionResourceItem = "Parameters.AddressStreet.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressStreetFiasId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressStreetFiasId.Caption", DescriptionResourceItem = "Parameters.AddressStreetFiasId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressHouse", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressHouse.Caption", DescriptionResourceItem = "Parameters.AddressHouse.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressHouseFiasId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressHouseFiasId.Caption", DescriptionResourceItem = "Parameters.AddressHouseFiasId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressBlock", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressBlock.Caption", DescriptionResourceItem = "Parameters.AddressBlock.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressFlat", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressFlat.Caption", DescriptionResourceItem = "Parameters.AddressFlat.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressOkato", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressOkato.Caption", DescriptionResourceItem = "Parameters.AddressOkato.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressOktmo", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressOktmo.Caption", DescriptionResourceItem = "Parameters.AddressOktmo.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressGeoLat", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressGeoLat.Caption", DescriptionResourceItem = "Parameters.AddressGeoLat.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressGeoLon", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressGeoLon.Caption", DescriptionResourceItem = "Parameters.AddressGeoLon.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressCountryId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressCountryId.Caption", DescriptionResourceItem = "Parameters.AddressCountryId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressRegionId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressRegionId.Caption", DescriptionResourceItem = "Parameters.AddressRegionId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddressCityId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4732d1b0951a4885b6f7b075a8bc2f15", CaptionResourceItem = "Parameters.AddressCityId.Caption", DescriptionResourceItem = "Parameters.AddressCityId.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class DaDataAccountSearch : ProcessUserTask
	{

		#region Constructors: Public

		public DaDataAccountSearch(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("4732d1b0-951a-4885-b6f7-b075a8bc2f15");
		}

		#endregion

		#region Properties: Public

		public virtual string Kpp {
			get;
			set;
		}

		public virtual string Inn {
			get;
			set;
		}

		public virtual bool IsMain {
			get;
			set;
		}

		public virtual Guid DaDataAccountTypeId {
			get;
			set;
		}

		public virtual string UnrestrictedValue {
			get;
			set;
		}

		public virtual string Ogrn {
			get;
			set;
		}

		public virtual DateTime OgrnDate {
			get;
			set;
		}

		public virtual string NameFullWithOpf {
			get;
			set;
		}

		public virtual string NameShortWithOpf {
			get;
			set;
		}

		public virtual string NameFull {
			get;
			set;
		}

		public virtual string NameShort {
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

		public virtual string Okpo {
			get;
			set;
		}

		public virtual string Okogu {
			get;
			set;
		}

		public virtual string Okfs {
			get;
			set;
		}

		public virtual string Okved {
			get;
			set;
		}

		public virtual string OpfFull {
			get;
			set;
		}

		public virtual string OpfShort {
			get;
			set;
		}

		public virtual string OpfCode {
			get;
			set;
		}

		public virtual string ManagementName {
			get;
			set;
		}

		public virtual string ManagementPost {
			get;
			set;
		}

		public virtual string Address {
			get;
			set;
		}

		public virtual Guid DaDataAccountStatusId {
			get;
			set;
		}

		public virtual DateTime RegistrationDate {
			get;
			set;
		}

		public virtual DateTime LiquidationDate {
			get;
			set;
		}

		public virtual DateTime ActualityDate {
			get;
			set;
		}

		public virtual bool AccountFound {
			get;
			set;
		}

		public virtual string ErrorText {
			get;
			set;
		}

		public virtual int BranchCount {
			get;
			set;
		}

		public virtual Guid DaDataBranchTypeId {
			get;
			set;
		}

		public virtual Guid AccountOwnershipId {
			get;
			set;
		}

		public virtual string AddressPostalCode {
			get;
			set;
		}

		public virtual string AddressCountry {
			get;
			set;
		}

		public virtual string AddressCountryIsoCode {
			get;
			set;
		}

		public virtual string AddressFederalDistrict {
			get;
			set;
		}

		public virtual string AddressRegion {
			get;
			set;
		}

		public virtual string AddressRegionFiasId {
			get;
			set;
		}

		public virtual string AddressArea {
			get;
			set;
		}

		public virtual string AddressAreaFiasId {
			get;
			set;
		}

		public virtual string AddressCity {
			get;
			set;
		}

		public virtual string AddressCityFiasId {
			get;
			set;
		}

		public virtual string AddressCityDistrict {
			get;
			set;
		}

		public virtual string AddressCityDistrictFiasId {
			get;
			set;
		}

		public virtual string AddressSettlement {
			get;
			set;
		}

		public virtual string AddressSettlementFiasId {
			get;
			set;
		}

		public virtual string AddressStreet {
			get;
			set;
		}

		public virtual string AddressStreetFiasId {
			get;
			set;
		}

		public virtual string AddressHouse {
			get;
			set;
		}

		public virtual string AddressHouseFiasId {
			get;
			set;
		}

		public virtual string AddressBlock {
			get;
			set;
		}

		public virtual string AddressFlat {
			get;
			set;
		}

		public virtual string AddressOkato {
			get;
			set;
		}

		public virtual string AddressOktmo {
			get;
			set;
		}

		public virtual string AddressGeoLat {
			get;
			set;
		}

		public virtual string AddressGeoLon {
			get;
			set;
		}

		public virtual Guid AddressCountryId {
			get;
			set;
		}

		public virtual Guid AddressRegionId {
			get;
			set;
		}

		public virtual Guid AddressCityId {
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
				if (!HasMapping("Kpp")) {
					writer.WriteValue("Kpp", Kpp, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("Inn")) {
					writer.WriteValue("Inn", Inn, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("IsMain")) {
					writer.WriteValue("IsMain", IsMain, false);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("DaDataAccountTypeId")) {
					writer.WriteValue("DaDataAccountTypeId", DaDataAccountTypeId, Guid.Empty);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("UnrestrictedValue")) {
					writer.WriteValue("UnrestrictedValue", UnrestrictedValue, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("Ogrn")) {
					writer.WriteValue("Ogrn", Ogrn, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("OgrnDate")) {
					writer.WriteValue("OgrnDate", OgrnDate, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("NameFullWithOpf")) {
					writer.WriteValue("NameFullWithOpf", NameFullWithOpf, null);
				}
			}
			if (!HasMapping("NameShortWithOpf")) {
				writer.WriteValue("NameShortWithOpf", NameShortWithOpf, null);
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("NameFull")) {
					writer.WriteValue("NameFull", NameFull, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("NameShort")) {
					writer.WriteValue("NameShort", NameShort, null);
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
				if (!HasMapping("Okpo")) {
					writer.WriteValue("Okpo", Okpo, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("Okogu")) {
					writer.WriteValue("Okogu", Okogu, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("Okfs")) {
					writer.WriteValue("Okfs", Okfs, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("Okved")) {
					writer.WriteValue("Okved", Okved, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("OpfFull")) {
					writer.WriteValue("OpfFull", OpfFull, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("OpfShort")) {
					writer.WriteValue("OpfShort", OpfShort, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("OpfCode")) {
					writer.WriteValue("OpfCode", OpfCode, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("ManagementName")) {
					writer.WriteValue("ManagementName", ManagementName, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("ManagementPost")) {
					writer.WriteValue("ManagementPost", ManagementPost, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("Address")) {
					writer.WriteValue("Address", Address, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("DaDataAccountStatusId")) {
					writer.WriteValue("DaDataAccountStatusId", DaDataAccountStatusId, Guid.Empty);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("RegistrationDate")) {
					writer.WriteValue("RegistrationDate", RegistrationDate, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("LiquidationDate")) {
					writer.WriteValue("LiquidationDate", LiquidationDate, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("ActualityDate")) {
					writer.WriteValue("ActualityDate", ActualityDate, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AccountFound")) {
					writer.WriteValue("AccountFound", AccountFound, false);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("ErrorText")) {
					writer.WriteValue("ErrorText", ErrorText, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("BranchCount")) {
					writer.WriteValue("BranchCount", BranchCount, 0);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("DaDataBranchTypeId")) {
					writer.WriteValue("DaDataBranchTypeId", DaDataBranchTypeId, Guid.Empty);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AccountOwnershipId")) {
					writer.WriteValue("AccountOwnershipId", AccountOwnershipId, Guid.Empty);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressPostalCode")) {
					writer.WriteValue("AddressPostalCode", AddressPostalCode, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressCountry")) {
					writer.WriteValue("AddressCountry", AddressCountry, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressCountryIsoCode")) {
					writer.WriteValue("AddressCountryIsoCode", AddressCountryIsoCode, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressFederalDistrict")) {
					writer.WriteValue("AddressFederalDistrict", AddressFederalDistrict, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressRegion")) {
					writer.WriteValue("AddressRegion", AddressRegion, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressRegionFiasId")) {
					writer.WriteValue("AddressRegionFiasId", AddressRegionFiasId, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressArea")) {
					writer.WriteValue("AddressArea", AddressArea, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressAreaFiasId")) {
					writer.WriteValue("AddressAreaFiasId", AddressAreaFiasId, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressCity")) {
					writer.WriteValue("AddressCity", AddressCity, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressCityFiasId")) {
					writer.WriteValue("AddressCityFiasId", AddressCityFiasId, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressCityDistrict")) {
					writer.WriteValue("AddressCityDistrict", AddressCityDistrict, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressCityDistrictFiasId")) {
					writer.WriteValue("AddressCityDistrictFiasId", AddressCityDistrictFiasId, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressSettlement")) {
					writer.WriteValue("AddressSettlement", AddressSettlement, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressSettlementFiasId")) {
					writer.WriteValue("AddressSettlementFiasId", AddressSettlementFiasId, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressStreet")) {
					writer.WriteValue("AddressStreet", AddressStreet, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressStreetFiasId")) {
					writer.WriteValue("AddressStreetFiasId", AddressStreetFiasId, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressHouse")) {
					writer.WriteValue("AddressHouse", AddressHouse, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressHouseFiasId")) {
					writer.WriteValue("AddressHouseFiasId", AddressHouseFiasId, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressBlock")) {
					writer.WriteValue("AddressBlock", AddressBlock, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressFlat")) {
					writer.WriteValue("AddressFlat", AddressFlat, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressOkato")) {
					writer.WriteValue("AddressOkato", AddressOkato, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressOktmo")) {
					writer.WriteValue("AddressOktmo", AddressOktmo, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressGeoLat")) {
					writer.WriteValue("AddressGeoLat", AddressGeoLat, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressGeoLon")) {
					writer.WriteValue("AddressGeoLon", AddressGeoLon, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressCountryId")) {
					writer.WriteValue("AddressCountryId", AddressCountryId, Guid.Empty);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressRegionId")) {
					writer.WriteValue("AddressRegionId", AddressRegionId, Guid.Empty);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("AddressCityId")) {
					writer.WriteValue("AddressCityId", AddressCityId, Guid.Empty);
				}
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "Kpp":
					if (!UseFlowEngineMode) {
						break;
					}
					Kpp = reader.GetStringValue();
				break;
				case "Inn":
					if (!UseFlowEngineMode) {
						break;
					}
					Inn = reader.GetStringValue();
				break;
				case "IsMain":
					if (!UseFlowEngineMode) {
						break;
					}
					IsMain = reader.GetBoolValue();
				break;
				case "DaDataAccountTypeId":
					if (!UseFlowEngineMode) {
						break;
					}
					DaDataAccountTypeId = reader.GetGuidValue();
				break;
				case "UnrestrictedValue":
					if (!UseFlowEngineMode) {
						break;
					}
					UnrestrictedValue = reader.GetStringValue();
				break;
				case "Ogrn":
					if (!UseFlowEngineMode) {
						break;
					}
					Ogrn = reader.GetStringValue();
				break;
				case "OgrnDate":
					if (!UseFlowEngineMode) {
						break;
					}
					OgrnDate = reader.GetDateTimeValue();
				break;
				case "NameFullWithOpf":
					if (!UseFlowEngineMode) {
						break;
					}
					NameFullWithOpf = reader.GetStringValue();
				break;
				case "NameShortWithOpf":
					NameShortWithOpf = reader.GetStringValue();
				break;
				case "NameFull":
					if (!UseFlowEngineMode) {
						break;
					}
					NameFull = reader.GetStringValue();
				break;
				case "NameShort":
					if (!UseFlowEngineMode) {
						break;
					}
					NameShort = reader.GetStringValue();
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
				case "Okpo":
					if (!UseFlowEngineMode) {
						break;
					}
					Okpo = reader.GetStringValue();
				break;
				case "Okogu":
					if (!UseFlowEngineMode) {
						break;
					}
					Okogu = reader.GetStringValue();
				break;
				case "Okfs":
					if (!UseFlowEngineMode) {
						break;
					}
					Okfs = reader.GetStringValue();
				break;
				case "Okved":
					if (!UseFlowEngineMode) {
						break;
					}
					Okved = reader.GetStringValue();
				break;
				case "OpfFull":
					if (!UseFlowEngineMode) {
						break;
					}
					OpfFull = reader.GetStringValue();
				break;
				case "OpfShort":
					if (!UseFlowEngineMode) {
						break;
					}
					OpfShort = reader.GetStringValue();
				break;
				case "OpfCode":
					if (!UseFlowEngineMode) {
						break;
					}
					OpfCode = reader.GetStringValue();
				break;
				case "ManagementName":
					if (!UseFlowEngineMode) {
						break;
					}
					ManagementName = reader.GetStringValue();
				break;
				case "ManagementPost":
					if (!UseFlowEngineMode) {
						break;
					}
					ManagementPost = reader.GetStringValue();
				break;
				case "Address":
					if (!UseFlowEngineMode) {
						break;
					}
					Address = reader.GetStringValue();
				break;
				case "DaDataAccountStatusId":
					if (!UseFlowEngineMode) {
						break;
					}
					DaDataAccountStatusId = reader.GetGuidValue();
				break;
				case "RegistrationDate":
					if (!UseFlowEngineMode) {
						break;
					}
					RegistrationDate = reader.GetDateTimeValue();
				break;
				case "LiquidationDate":
					if (!UseFlowEngineMode) {
						break;
					}
					LiquidationDate = reader.GetDateTimeValue();
				break;
				case "ActualityDate":
					if (!UseFlowEngineMode) {
						break;
					}
					ActualityDate = reader.GetDateTimeValue();
				break;
				case "AccountFound":
					if (!UseFlowEngineMode) {
						break;
					}
					AccountFound = reader.GetBoolValue();
				break;
				case "ErrorText":
					if (!UseFlowEngineMode) {
						break;
					}
					ErrorText = reader.GetStringValue();
				break;
				case "BranchCount":
					if (!UseFlowEngineMode) {
						break;
					}
					BranchCount = reader.GetIntValue();
				break;
				case "DaDataBranchTypeId":
					if (!UseFlowEngineMode) {
						break;
					}
					DaDataBranchTypeId = reader.GetGuidValue();
				break;
				case "AccountOwnershipId":
					if (!UseFlowEngineMode) {
						break;
					}
					AccountOwnershipId = reader.GetGuidValue();
				break;
				case "AddressPostalCode":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressPostalCode = reader.GetStringValue();
				break;
				case "AddressCountry":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressCountry = reader.GetStringValue();
				break;
				case "AddressCountryIsoCode":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressCountryIsoCode = reader.GetStringValue();
				break;
				case "AddressFederalDistrict":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressFederalDistrict = reader.GetStringValue();
				break;
				case "AddressRegion":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressRegion = reader.GetStringValue();
				break;
				case "AddressRegionFiasId":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressRegionFiasId = reader.GetStringValue();
				break;
				case "AddressArea":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressArea = reader.GetStringValue();
				break;
				case "AddressAreaFiasId":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressAreaFiasId = reader.GetStringValue();
				break;
				case "AddressCity":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressCity = reader.GetStringValue();
				break;
				case "AddressCityFiasId":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressCityFiasId = reader.GetStringValue();
				break;
				case "AddressCityDistrict":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressCityDistrict = reader.GetStringValue();
				break;
				case "AddressCityDistrictFiasId":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressCityDistrictFiasId = reader.GetStringValue();
				break;
				case "AddressSettlement":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressSettlement = reader.GetStringValue();
				break;
				case "AddressSettlementFiasId":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressSettlementFiasId = reader.GetStringValue();
				break;
				case "AddressStreet":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressStreet = reader.GetStringValue();
				break;
				case "AddressStreetFiasId":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressStreetFiasId = reader.GetStringValue();
				break;
				case "AddressHouse":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressHouse = reader.GetStringValue();
				break;
				case "AddressHouseFiasId":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressHouseFiasId = reader.GetStringValue();
				break;
				case "AddressBlock":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressBlock = reader.GetStringValue();
				break;
				case "AddressFlat":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressFlat = reader.GetStringValue();
				break;
				case "AddressOkato":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressOkato = reader.GetStringValue();
				break;
				case "AddressOktmo":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressOktmo = reader.GetStringValue();
				break;
				case "AddressGeoLat":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressGeoLat = reader.GetStringValue();
				break;
				case "AddressGeoLon":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressGeoLon = reader.GetStringValue();
				break;
				case "AddressCountryId":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressCountryId = reader.GetGuidValue();
				break;
				case "AddressRegionId":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressRegionId = reader.GetGuidValue();
				break;
				case "AddressCityId":
					if (!UseFlowEngineMode) {
						break;
					}
					AddressCityId = reader.GetGuidValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

