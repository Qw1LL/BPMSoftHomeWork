/**
 * @class BPMSoft.configuration.controller.ContactVCardQrScannerPage
 */
Ext.define("BPMSoft.configuration.controller.ContactVCardQrScannerPage", {
  extend: "BPMSoft.controller.BaseQrScannerPage",

  config: {
    refs: {
      view: "#ContactVCardQrScannerPage",
    },
  },

  vcardTags: [
    BPMSoft.VCardTagsConfig.titleTag,
    BPMSoft.VCardTagsConfig.formattedNameTag,
    BPMSoft.VCardTagsConfig.telTag,
    BPMSoft.VCardTagsConfig.emailTag,
    BPMSoft.VCardTagsConfig.urlTag,
  ],

  /**
   * Возвращает кастомный заголовок
   * @virtual
   * @overridden
   * @return {String | null} кастомный заголовок
   */
  getCustomTitle: function () {
    return BPMSoft.LS["ContactVCardQrScannerPage_navigationPanel_title"];
  },

  /**
   * Проверка формата
   * @public
   * @param {String} contents Контент QR-кода
   */
  checkQrFormat: function (contents) {
    const parsedData = BPMSoft.VCardParsers.vcardFormatParser(contents, [
      BPMSoft.VCardTagsConfig.beginTag,
    ]);
    if (parsedData && parsedData.format) {
      return parsedData.format.toUpperCase() === "VCARD";
    }
  },

  /**
   * Каллбек при удачном сканирование QR-кода
   * @virtual
   * @overridden
   * @param {String} contents Контент QR-кода
   */
  onSuccessScan: function (contents) {
    const isVCrad = this.checkQrFormat(contents);

    if (!isVCrad) {
      BPMSoft.Logger.error(
        Ext.String.format(
          "QR format not supported. " + "QR contents: {0}",
          contents
        )
      );
      const notSupportedFormatText =
        BPMSoft.LS["ContactVCardQrScannerPage_notSupportedQrFormat"];
      this.showAlertBanner(notSupportedFormatText);
      return;
    }
    const parsedData = BPMSoft.VCardParsers.vcardFormatParser(
      contents,
      this.vcardTags
    );

    const previousPageController =
      BPMSoft.PageNavigator.getPreviuosPageController();

    const mergeFun = (data) => {
      try {
        return this.mergeQrScannerResult(data);
      } catch (error) {
        data.controller.defaultExceptionHandler(error);
        return data.record;
      }
    };

    previousPageController
      .mergeRecordWithQrScannerResult(parsedData, mergeFun)
      .finally(() => {
        BPMSoft.Router.back();
      });
  },

  mergeQrScannerResult: async function ({
    record,
    qrScannerResult,
    controller,
  }) {
    const contactCommunicationDetailEmbeddedDetailName =
      "ContactCommunicationDetailEmbeddedDetail";
    const communicationTypeName = "CommunicationType";
    let communicationDetail;
    const supportedCommunicationTypes = {};

    const setRecordFields = () => {
      if (qrScannerResult.fullname) {
        record.set("Name", qrScannerResult.fullname);
      }
      if (qrScannerResult.title) {
        record.set("JobTitle", qrScannerResult.title);
      }
    };

    const needUpdateCommunicationDetail = () => {
      return (
        qrScannerResult.telephones ||
        qrScannerResult.emails ||
        qrScannerResult.url
      );
    };

    const findCommunicationDetail = () => {
      const pageHistoryItem = controller.getPageHistoryItem();
      const pageConfig = pageHistoryItem.getRawConfig();
      const communicationDetailId = BPMSoft.util.getColumnSetId(
        record.modelName,
        contactCommunicationDetailEmbeddedDetailName,
        pageConfig.type
      );
      communicationDetail = Ext.getCmp(communicationDetailId);
    };

    const fillSupportedCommunicationTypes = async () => {
      const communicationTypes = await BPMSoft.StoreUtils.getAllRecords(
        communicationTypeName
      );

      for (const type of communicationTypes) {
        switch (type.data.Id) {
          case BPMSoft.GUID.HomePhone:
            supportedCommunicationTypes.homePhone = type;
            break;
          case BPMSoft.GUID.WorkPhone:
            supportedCommunicationTypes.workPhone = type;
            break;
          case BPMSoft.GUID.MobilePhone:
            supportedCommunicationTypes.mobilePhone = type;
            break;
          case BPMSoft.GUID.OtherPhone:
            supportedCommunicationTypes.otherPhone = type;
            break;
          case BPMSoft.GUID.Email:
            supportedCommunicationTypes.email = type;
            break;
          case BPMSoft.GUID.URL:
            supportedCommunicationTypes.url = type;
            break;
        }
      }
    };

    const convertVcardTelTypeToCommunicationType = (phoneType) => {
      switch (phoneType) {
        case BPMSoft.VCardTelephoneType.work:
          return supportedCommunicationTypes.workPhone;
        case BPMSoft.VCardTelephoneType.home:
          return supportedCommunicationTypes.homePhone;
        case BPMSoft.VCardTelephoneType.car:
          return supportedCommunicationTypes.mobilePhone;
        case BPMSoft.VCardTelephoneType.cell:
          return supportedCommunicationTypes.mobilePhone;
        case BPMSoft.VCardTelephoneType.other:
          return supportedCommunicationTypes.otherPhone;
      }
    };

    const addCommunicationDetailItem = (value, type) => {
      const communicationDetailStore = communicationDetail.getStore();
      const communicationDetailModel = communicationDetailStore.getModel();

      const success = (loadedRecord) => {
        if (controller.isDestroyed) {
          return;
        }

        const sameRecords = communicationDetailStore.data.items.filter((v) => {
          return (
            v.data.Number === value && v.data.CommunicationType.Id === type.Id
          );
        });

        if (sameRecords.length) {
          return;
        }

        loadedRecord.set("Number", value);
        loadedRecord.set("CommunicationType", type);
        communicationDetail.addRecord(loadedRecord);
      };
      const failure = (exception) => {
        controller.defaultExceptionHandler(exception);
      };
      const cancellationConfig = {
        cancellationId: controller.getCancellationId("createDetail"),
      };

      communicationDetailModel.createWithDefaultValues(
        success,
        failure,
        controller,
        cancellationConfig
      );
    };

    const addPhoneNumber = (phoneNumber) => {
      const type = convertVcardTelTypeToCommunicationType(
        phoneNumber.type,
        supportedCommunicationTypes
      );

      addCommunicationDetailItem(phoneNumber.value, type);
    };

    const runMerge = async () => {
      if (!qrScannerResult) {
        return record;
      }
      setRecordFields();

      if (!needUpdateCommunicationDetail()) {
        return record;
      }

      findCommunicationDetail();
      if (!communicationDetail) {
        return record;
      }

      await fillSupportedCommunicationTypes();

      if (qrScannerResult.telephones) {
        qrScannerResult.telephones.map(addPhoneNumber);
      }
      if (qrScannerResult.emails) {
        qrScannerResult.emails.map((email) =>
          addCommunicationDetailItem(
            email.value,
            supportedCommunicationTypes.email
          )
        );
      }
      if (qrScannerResult.url) {
        addCommunicationDetailItem(
          qrScannerResult.url,
          supportedCommunicationTypes.url
        );
      }

      return record;
    };

    return runMerge();
  },
});
