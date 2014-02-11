﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08/02/2012
 * Time: 02:29 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    extern alias UIANET;
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of NewUiaWizardCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "UiaWizard")]
    public class NewUiaWizardCommand : WizardContainerCmdletBase
    {
        public NewUiaWizardCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ScriptBlock[] StartAction { get; set; }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] StopAction { get; set; }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] DefaultStepForwardAction { get; set; }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] DefaultStepBackwardAction { get; set; }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] DefaultStepCancelAction { get; set; }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] GetWindowAction { get; set; }
//        [Parameter(Mandatory = false)]
//        internal int Order { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            NewWizardCommand command =
                new NewWizardCommand(this);
            command.Execute();
        }
        
    }
}
