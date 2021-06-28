using OpenQA.Selenium;
using System.Collections.Generic;

namespace SpecflowFirst.Pages
{
    public class PermittingPage
    {
        private IWebDriver _webDriver;
        CommonPage common;
        public PermittingPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            common = new CommonPage(webDriver);
        }

        //use string[1] for options that cannot change
        //use string[n] for options that can change to multiple values (n values)
        public static List<string[]> menuOptions = new List<string[]> {
            new string[1] { "Edit" },
            new string[1] { "Add Record" },
            new string[1] { "Duplicate" },
            new string[1] { "Link to..." },
            new string[1] { "Edit Type/Subtype" },
            new string[1] { "Add Additional Sites" },
            new string[1] { "View Timeline" },
            new string[2] { "Follow Permit", "Un-Follow Permit" },
            new string[1] { "Break Link" },
            new string[1] { "Send Email" }
        };

        public const int typeCode = 2;
        public IWebElement btnAddNotes => _webDriver.FindElement(By.Id("ctl09_C_ctl00_btnAddNotes"));
        public IWebElement informationPane => _webDriver.FindElement(By.Id("ctl09"));
        public IWebElement informationBar => _webDriver.FindElement(By.Id("ctl09_T"));
        public IWebElement btnAddInspection => _webDriver.FindElement(By.Id("ctl14_C_ctl00_btnAddInspection"));
        IWebElement inspectionPane => _webDriver.FindElement(By.Id("ctl14"));
        public IWebElement inspectionBar => _webDriver.FindElement(By.Id("ctl14_T"));
        public By informationBarLocator => By.Id("ctl09_T");
        public By mainMenuLocator => By.Id("ctl09_C_ctl00_radActionsMenu");
        public IWebElement mainMenu => _webDriver.FindElement(By.Id("ctl09_C_ctl00_radActionsMenu"));

        //IWebElement editRecordAppliedDateCalendarButton => _webDriver.FindElement(By.Id("ctl09_C_ctl00_calAppliedDate_popupButton"));
        //IWebElement editRecordAppliedDateTodayButton => _webDriver.FindElement(By.Id("ctl09_C_ctl00_btnAppliedDateToday"));
        //IWebElement editRecordAppliedDateInput => _webDriver.FindElement(By.Id("ctl09_C_ctl00_calAppliedDate_dateInput"));
        //IWebElement editRecordStatusDropDown => _webDriver.FindElement(By.Id("ctl09_C_ctl00_ddStatus_DropDown"));
        //IWebElement editRecordStatusInput => _webDriver.FindElement(By.Id("ctl09_C_ctl00_ddStatus_Input"));
        //IWebElement editButton => _webDriver.FindElement(By.Id("ctl09_C_ctl00_btnEdit"));
        //IWebElement editRecordApprovedDateInput => _webDriver.FindElement(By.Id("ctl09_C_ctl00_calApprovedDate_dateInput"));
        //IWebElement editRecordApprovedDateTodayButton => _webDriver.FindElement(By.Id("ctl09_C_ctl00_btnApprovedDateToday"));
        //IWebElement editRecordApprovedDateCalendarButton => _webDriver.FindElement(By.Id("ctl09_C_ctl00_calApprovedDate_popupButton"));
        //IWebElement editRecordIssuedDateInput => _webDriver.FindElement(By.Id("ctl09_C_ctl00_calIssuedDate_dateInput"));
        //IWebElement editRecordIssuedDateTodayButton => _webDriver.FindElement(By.Id("ctl09_C_ctl00_btnIssuedDateToday"));
        //IWebElement editRecordIssuedDateCalendarButton => _webDriver.FindElement(By.Id("ctl09_C_ctl00_calIssuedDate_popupButton"));
        //IWebElement editRecordFinaledDateInput => _webDriver.FindElement(By.Id("ctl09_C_ctl00_calFinaledDate_dateInput"));
        //IWebElement editRecordFinalDateTodayButton => _webDriver.FindElement(By.Id("ctl09_C_ctl00_btnFinalDateToday"));
        //IWebElement editRecordFinalDateCalendarButton => _webDriver.FindElement(By.Id("ctl09_C_ctl00_calFinalDate_popupButton"));
        //IWebElement editRecordOtherDateInput => _webDriver.FindElement(By.Id("ctl09_C_ctl00_calOtherDate1_dateInput"));
        //IWebElement editRecordOtherDateTodayButton => _webDriver.FindElement(By.Id("ctl09_C_ctl00_btnOtherDate1Today"));
        //IWebElement editRecordOtherDateCalendarButton => _webDriver.FindElement(By.Id("ctl09_C_ctl00_calOtherDate1_popupButton"));
        //IWebElement editRecordExpiredDateInput => _webDriver.FindElement(By.Id("ctl09_C_ctl00_calExpiredDate_dateInput"));


        //public static By
        //    editRecordExpiredDateTodayButton = By.Id("ctl09_C_ctl00_btnExpiredDateToday"),
        //    editRecordExpiredDateCalendarButton = By.Id("ctl09_C_ctl00_calExpiredDate_popupButton"),
        //    editRecordDescriptionInput = By.Id("ctl09_C_ctl00_txtDescription"),
        //    notesButton = By.Id("ctl09_C_ctl00_btnAddNotes"),
        //    notesButtonToolTip = By.XPath("//*[@id='RadToolTipWrapper_ctl09_C_ctl00_rttNotes']/table/tbody/tr[2]/td[2]/div/div"),
        //    editRecordSaveButton = By.Id("ctl09_C_ctl00_btnSave"),
        //    editRecordCancelButton = By.Id("ctl09_C_ctl00_btnRevert"),
        //    recordStatus = By.Id("ctl09_C_ctl00_lblStatus"),
        //    recordLockedButton = By.Id("ctl09_C_ctl00_btnLocked"),
        //    contactPane = By.Id("ctl10"),
        //    contactBar = By.Id("ctl10_T"),
        //    valuationsBar = By.Id("ctl11"),
        //    valuationsPane = By.Id("ctl11_T"),
        //    addValuationsButton = By.Id("ctl11_C_ctl00_btnAddValuation"),
        //    applyModelHomeButton = By.Id("ctl11_C_ctl00_btnApplyModelHome"),
        //    financialPane = By.Id("ctl12"),
        //    financialBar = By.Id("ctl12_T"),
        //    conditionsPane = By.Id("ctl13"),
        //    conditionsBar = By.Id("ctl13_T"),
        //    addConditionsButton = By.Id("ctl13_C_ctl00_btnAddCondition"),
        //    conditionsReorderButton = By.Id("ctl13_C_ctl00_btnReorderConditions"),
        //    conditionsFilterButton = By.Id("ctl13_C_ctl00_btnConditionFilterSettings"),
        //    inspectionPane = By.Id("ctl14"),
        //    inspectionBar = By.Id("ctl14_T"),
        //    reviewPane = By.Id("ctl15"),
        //    reviewBar = By.Id("ctl15_T"),
        //    addReviewButton = By.Id("ctl15_C_ctl00_btnAddReview"),
        //    chronologyPane = By.Id("ctl16"),
        //    chronologyBar = By.Id("ctl16_T"),
        //    addActionsButton = By.Id("ctl16_C_ctl00_btnAddAction"),
        //    chronologyFilterButton = By.Id("ctl16_C_ctl00_btnChronologyFilterSettings"),
        //    scheduleEventButton = By.Id("ctl16_C_ctl00_btnScheduleEvent"),
        //    customScreensBar = By.Id("ctl17"),
        //    customScreensPane = By.Id("ctl17_T"),
        //    customScreensEditButton = By.Id("ctl17_C_ctl00_btnEdit"),
        //    customScreens_eTRAKiTUDFTestTab = By.XPath(".//*[@id='ctl17_C_ctl00_rtsCustomScreens']//span[@class='rtsTxt' and contains(., 'eTRAKiT UDF Test')]"),
        //    customScreens_Test1Cbx = By.XPath(".//input[./../../span[.='Test1'] and contains(@id, '_lblUDFItem')]"),
        //    customScreens_Test2 = By.XPath(".//table[./../span[.='Test2'] and contains(@id, '_tblDate')]//*[contains(@id, '_lblUDFItem')]"),
        //    customScreens_Test3 = By.XPath(".//span[./../span[.='Test3'] and contains(@id, '_lblUDFItem')]"),
        //    customScreens_Test4 = By.XPath(".//span[./../span[.='Test4'] and contains(@id, '_lblUDFItem')]"),
        //    customScreens_Test5NotesButton = By.XPath(".//img[./../span[.='Test5'] and contains(@onclick, 'openNotes')]"),
        //    customScreens_Test6 = By.XPath(".//span[./../span[.='Test6'] and contains(@id, '_lblUDFItem')]"),
        //    bondsPane = By.Id("ctl18"),
        //    bondsBar = By.Id("ctl18_T"),
        //    addBondsButton = By.Id("ctl18_C_ctl00_imgBtnAddBonds"),
        //    payBondsButton = By.Id("ctl18_C_ctl00_imgBtnPayBonds"),
        //    unpayBondsButton = By.Id("ctl18_C_ctl00_imgBtnUnPay"),
        //    bondsDueLink = By.Id("ctl18_C_ctl00_lnkBtnFeesDue"),
        //    receiptsBondsButton = By.Id("ctl18_C_ctl00_imgBtnReceipts"),
        //    addCalendarButton = By.Id("ctl14_C_ctl00_btnCalendar"),
        //    addInspectionButton = By.Id("ctl14_C_ctl00_btnAddInspection"),
        //    radMenu = By.Id("ctl09_C_ctl00_radActionsMenu"),
        //    geoRadMenu = By.Id("ctl09_C_ctl00_radGeoActionsMenu"),
        //    addContactButton = By.Id("ctl10_C_ctl00_btnAddContact"),
        //    addFeeButton = By.Id("ctl12_C_ctl00_imgBtnAddFees"),
        //    refundFeeButton = By.Id("ctl12_C_ctl00_imgBtnRefund"),
        //    receiptsButton = By.Id("ctl12_C_ctl00_imgBtnReceipts"),
        //    saveAllFeesButton = By.Id("ctl12_C_ctl00_imgBtnSaveAllFeesBottom"),
        //    editAllFeesButton = By.Id("ctl12_C_ctl00_imgBtnEditAllFeesBottom"),
        //    payFeeButton = By.Id("ctl12_C_ctl00_imgBtnPayFees"),
        //    unpayFeeButton = By.Id("ctl12_C_ctl00_imgBtnUnPay"),
        //    createInvoiceButton = By.Id("ctl12_C_ctl00_imgBtnInvoicing"),
        //    feeHistoryButton = By.Id("ctl12_C_ctl00_imgBtnHistory"),
        //    depositsButton = By.Id("ctl12_C_ctl00_imgBtnDeposits"),
        //    feesChargedLink = By.Id("ctl12_C_ctl00_hlFeesCharged"),
        //    feesDueLink = By.Id("ctl12_C_ctl00_lnkBtnFeesDue"),
        //    feesPaidLink = By.Id("ctl12_C_ctl00_lnkFeesPaid"),
        //    depositBalanceLink = By.Id("ctl12_C_ctl00_hlDepositBal"),

        //    recordName = By.Id("ctl09_C_ctl00_lblActivityNoNoEdit"),
        //    recordType = By.Id("ctl09_C_ctl00_lblPermitTypeNoEdit"),
        //    recordApplicant = By.Id("ctl09_C_ctl00_lblApplicantNameNoEdit"),
        //    recordSubtype = By.Id("ctl09_C_ctl00_lblPermitSubTypeNoEdit"),
        //    recordApplied = By.Id("ctl09_C_ctl00_lblAppliedDate"),
        //    recordApproved = By.Id("ctl09_C_ctl00_lblApprovedDate"),
        //    recordIssued = By.Id("ctl09_C_ctl00_lblIssuedDate"),
        //    recordFinaled = By.Id("ctl09_C_ctl00_lblFinaledDate"),
        //    recordOther = By.Id("ctl09_C_ctl00_lblOtherDate1"),
        //    recordExpired = By.Id("ctl09_C_ctl00_lblExpiredDate"),
        //    recordDescription = By.Id("ctl09_C_ctl00_lblDescription"),
        //    linkedGeoRecord = By.Id("ctl09_C_ctl00_hlSiteAPN"),

        //    siteTreeGeoRecord = By.XPath("//*[@id='docTree_C_ctl01_rtvSiteTree']//a[contains(text(), 'Assessor PIN or Tax Lot No')]/.."),
        //    siteTreeAdditionalSitesCategory = By.XPath("//*[@id='docTree_C_ctl01_rtvSiteTree']//li[./div/span[contains(text(), 'Additional Sites')]]"),

        //    recordTreeParentActivitiesCategory = By.XPath("//*[@id='docTree_C_ctl00_rtvRecordTree']//li[./div/span[contains(text(), 'Parent Activities')]]"),
        //    recordTreeParentPermitsCategory = By.XPath("//*[@id='docTree_C_ctl00_rtvRecordTree']//li[./div/span[contains(text(), 'Parent Permits')]]"),
        //    recordTreeParentProjectsCategory = By.XPath("//*[@id='docTree_C_ctl00_rtvRecordTree']//li[./div/span[contains(text(), 'Parent Projects')]]"),
        //    recordTreePermitsCategory = By.XPath("//*[@id='docTree_C_ctl00_rtvRecordTree']//li[./div/span[contains(text(), 'Permits') and not(contains(text(), 'Parent'))]]"),
        //    recordTreeCasesCategory = By.XPath("//*[@id='docTree_C_ctl00_rtvRecordTree']//li[./div/span[contains(text(), 'Cases') and not(contains(text(), 'Parent'))]]"),
        //    recordTreeIssuesCategory = By.XPath("//*[@id='docTree_C_ctl00_rtvRecordTree']//li[./div/span[contains(text(), 'Issues') and not(contains(text(), 'Parent'))]]"),
        //    recordTreeLicensesCategory = By.XPath("//*[@id='docTree_C_ctl00_rtvRecordTree']//li[./div/span[contains(text(), 'Licenses') and not(contains(text(), 'Parent'))]]"),

        //    editRecordGeoHouseNumberInput = By.Id("ctl09_C_ctl00_txtSiteNumber"),
        //    editRecordGeoStreetNameInput = By.Id("ctl09_C_ctl00_txtSiteStreetName"),
        //    editRecordGeoUnitNumberInput = By.Id("ctl09_C_ctl00_txtSiteUnitNo"),
        //    editRecordGeoCityInput = By.Id("ctl09_C_ctl00_txtSiteCity"),
        //    editRecordGeoStateInput = By.Id("ctl09_C_ctl00_txtSiteState"),
        //    editRecordGeoZipInput = By.Id("ctl09_C_ctl00_txtSiteZip"),
        //    editRecordGeoTractInput = By.Id("ctl09_C_ctl00_txtSiteTract"),
        //    editRecordGeoBlockInput = By.Id("ctl09_C_ctl00_txtSiteBlock"),
        //    editRecordGeoLotInput = By.Id("ctl09_C_ctl00_txtSiteLotNo"),
        //    editRecordGeoSubdivisionInput = By.Id("ctl09_C_ctl00_txtSiteSubdivision"),

        //    linkedGeoAddress = By.Id("ctl09_C_ctl00_lblSiteAddress"),
        //    linkedGeoCity = By.Id("ctl09_C_ctl00_lblSiteCity"),
        //    linkedGeoState = By.Id("ctl09_C_ctl00_lblSiteState"),
        //    linkedGeoZip = By.Id("ctl09_C_ctl00_lblSiteZip"),
        //    linkedGeoTract = By.Id("ctl09_C_ctl00_lblSiteTract"),
        //    linkedGeoBlock = By.Id("ctl09_C_ctl00_lblSiteBlock"),
        //    linkedGeoLot = By.Id("ctl09_C_ctl00_lblSiteLotNo"),
        //    linkedGeoSubdivision = By.Id("ctl09_C_ctl00_lblSiteSubdivision");

        //public string GetPageTitle()
        //{
        //    CommonPage commonPage = new CommonPage(_webDriver);
        //    commonPage.SwitchToFrame("FRMPERMIT");
        //    string pageTitle = commonPage.getPageTitle(informationPane);
        //    return pageTitle;
        //}

        public IWebElement ReturnHeaderElement()
        {
            return informationPane;
        }

        public void HoverElement()
        {
            common.HoverElement(btnAddNotes);
        }

        //public void ClickPane()
        //{
        //    Actions actions = new Actions(_webDriver);
        //    actions.DoubleClick(informationBar);
        //    Thread.Sleep(10000);
        //}
    }
}
