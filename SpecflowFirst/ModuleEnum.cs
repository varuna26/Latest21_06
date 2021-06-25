using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowFirst
{
    public enum ModuleEnum
    {
        Workspace,
        Permitting,
        LandManagement,
        Contacts
    }

    public enum FrameNameEnum
    {
        FRMPERMIT,
        FRMLAND
    }

    public enum ActionType
    {
        Add,
        Edit,
        Delete,
        Save
    }

    public enum PaneTypeEnum
    {
        Inspections,
        Contacts,
        FinancialInformation,
        Chronology,
        Reviews,
        Permitting

    }
}
