using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowFirst.Pages
{
    public class InspectionPage
    {
        private IWebDriver _webDriver;

        public InspectionPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        // contains CRUD locators for inspections

        //public static string
        //    addFrame = "rw",
        //    editFrame = "rw",
        //    notesFrame = "rw",
        //    newInspectionClass = "New-Inspections-ListItem",
        //    inspectionHistoryFrame = "rw";

        IWebElement inspectionItem => _webDriver.FindElement(By.ClassName("Inspections-ListItem"));

        IWebElement inspectionName => _webDriver.FindElement(By.XPath(".//*[contains(@id, \"lblInspectorName\")]/span[2]"));

        IWebElement inspectionType => _webDriver.FindElement(By.XPath(".//*[contains(@id, \"_lblInspectionType\")]"));

        IWebElement newInspectionItem => _webDriver.FindElement(By.ClassName("New-Inspections-ListItem"));

        IWebElement inspectionRemarks => _webDriver.FindElement(By.XPath(".//*[contains(@id, \"_lblRemarks\")]/span[2]"));

        IWebElement inspectionResult => _webDriver.FindElement(By.XPath(".//*[contains(@id, \"_lblResult\")]/span[2]"));

        IWebElement inspectionCompletedDate => _webDriver.FindElement(By.XPath(".//*[contains(@id, \"_lblCompletedDate\")]/span[2]"));

        IWebElement inspectionCompletedTime => _webDriver.FindElement(By.XPath(".//*[contains(@id, \"_lblCompletedTime\")]/span[1]"));

        IWebElement inspectionScheduledDate => _webDriver.FindElement(By.XPath(".//*[contains(@id, \"_lblScheduledDate\")]/span[2]"));
        IWebElement inspectionScheduledTime => _webDriver.FindElement(By.XPath(".//*[contains(@id, \"_lblScheduledTime\")]/span[1]"));

        IWebElement inspectionScheduledDuration => _webDriver.FindElement(By.XPath(".//*[contains(@id, \"_lblScheduledTime\")]/span[2]"));
        IWebElement inspectionEditButton => _webDriver.FindElement(By.XPath(".//*[contains(@id, \"_btnEdit\")]"));

        IWebElement inspectionViewNotesButton => _webDriver.FindElement(By.XPath(".//*[contains(@id, \"_btnViewNotes\")]"));
        IWebElement inspectionMenu => _webDriver.FindElement(By.XPath(".//*[contains(@id, \"_radInspectionsMenu\")]"));

        IWebElement inspectionVoidedImg => _webDriver.FindElement(By.XPath(".//img[contains(@id, \"_imgInspectionVoided\")]"));
        IWebElement inspectionEditTypeInput => _webDriver.FindElement(By.Id("ctl08_ddInspectionType_Input"));

        IWebElement inspectionEditTypeDropDown => _webDriver.FindElement(By.Id("ctl08_ddInspectionType_DropDown"));

        IWebElement inspectionEditInspectorInput => _webDriver.FindElement(By.Id("ctl08_ddInspector_Input"));
        IWebElement inspectionEditInspectorDropDown => _webDriver.FindElement(By.Id("ctl08_ddInspector_DropDown"));

        IWebElement inspectionEditScheduleDateInput => _webDriver.FindElement(By.Id("ctl08_calScheduledDate_dateInput"));

        IWebElement inspectionEditScheduleDateTodayButton => _webDriver.FindElement(By.Id("ctl08_btnScheduledDateToday"));

        IWebElement inspectionEditScheduleTimeInput => _webDriver.FindElement(By.Id("ctl08_ddScheduledTime_Input"));

        IWebElement inspectionEditScheduleTimeDropDown => _webDriver.FindElement(By.Id("ctl08_ddScheduledTime_DropDown"));

        IWebElement inspectionEditDurationInput => _webDriver.FindElement(By.Id("ctl08_ddDuration_Input"));

        IWebElement inspectionEditDurationDropDown => _webDriver.FindElement(By.Id("ctl08_ddDuration_DropDown"));

        IWebElement inspectionEditResultInput => _webDriver.FindElement(By.Id("ctl08_ddResult_Input"));

        IWebElement inspectionEditResultDropDown => _webDriver.FindElement(By.Id("ctl08_ddResult_DropDown"));

        IWebElement inspectionEditRemarksInput => _webDriver.FindElement(By.Id("ctl08_txtRemarks"));

        IWebElement inspectionEditCompletedDateInput => _webDriver.FindElement(By.Id("ctl08_calCompletedDate_dateInput"));

        IWebElement inspectionEditCompletedDateTodayButton => _webDriver.FindElement(By.Id("ctl08_btnCompletedDateToday"));

        IWebElement inspectionEditCompletedTimeInput => _webDriver.FindElement(By.Id("ctl08_ddCompletedTime_Input"));

        IWebElement inspectionEditCompletedTimeDropDown => _webDriver.FindElement(By.Id("ctl08_ddCompletedTime_DropDown"));

        IWebElement inspectionEditAddToTimesheetInput => _webDriver.FindElement(By.Id("ctl08_txtAddTimeSheet"));

        IWebElement inspectionEditAddNotesInput => _webDriver.FindElement(By.Id("ctl08_ctrlNotes_txtNoteSave"));

        IWebElement inspectorInput => _webDriver.FindElement(By.Id("ctl08_ddInspector_Input"));

        IWebElement inspectorDropDown => _webDriver.FindElement(By.Id("ctl08_ddInspector_DropDown"));

        IWebElement setDefaultInput => _webDriver.FindElement(By.Id("ctl08_ddSetDefault_Input"));

        IWebElement setDefaultDropDown => _webDriver.FindElement(By.Id("ctl08_ddSetDefault_DropDown"));
        IWebElement scheduleDateInput => _webDriver.FindElement(By.Id("ctl08_calScheduledDate_dateInput"));
        IWebElement timeInput => _webDriver.FindElement(By.Id("ctl08_ddScheduleTime_Input"));
        IWebElement timeDropDown => _webDriver.FindElement(By.Id("ctl08_ddScheduleTime_DropDown"));
        IWebElement dateTodayButton => _webDriver.FindElement(By.Id("ctl08_btnScheduledDateToday"));

        IWebElement inspectionHistoryItem => _webDriver.FindElement(By.XPath(".//*[contains(@id, \"_tblListViewItem\")]"));
    }
}
