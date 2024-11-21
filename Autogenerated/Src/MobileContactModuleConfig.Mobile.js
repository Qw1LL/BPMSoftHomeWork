BPMSoft.sdk.RecordPage.setTitle(
  "Contact",
  "create",
  "ContactEditPage_navigationPanel_title_create"
);
BPMSoft.sdk.RecordPage.setQrScannerButtonConfig("Contact", {
  visible: true,
  onTap: function () {
    var mainPageController = BPMSoft.util.getMainController();
    BPMSoft.Router.route("page", mainPageController, [
      {
        controllerName:
          "BPMSoft.configuration.controller.ContactVCardQrScannerPage",
        viewXClass: "BPMSoft.configuration.view.ContactVCardQrScannerPage",
      },
    ]);
  },
});

const contactCommunicationDetailEmbeddedDetailName =
  "ContactCommunicationDetailEmbeddedDetail";
const communicationTypeName = "CommunicationType";

BPMSoft.sdk.RecordPage.configureColumn(
  "Contact",
  "primaryColumnSet",
  "Account",
  {
    viewType: BPMSoft.ViewTypes.Preview,
  }
);

BPMSoft.sdk.RecordPage.configureColumn(
  "Contact",
  contactCommunicationDetailEmbeddedDetailName,
  "Number",
  {
    hideLabel: true,
    viewType: {
      typeColumn: communicationTypeName,
    },
    placeHolder:
      "ContactRecordPage_contactCommunicationsDetail_Number_placeHolder",
  }
);

BPMSoft.sdk.RecordPage.configureEmbeddedDetail(
  "Contact",
  contactCommunicationDetailEmbeddedDetailName,
  {
    title: "ContactRecordPage_contactCommunicationsDetail_title",
    displaySeparator: false,
    isCollapsed: false,
    hideTitle: true,
    previewConfig: {
      valueColumn: "Number",
      label: {
        column: communicationTypeName,
      },
    },
    isInPlaceEditingMode: true,
  }
);

BPMSoft.sdk.RecordPage.configureColumn(
  "Contact",
  contactCommunicationDetailEmbeddedDetailName,
  communicationTypeName,
  {
    useAsLabel: true,
    label: {
      emptyText:
        "ContactRecordPage_contactCommunicationsDetail_CommunicationType_emptyText",
      pickerTitle:
        "ContactRecordPage_contactCommunicationsDetail_CommunicationType_label",
    },
  }
);

BPMSoft.sdk.RecordPage.configureEmbeddedDetail(
  "Contact",
  "ContactAddressDetailV2EmbeddedDetail",
  {
    title: "ContactRecordPage_contactAddressesDetail_title",
    displaySeparator: true,
    orderByColumns: [
      {
        column: "Primary",
        orderType: BPMSoft.OrderTypes.DESC,
      },
    ],
    previewConfig:
      BPMSoft.Configuration.util.getAddressEmbeddedDetailPreviewConfig(),
    isInPlaceEditingMode: true,
    hideTitle: true,
  }
);

BPMSoft.sdk.RecordPage.configureColumn(
  "Contact",
  "ContactAddressDetailV2EmbeddedDetail",
  "Address",
  {
    viewType: BPMSoft.ViewTypes.Map,
    typeConfig: {
      searchColumns: ["Address", "City", "Region", "Country"],
    },
    isMultiline: true,
  }
);

BPMSoft.sdk.RecordPage.addColumn(
  "Contact",
  {
    name: "Primary",
    hidden: true,
  },
  "ContactAddressDetailV2EmbeddedDetail"
);

BPMSoft.sdk.RecordPage.configureEmbeddedDetail(
  "Contact",
  "ContactAnniversaryDetailV2EmbeddedDetail",
  {
    title: "ContactRecordPage_contactAnniversariesDetail_title",
    orderByColumns: [
      {
        column: "Date",
        orderType: BPMSoft.OrderTypes.ASC,
      },
    ],
    displaySeparator: false,
    previewConfig: {
      valueColumn: "Date",
      label: {
        column: "AnniversaryType",
      },
    },
    isInPlaceEditingMode: true,
  }
);

BPMSoft.sdk.RecordPage.configureColumn(
  "Contact",
  "ContactAnniversaryDetailV2EmbeddedDetail",
  "AnniversaryType",
  {
    useAsLabel: true,
    label: {
      emptyText:
        "ContactRecordPage_contactAnniversariesDetail_AnniversaryType_emptyText",
      pickerTitle:
        "ContactRecordPage_contactAnniversariesDetail_AnniversaryType_label",
    },
  }
);

BPMSoft.sdk.RecordPage.configureColumn(
  "Contact",
  "ContactAnniversaryDetailV2EmbeddedDetail",
  "Date",
  {
    hideLabel: true,
    viewType: {
      typeColumn: "AnniversaryType",
    },
    placeHolder:
      "ContactRecordPage_contactAnniversariesDetail_Date_placeHolder",
  }
);

BPMSoft.sdk.GridPage.setImageColumn(
  "Contact",
  "Photo.PreviewData",
  "MobileImageListDefaultContactPhoto"
);

BPMSoft.sdk.RecordPage.setImageConfig("Contact", {
  column: "Photo",
  imageDataColumnName: "PreviewData",
  imageDisplayColumnName: "Name",
  defaultImageId: "MobileImageListDefaultContactPhotoEdit",
});

BPMSoft.sdk.GridPage.setOrderByColumns("Contact", {
  column: "Name",
  orderType: BPMSoft.OrderTypes.ASC,
});

//Многострочность поля Имя
BPMSoft.sdk.RecordPage.configureColumn("Contact", "primaryColumnSet", "Name", {
  isMultiline: true,
});

BPMSoft.sdk.Actions.add("Contact", {
  name: "Meeting",
  isVisibleInGrid: true,
  isDisplayTitle: true,
  actionClassName: "BPMSoft.ActionMeeting",
  title: "Sys.Action.Meeting.Caption",
  defineTitle: "Sys.Action.Meeting.Title",
  modelName: "Activity",
  sourceModelColumnNames: ["Id", "Account"],
  destinationModelColumnNames: ["Contact", "Account"],
  evaluateModelColumnConfig: [
    {
      column: "Owner",
      value: {
        isMacros: true,
        value: BPMSoft.ValueMacros.CurrentUserContact,
      },
    },
    {
      column: "Author",
      value: {
        isMacros: true,
        value: BPMSoft.ValueMacros.CurrentUserContact,
      },
    },
    {
      column: "ActivityCategory",
      value: "42c74c49-58e6-df11-971b-001d60e938c6",
    },
    {
      column: "Priority",
      value: "ab96fa02-7fe6-df11-971b-001d60e938c6",
    },
    {
      column: "Status",
      value: "384d4b84-58e6-df11-971b-001d60e938c6",
    },
    {
      column: "Type",
      value: "fbe0acdc-cfc0-df11-b00f-001d60e938c6",
    },
  ],
});

BPMSoft.sdk.Actions.add("Contact", {
  name: "addContactCommunication",
  type: "addEmbeddedDetailRecord",
  title: "ContactRecordPageActionAddContactCommunicationCaption",
  detailName: contactCommunicationDetailEmbeddedDetailName,
  iconCls: BPMSoft.ActionIcons.Communication,
  isQuickAction: true,
  useMask: false,
});

BPMSoft.sdk.Actions.add("Contact", {
  name: "addContactAddress",
  type: "addEmbeddedDetailRecord",
  title: "ContactRecordPageActionAddAddressCaption",
  detailName: "ContactAddressDetailV2EmbeddedDetail",
  iconCls: BPMSoft.ActionIcons.Address,
  isQuickAction: true,
  useMask: false,
});

BPMSoft.sdk.Actions.add("Contact", {
  name: "addContactAnniversary",
  type: "addEmbeddedDetailRecord",
  title: "ContactRecordPageActionAddAnniversaryCaption",
  detailName: "ContactAnniversaryDetailV2EmbeddedDetail",
  iconCls: BPMSoft.ActionIcons.Activity,
  isQuickAction: true,
  useMask: false,
});

BPMSoft.sdk.Actions.setOrder("Contact", {
  addContactCommunication: 0,
  addContactAddress: 1,
  addContactAnniversary: 2,
  Meeting: 3,
  "BPMSoft.configuration.action.ShareLink": 4,
  "BPMSoft.ActionCopy": 5,
  "BPMSoft.ActionDelete": 6,
});

BPMSoft.sdk.Details.configure("Contact", "ActivityDetailV2StandartDetail", {
  filters: Ext.create("BPMSoft.Filter", {
    type: BPMSoft.FilterTypes.Group,
    subfilters: [
      Ext.create("BPMSoft.Filter", {
        compareType: BPMSoft.ComparisonTypes.NotEqual,
        property: "Type",
        value: BPMSoft.GUID.ActivityTypeEmail,
      }),
    ],
  }),
});
